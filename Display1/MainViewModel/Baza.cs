using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Display1.Model;

namespace Display1.MainViewModel
{
    public static class Baza
    {
        private static string UserDB = "sa";
        private static string PassDB = "Leopard12";
        public static string AdressDB = @"DELL_MARCIN";
        public static string NameDB = "CDNXL_ARCUS_2017_2_1";
        private static string PolaczenieSQL = PolaczenieSQL = @"Server=" + AdressDB + ";user=" + UserDB + ";password=" + PassDB + ";database=" + NameDB + "";
        private static SqlConnection polaczsql;

        public static BindingList<Model.Downloading> SQL_SelectDownloading(string dataOd, string dataDo)
        {
            BindingList<Model.Downloading> lista_downloading = new BindingList<Model.Downloading>();
            try
            {
                string zapytanie = $@"select DISTINCT TrN_KrajPrzezWys
from cdn.PCN_FAI 
join cdn.TraNag on TraNag.trn_gidnumer = PCN_FAI.Trn_GIDNumer 
where TrN_TrNSeria ='I'  and TrN_GIDTyp = 1521 and 
TrN_Data2 >= datediff (day,'1800-12-28','{dataOd}') and 
TrN_Data2 <= datediff (day,'1800-12-28','{dataDo}') ";
                polaczsql = new SqlConnection(PolaczenieSQL);
                using (polaczsql)
                {
                    SqlCommand pobierz_zlecenia = new SqlCommand();
                    pobierz_zlecenia.Connection = polaczsql;
                    pobierz_zlecenia.CommandText = zapytanie;
                    polaczsql.Open();
                    SqlDataReader reader = pobierz_zlecenia.ExecuteReader();
                    while (reader.Read())
                    {
                        Model.Downloading downloading = new Model.Downloading();
                        downloading.TrN_KrajPrzezWys = reader["TrN_KrajPrzezWys"].ToString();
                        lista_downloading.Add(downloading);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            polaczsql.Close();
            return lista_downloading;

        }

        public static BindingList<Model.List> SQL_SelectList(string dataOd, string dataDo, string kraj)
        {
            BindingList<Model.List> lista_list = new BindingList<Model.List>();
            try
            {
                string zapytanie = $@"select dateadd(day,trn_data2,'18001228') as DataDokumentu ,cdn.NazwaObiektu(trn_gidtyp,cdn.TraNag.TrN_GIDNumer,0,2) as NumerDokumentu,PCN_NAZWA, 
PCN_WAGA_BRUTTO 
,PCN_WAGA_NETTO
,PCN_WARTOSC
,PCN_M2
from cdn.PCN_FAI 
join cdn.TraNag on TraNag.trn_gidnumer = PCN_FAI.Trn_GIDNumer 
where TrN_TrNSeria ='I'  and TrN_GIDTyp = 1521 and 
TrN_Data2 >= datediff (day,'1800-12-28','{dataOd}') and 
TrN_Data2 <= datediff (day,'1800-12-28','{dataDo}') 
and TrN_KrajPrzezWys = '{kraj}' -- Hiszpania
order by PCN_NAZWA, TrN_Data2 ";
                polaczsql = new SqlConnection(PolaczenieSQL);
                using (polaczsql)
                {
                    SqlCommand pobierz_zlecenia = new SqlCommand();
                    pobierz_zlecenia.Connection = polaczsql;
                    pobierz_zlecenia.CommandText = zapytanie;
                    polaczsql.Open();
                    SqlDataReader reader = pobierz_zlecenia.ExecuteReader();
                    while (reader.Read())
                    {
                        Model.List list = new Model.List();
                        list.DataDokumentu = (DateTime)reader["DataDokumentu"];
                        list.NumerDokumentu = reader["NumerDokumentu"].ToString();
                        list.PCN_NAZWA = (int)reader["PCN_NAZWA"];
                        list.PCN_WAGA_BRUTTO = (decimal)reader["PCN_WAGA_BRUTTO"];
                        list.PCN_WAGA_NETTO = (decimal)reader["PCN_WAGA_NETTO"];
                        list.PCN_WARTOSC = (decimal)reader["PCN_WARTOSC"];
                        list.PCN_M2 = (decimal)reader["PCN_M2"];
                        lista_list.Add(list);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            polaczsql.Close();
            return lista_list;

        }
        public static BindingList<Model.Sum> SQL_SelectSum(string dataOd, string dataDo, string kraj)
        {
            BindingList<Model.Sum> lista_sum = new BindingList<Model.Sum>();
            try
            {
                string zapytanie = $@"select PCN_NAZWA, 
sum (PCN_WAGA_BRUTTO ) as PCN_WAGA_BRUTTO
, sum(PCN_WAGA_NETTO) as PCN_WAGA_NETTO
,sum (PCN_WARTOSC) as PCN_WARTOSC
,sum (PCN_M2) as PCN_M2
from cdn.PCN_FAI 
join cdn.TraNag on TraNag.trn_gidnumer = PCN_FAI.Trn_GIDNumer 
where TrN_TrNSeria ='I'  and TrN_GIDTyp = 1521 and 
TrN_Data2 >= datediff (day,'1800-12-28','{dataOd}') and 
TrN_Data2 <= datediff (day,'1800-12-28','{dataDo}') 
and TrN_KrajPrzezWys = '{kraj}' -- Hiszpania
group by PCN_NAZWA";
                polaczsql = new SqlConnection(PolaczenieSQL);
                using (polaczsql)
                {
                    SqlCommand pobierz_zlecenia = new SqlCommand();
                    pobierz_zlecenia.Connection = polaczsql;
                    pobierz_zlecenia.CommandText = zapytanie;
                    polaczsql.Open();
                    SqlDataReader reader = pobierz_zlecenia.ExecuteReader();
                    while (reader.Read())
                    {
                        Model.Sum sum = new Model.Sum();
                        sum.PCN_NAZWA = (int)reader["PCN_NAZWA"];
                        sum.PCN_WAGA_BRUTTO = (decimal)reader["PCN_WAGA_BRUTTO"];
                        sum.PCN_WAGA_NETTO = (decimal)reader["PCN_WAGA_NETTO"];
                        sum.PCN_WARTOSC = (decimal)reader["PCN_WARTOSC"];
                        sum.PCN_M2 = (decimal)reader["PCN_M2"];
                        lista_sum.Add(sum);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            polaczsql.Close();
            return lista_sum;

        }
    }
}
