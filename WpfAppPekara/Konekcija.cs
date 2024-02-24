using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPekara
{
    public class Konekcija
    {
        public SqlConnection KreirajKonekciju()
        {
            //pruza jednostavan nacin za kreiranje i upravljanje sadrzajem konekcionog stringa
            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder
            {
                DataSource = @"DESKTOP-R3IS70R\SQLEXPRESS", //naziv lokalnog servera Vašeg računara
                InitialCatalog = "Pekara2", //Baza na lokalnom serveru
                IntegratedSecurity = true //koristice se trenutni windows kredencijali za autentifikaciju, u slucaju da je false potrebno bi bilo u okviru konekcionog stringa navesti User ID i password
            };
            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;
        }
    }
}
