using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppPekara.Forme
{
    /// <summary>
    /// Interaction logic for FrmProiy.xaml
    /// </summary>
    public partial class FrmPorudzbina : Window
    {
        
            Konekcija kon = new Konekcija();
            SqlConnection konekcija = new SqlConnection();
            private bool azuriraj;
            private DataRowView red;

            public FrmPorudzbina()
            {
                InitializeComponent();
                //fokus
                konekcija = kon.KreirajKonekciju();
                PopuniPadajuceListe();
            }

            public FrmPorudzbina(bool azuriraj, DataRowView red)
            {
                this.azuriraj = azuriraj;
                this.red = red;
                InitializeComponent();
                konekcija = kon.KreirajKonekciju();
                PopuniPadajuceListe();
            }

            private void PopuniPadajuceListe()
            {
                try
                {
                    konekcija.Open();

                    string vratiProizvod = @"select proizvodID, naziv from tblProizvod";
                    SqlDataAdapter daProizvod = new SqlDataAdapter(vratiProizvod, konekcija);
                    DataTable dtProizvod= new DataTable();
                    daProizvod.Fill(dtProizvod);
                    cbProizvod.ItemsSource = dtProizvod.DefaultView;
                    dtProizvod.Dispose();
                    dtProizvod.Dispose();

                    string vratiKasira = @"select kasirID, prezime from tblKasir";
                    SqlDataAdapter daKasir = new SqlDataAdapter(vratiKasira, konekcija);
                    DataTable dtKasir = new DataTable();
                    daKasir.Fill(dtKasir);
                    cbKasir.ItemsSource = dtKasir.DefaultView;
                    dtKasir.Dispose();
                    dtKasir.Dispose();

                    string vratiKupca = @"select ime, kupacID from tblKuupac";
                    SqlDataAdapter daKupac = new SqlDataAdapter(vratiKupca, konekcija);
                    DataTable dtKupac = new DataTable();
                    daKupac.Fill(dtKupac);
                    cbKupac.ItemsSource = dtKupac.DefaultView;
                    dtKupac.Dispose();
                    dtKupac.Dispose();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Padajuce liste nisu popunjene", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (konekcija != null)
                    {
                        konekcija.Close();
                    }
                }
            }
            private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    konekcija.Open();
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija
                    };

                    cmd.Parameters.Add("@kolicinaP", SqlDbType.Int).Value = txtKolicina.Text;
                    cmd.Parameters.Add("@proizvod", SqlDbType.Int).Value = cbProizvod.SelectedValue;
                    cmd.Parameters.Add("@kupac", SqlDbType.Int).Value = cbKupac.SelectedValue;
                    cmd.Parameters.Add("@kasir", SqlDbType.Int).Value = cbKasir.SelectedValue;

                    if (azuriraj)
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                        cmd.CommandText = @"update tblPorudzbina
                                       set kolicinaP=@kolicinaP, kupacID=@kupac,
                                        kasirID = @kasir, proizvodID = @proizvod
                                       where porudzbinaID  = @id";
                        red = null;
                    }
                    else
                    {
                        cmd.CommandText = @"insert into tblPorudzbina(kolicinaP, kasirID, kupacID, proizvodID)
                                        VALUES (@kolicinaP, @kasir, @kupac, @proizvod)";
                    }
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    this.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Doslo je do greske prilikom konverzija podataka", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (konekcija != null)
                    {
                        konekcija.Close();
                    }
                }
            }

            private void btnOtkazi_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
        
    }
}
