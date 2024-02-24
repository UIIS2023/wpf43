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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppPekara.Forme;
using System.Windows.Controls.Primitives;

namespace WpfAppPekara
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string ucitanaTabela;
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        #region Select upiti
        private static string proizvodSelect =@"select proizvodID as ID, naziv as 'Proizvod', kolicinaS as 'Proizvodi na stanju', cena as 'Cena', pekarID as 'Pekar' from tblProizvod";
        private static string pekarSelect = @"select pekarID as ID, ime + ' ' + prezime as 'Ime i prezime pekara', jmbg as 'JMBG', telefon as 'Kontakt pekara' from tblPekar";
        private static string kupacSelect = @"select kupacID as ID, ime + ' ' + prezime as 'Ime i prezime korisnika', telefon as 'Kontakt kupca' from tblKuupac";
        private static string kasirSelect = @"select kasirID as ID, ime + ' ' + prezime as 'Ime i prezime kasiira' from tblKasir";
        private static string porudzbinaSelect = @" Select porudzbinaID as ID, naziv as 'Proizvod' ,kolicinaP as 'Kupljeno proizvoda', ime as 'Kupac' from tblPorudzbina
                                             join tblProizvod on tblPorudzbina.proizvodID = tblProizvod.proizvodID
                                             join tblKuupac on tblPorudzbina.kupacID = tblKuupac.kupacID";
            // @"select porudzbinaID as ID, proizvodID as 'ID porucenog proizvoda', kolicinaP as 'Kolicina porucenog proizvoda', kupacID as 'ID kupca', kasirID as 'ID kasira' from tblPorudzbina";
        private static string nabavkaSelect = @"select nabavkaID as ID, kolicina as 'Kolicina nabavljenog materijala', cena as 'cena nabavke' from tblNabavka";
        private static string materijalSelect = @"select materijalID as ID, naziv as 'Naziv', kolicina as 'Kolicina na stanju', nabavkaID as 'ID nabavke materijala' from tblMaterijal";
        private static string receptSelect =@"select receptID as ID, proizvodID as 'ID proizvoda', materijalID as 'ID potrebnog materijala' from tblRecept";
        private static string dobavljacSelect =@"select dobavljacID as ID, ime as 'Ime dobavljaca', telefon as 'Kontakt dobavljaca', nabavkaID as 'ID nabavke' from tblDobavljac";
        #endregion

        #region Select sa uslovom

        private static string selectUslovProizvod = @"select * from tblProizvod where proizvodID=";
        private static string selectUslovPorudzbina = @"select * from tblPorudzbina where porudzbinaID=";
        private static string selectUslovPekar = @"select * from tblPekar where pekarID=";
        private static string selectUslovKasir = @"select * from tblKasir where kasirID=";
        private static string selectUslovKupac = @"select * from tblKuupac where kupacID=";
        private static string selectUslovNabavka = @"select * from tblNabavka where nabavkaID=";
        private static string selectUslovMaterijal = @"select * from tblMaterijal where materijalID=";
        private static string selectUslovDobavljac = @"select * from tblDobavljac where dobavljacID=";
        private static string selectUslovRecept = @"select * from tblRecept where receptID=";



        #endregion

        #region Delete naredbe



        private static string deleteProizvod = @"delete  from tblProizvod where proizvodID=";
        private static string deletePorudzbina = @"delete from tblPorudzbina where porudzbinaID=";
        private static string deletePekar = @"delete from tblPekar where pekarID=";
        private static string deleteKasir = @"delete from tblKasir where kasirID=";
        private static string deleteKupac = @"delete from tblKuupac where kupacID=";
        private static string deleteNabavka = @"delete from tblNabavka where nabavkaID=";
        private static string deleteMaterijal = @"delete from tblMaterijal where materijalID=";
        private static string deleteDobavljac = @"delete from tblDobavljac where dobavljacID=";
        private static string deleteRecept = @"delete from tblRecept where receptID=";

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(pekarSelect);
        }

        private void UcitajPodatke(string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataGridCentralni != null)
                {
                    dataGridCentralni.ItemsSource = dataTable.DefaultView;
                }
                ucitanaTabela = selectUpit;
                dataAdapter.Dispose();
                dataTable.Dispose();

            }
            catch (SqlException)
            {
                MessageBox.Show("Neuspesno ucitani podaci!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
        private void btnPekar_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(pekarSelect);
        }

        private void btnProizvod_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(proizvodSelect);
        }

        private void btnKupac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(kupacSelect);
        }

        private void btnKasir_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(kasirSelect);
        }

        private void btnPorudzbina_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(porudzbinaSelect);
        }

        private void btnDobavljac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(dobavljacSelect);
        }

        private void btnMaterijal_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(materijalSelect);
        }

        private void btnNabavka_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(nabavkaSelect);
        }

        private void btnRecept_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(receptSelect);
        }

        private void popuniFormu(string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                red = (DataRowView)dataGridCentralni.SelectedItems[0];
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader citac = cmd.ExecuteReader();
                if (citac.Read())
                {
                    if (ucitanaTabela.Equals(proizvodSelect))
                    {
                        FrmProizvod prozorProizvod = new FrmProizvod(azuriraj, red);
                        prozorProizvod.txtNaziv.Text = citac["naziv"].ToString();
                        prozorProizvod.txtCena.Text = citac["cena"].ToString();
                        prozorProizvod.txtKolicina.Text = citac["kolicinaS"].ToString();
                        prozorProizvod.cbPekar.SelectedValue = citac["pekarID"];
                        prozorProizvod.ShowDialog();

                    }
                    else if (ucitanaTabela.Equals(porudzbinaSelect))
                    {
                        FrmPorudzbina prozorPorudzbina = new FrmPorudzbina(azuriraj, red);
                        prozorPorudzbina.txtKolicina.Text = citac["kolicinaP"].ToString();
                        prozorPorudzbina.cbKasir.SelectedValue = citac["kasirID"];
                        prozorPorudzbina.cbKupac.SelectedValue = citac["kupacID"];
                        prozorPorudzbina.cbProizvod.SelectedValue = citac["proizvodID"];
                        prozorPorudzbina.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(pekarSelect))
                    {
                        FrmPekar prozorPekar = new FrmPekar(azuriraj, red);
                        prozorPekar.txtIme.Text = citac["ime"].ToString();
                        prozorPekar.txtPrezime.Text = citac["prezime"].ToString();
                        prozorPekar.txtJMBG.Text = citac["jmbg"].ToString();
                        prozorPekar.txtTelefon.Text = citac["telefon"].ToString();
                        prozorPekar.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(dobavljacSelect))
                    {
                        FrmDobavljac prozorDobavljac = new FrmDobavljac(azuriraj, red);
                        prozorDobavljac.txtIme.Text = citac["ime"].ToString();
                        prozorDobavljac.txtTelefon.Text = citac["telefon"].ToString();
                        prozorDobavljac.cbNabavka.SelectedValue = citac["nabavkaID"];
                        prozorDobavljac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(kasirSelect))
                    {
                        FrmKasir prozorKasir = new FrmKasir(azuriraj, red);
                        prozorKasir.txtIme.Text = citac["ime"].ToString();
                        prozorKasir.txtPrezime.Text = citac["prezime"].ToString();
                        prozorKasir.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(kupacSelect))
                    {
                        FrmKupac prozorKupac = new FrmKupac(azuriraj, red);
                        prozorKupac.txtIme.Text = citac["ime"].ToString();
                        prozorKupac.txtPrezime.Text = citac["prezime"].ToString();
                        prozorKupac.txtTelefon.Text = citac["telefon"].ToString();
                        prozorKupac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(materijalSelect))
                    {
                        FrmMaterijal prozorMaterijal = new FrmMaterijal(azuriraj, red);
                        prozorMaterijal.txtNaziv.Text = citac["naziv"].ToString();
                        prozorMaterijal.txtKolicina.Text = citac["kolicina"].ToString();
                        prozorMaterijal.cbNabavka.SelectedValue = citac["nabavkaID"];
                        prozorMaterijal.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(nabavkaSelect))
                    {
                        FrmNabavka prozorNabavka = new FrmNabavka(azuriraj, red);
                        prozorNabavka.txtCena.Text = citac["cena"].ToString();
                        prozorNabavka.txtKolicina.Text = citac["kolicina"].ToString();

                        prozorNabavka.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(receptSelect))
                    {
                        FrmRecept prozorRecept = new FrmRecept(azuriraj, red);
                        prozorRecept.cbProizvod.SelectedValue = citac["proizvodID"];
                        prozorRecept.cbMaterijal.SelectedValue = citac["materijalID"];
                        prozorRecept.ShowDialog();
                    }

                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        
        

        private void ObrisiZapis(string deleteUpit)
        {
            try
            {
                konekcija.Open();
                red = (DataRowView)dataGridCentralni.SelectedItems[0];
                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da želite da obrišete odabrane podatke?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = konekcija

                    };
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = deleteUpit + "@id";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }

        private void btnIzmeni_Click_1(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(proizvodSelect))
            {
                popuniFormu(selectUslovProizvod);
                UcitajPodatke(proizvodSelect);
            }
            else if (ucitanaTabela.Equals(porudzbinaSelect))
            {
                popuniFormu(selectUslovPorudzbina);
                UcitajPodatke(porudzbinaSelect);
            }
            else if (ucitanaTabela.Equals(pekarSelect))
            {
                popuniFormu(selectUslovPekar);
                UcitajPodatke(pekarSelect);
            }
            else if (ucitanaTabela.Equals(kupacSelect))
            {
                popuniFormu(selectUslovKupac);
                UcitajPodatke(kupacSelect);
            }
            else if (ucitanaTabela.Equals(kasirSelect))
            {
                popuniFormu(selectUslovKasir);
                UcitajPodatke(kasirSelect);
            }
            else if (ucitanaTabela.Equals(nabavkaSelect))
            {
                popuniFormu(selectUslovNabavka);
                UcitajPodatke(nabavkaSelect);
            }
            else if (ucitanaTabela.Equals(dobavljacSelect))
            {
                popuniFormu(selectUslovDobavljac);
                UcitajPodatke(dobavljacSelect);
            }
            else if (ucitanaTabela.Equals(receptSelect))
            {
                popuniFormu(selectUslovRecept);
                UcitajPodatke(receptSelect);
            }
            else if (ucitanaTabela.Equals(materijalSelect))
            {
                popuniFormu(selectUslovMaterijal);
                UcitajPodatke(materijalSelect);
            }
        }

        private void btnDodaj_Click_1(object sender, RoutedEventArgs e)
        {
            Window prozor;
            if (ucitanaTabela.Equals(proizvodSelect))
            {
                prozor = new FrmProizvod();
                prozor.ShowDialog();
                UcitajPodatke(proizvodSelect);
            }
            else if (ucitanaTabela.Equals(porudzbinaSelect))
            {
                prozor = new FrmPorudzbina();
                prozor.ShowDialog();
                UcitajPodatke(porudzbinaSelect);
            }
            else if (ucitanaTabela.Equals(pekarSelect))
            {
                prozor = new FrmPekar();
                prozor.ShowDialog();
                UcitajPodatke(pekarSelect);
            }
            else if (ucitanaTabela.Equals(dobavljacSelect))
            {
                prozor = new FrmDobavljac();
                prozor.ShowDialog();
                UcitajPodatke(dobavljacSelect);
            }
            else if (ucitanaTabela.Equals(nabavkaSelect))
            {
                prozor = new FrmNabavka();
                prozor.ShowDialog();
                UcitajPodatke(nabavkaSelect);
            }
            else if (ucitanaTabela.Equals(receptSelect))
            {
                prozor = new FrmRecept();
                prozor.ShowDialog();
                UcitajPodatke(receptSelect);
            }
            else if (ucitanaTabela.Equals(kasirSelect))
            {
                prozor = new FrmKasir();
                prozor.ShowDialog();
                UcitajPodatke(kasirSelect);
            }
            else if (ucitanaTabela.Equals(kupacSelect))
            {
                prozor = new FrmKupac();
                prozor.ShowDialog();
                UcitajPodatke(kupacSelect);
            }
            else if (ucitanaTabela.Equals(materijalSelect))
            {
                prozor = new FrmMaterijal();
                prozor.ShowDialog();
                UcitajPodatke(materijalSelect);
            }
        }
        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(proizvodSelect))
            {
                ObrisiZapis(deleteProizvod);
                UcitajPodatke(proizvodSelect);
            }
            else if (ucitanaTabela.Equals(porudzbinaSelect))
            {
                ObrisiZapis(deletePorudzbina);
                UcitajPodatke(porudzbinaSelect);
            }
            else if (ucitanaTabela.Equals(pekarSelect))
            {
                ObrisiZapis(deletePekar);
                UcitajPodatke(pekarSelect);
            }
            else if (ucitanaTabela.Equals(kupacSelect))
            {
                ObrisiZapis(deleteKupac);
                UcitajPodatke(kupacSelect);
            }
            else if (ucitanaTabela.Equals(kasirSelect))
            {
                ObrisiZapis(deleteKasir);
                UcitajPodatke(kasirSelect);
            }
            else if (ucitanaTabela.Equals(nabavkaSelect))
            {
                ObrisiZapis(deleteNabavka);
                UcitajPodatke(nabavkaSelect);
            }
            else if (ucitanaTabela.Equals(dobavljacSelect))
            {
                ObrisiZapis(deleteDobavljac);
                UcitajPodatke(dobavljacSelect);
            }
            else if (ucitanaTabela.Equals(receptSelect))
            {
                ObrisiZapis(deleteRecept);
                UcitajPodatke(receptSelect);
            }
            else if (ucitanaTabela.Equals(materijalSelect))
            {
                ObrisiZapis(deleteMaterijal);
                UcitajPodatke(materijalSelect);
            }
        }
    }
}

