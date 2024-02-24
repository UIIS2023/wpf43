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
    /// Interaction logic for FrmMaterijal.xaml
    /// </summary>
    public partial class FrmMaterijal : Window
    {
        
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmMaterijal()
        {
            InitializeComponent();
            txtNaziv.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();
        }

        public FrmMaterijal(bool azuriraj, DataRowView red)
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

                string vratiNabavku = @"SELECT nabavkaID, nabavkaID FROM tblNabavka";
                SqlDataAdapter daNabavka = new SqlDataAdapter(vratiNabavku, konekcija);
                DataTable dtNabavka = new DataTable();
                daNabavka.Fill(dtNabavka);
                cbNabavka.ItemsSource = dtNabavka.DefaultView;
                dtNabavka.Dispose();
                dtNabavka.Dispose();
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
                cmd.Parameters.Add("@kolicina", SqlDbType.Int).Value = txtKolicina.Text;
                cmd.Parameters.Add("@nabavka", SqlDbType.Int).Value = cbNabavka.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblMaterijal
                                       set naziv=@naziv, kolicina=@kolicina, nabavkaID=@nabavka,
                                       where materijalID  = @id";
                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblMaterijal(naziv, kolicina, nabavkaID)
                                        VALUES (@naziv, @kolicina, @nabavka)";
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

