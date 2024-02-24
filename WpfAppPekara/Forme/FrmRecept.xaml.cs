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
    /// Interaction logic for Recept.xaml
    /// </summary>
    public partial class FrmRecept : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmRecept()
        {
            InitializeComponent();
            //fokus
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmRecept(bool azuriraj, DataRowView red)
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
                DataTable dtProizvod = new DataTable();
                daProizvod.Fill(dtProizvod);
                cbProizvod.ItemsSource = dtProizvod.DefaultView;
                dtProizvod.Dispose();
                dtProizvod.Dispose();

                string vratiMaterijal = @"select naziv, materijalID from tblMaterijal";
                SqlDataAdapter daMaterijal = new SqlDataAdapter(vratiMaterijal, konekcija);
                DataTable dtMaterijal = new DataTable();
                daMaterijal.Fill(dtMaterijal);
                cbMaterijal.ItemsSource = dtMaterijal.DefaultView;
                dtMaterijal.Dispose();
                dtMaterijal.Dispose();

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

                cmd.Parameters.Add("@proizvod", SqlDbType.Int).Value = cbProizvod.SelectedValue;
                cmd.Parameters.Add("@materijal", SqlDbType.Int).Value = cbMaterijal.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblRecept
                                      set materijalID = @materijal, proizvodID = @proizvod
                                       where receptID  = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblRecept(materijalID, proizvodID)
                                        VALUES (@materijal, @proizvod)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Odaberite datum", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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
