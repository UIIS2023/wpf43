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
    /// Interaction logic for FrmProizvod.xaml
    /// </summary>
    public partial class FrmProizvod : Window
    {
            Konekcija kon = new Konekcija();
            SqlConnection konekcija = new SqlConnection();
            private bool azuriraj;
            private DataRowView red;

            public FrmProizvod()
            {
                InitializeComponent();
                txtNaziv.Focus();
                konekcija = kon.KreirajKonekciju();
                PopuniPadajuceListe();
            }

            public FrmProizvod(bool azuriraj, DataRowView red)
            {
                this.azuriraj = azuriraj;
                this.red = red;
                InitializeComponent();
                txtNaziv.Focus();
                konekcija = kon.KreirajKonekciju();
                PopuniPadajuceListe();
            }

            private void PopuniPadajuceListe()
            {
                try
                {
                    konekcija.Open();

                    string vratiPekara = @"select pekarID, ime from tblPekar";
                    SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiPekara, konekcija);
                    DataTable dtPekar = new DataTable();
                    daKorisnik.Fill(dtPekar);
                    cbPekar.ItemsSource = dtPekar.DefaultView;
                    dtPekar.Dispose();
                    dtPekar.Dispose();
  
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

                    cmd.Parameters.Add("@naziv", SqlDbType.NVarChar).Value = txtNaziv.Text;
                    cmd.Parameters.Add("@cena", SqlDbType.Real).Value = txtCena.Text;
                    cmd.Parameters.Add("@kolicinaS", SqlDbType.Int).Value = txtKolicina.Text;
                    cmd.Parameters.Add("@pekar", SqlDbType.Int).Value = cbPekar.SelectedValue;

                    if (azuriraj)
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                        cmd.CommandText = @"update tblProizvod
                                       set naziv=@naziv, cena=@cena, kolicinaS=@kolicinaS, pekarID=@pekar,
                                      
                                       where proizvodID  = @id";
                        red = null;
                    }
                    else
                    {
                        cmd.CommandText = @"insert into tblProizvod(naziv, cena, kolicinaS, pekarID)
                                        VALUES (@naziv, @cena, @kolicinaS, @pekar)";
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
