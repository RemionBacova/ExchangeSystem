using System;
using System.Collections.Generic;

using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ExchangeOnline.Lidhja
{
    public static class Kerkesat1
    {
        public static Kerkesat a = new Kerkesat();
        static Kerkesat1()
        {
           
        }
    }

    public class Kerkesat : IDisposable
    {
        static ExchangeOnline.Lidhja.LIDHJA z = new ExchangeOnline.Lidhja.LIDHJA();
        DataTable b;
        public Kerkesat()
        {
            b = new DataTable();
        }

        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue 
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }
        private IntPtr handle;
        private bool disposed = false;
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed 
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    b.Clear();
                    b.Dispose();
                }

                // Call the appropriate methods to clean up 
                // unmanaged resources here.
                // If disposing is false, 
                // only the following code is executed.
                CloseHandle(handle);
                handle = IntPtr.Zero;
            }
            disposed = true;
        }
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);


        #region select_statements

        //procedure 'excecuteScript' might be necessary

        public DataTable excecuteScript(string procedure_string)
        {
            b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "procedure_string";
            z.vektor[0, 1] = procedure_string;
            z.sp("excecuteScript", "tabela", ref b);

            return b;
        }

        public DataTable kursetByMonedha(string id_curr)
        {
            b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "id_curr";
            z.vektor[0, 1] = id_curr;
            z.sp("kursetByMonedha", "tabela", ref b);

            return b;
        }

        public DataTable getMesataretDitore(string curr_id)
        {
            b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "curr_id";
            z.vektor[0, 1] = curr_id;
            z.sp("getMesataretDitore", "tabela", ref b);

            return b;
        }

        public void excecuteInsertScript(string procedure_string)
        {
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "procedure_string";
            z.vektor[0, 1] = procedure_string;
            z.ip("excecuteScript");
        }

        public void insertLevizje(string curr_id, string arka_id, string prerje, string sasia, string transaksion_id, string insertion)
        {
            z.vektor = new string[6, 2];
            z.vektor[0, 0] = "curr_id";
            z.vektor[0, 1] = curr_id;
            z.vektor[1, 0] = "arka_id";
            z.vektor[1, 1] = arka_id;
            z.vektor[2, 0] = "prerje";
            z.vektor[2, 1] = prerje;
            z.vektor[3, 0] = "sasia";
            z.vektor[3, 1] = sasia;
            z.vektor[4, 0] = "transaksion_id";
            z.vektor[4, 1] = transaksion_id;
            z.vektor[5, 0] = "insertion";
            z.vektor[5, 1] = insertion;
            z.ip("insertLevizje");
        }

        public DataTable getBlerjeShitjeMonedhe(string monedha_id, string dita_sotme)
        {
            b.Clear();
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "monedha_id";
            z.vektor[0, 1] = monedha_id;
            z.vektor[1, 0] = "dita_sotme";
            z.vektor[1, 1] = dita_sotme;
            z.sp("getBlerjeShitjeMonedhe", "tabela", ref b);

            return b;
        }

        public DataTable getKursiBankesByMonedha(string monedha_id)
        {
            b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "monedha_id";
            z.vektor[0, 1] = monedha_id;
            z.sp("getKursiBankesByMonedha", "tabela", ref b);

            return b;
        }

        public DataTable getMinDenomByCurrency(string id_cur)
        {
            b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "id_cur";
            z.vektor[0, 1] = id_cur;
            z.sp("getMinDenomByCurrency", "tabela", ref b);

            return b;
        }

        public DataTable getUserInfoByUsernamePassword(string username, string password)
        {
            b.Clear();
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "username";
            z.vektor[0, 1] = username;
            z.vektor[1, 0] = "password";
            z.vektor[1, 1] = password;
            z.sp("getUserInfoByUsernamePassword", "tabela", ref b);

            return b;
        }

        public DataTable selectAllRecFromTable(string table)
        {
            b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "table";
            z.vektor[0, 1] = table;
            z.sp("selectAllRecFromTable", "tabela", ref b);

            return b;
        }

        public DataTable selectArkatByUser(string user_id)
        {
            b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "user_id";
            z.vektor[0, 1] = user_id;
            z.sp("selectArkatByUser", "tabela", ref b);

            return b;
        }

        public DataTable selectDenomValueByCurrency(string id_cur)
        {
            b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "id_cur";
            z.vektor[0, 1] = id_cur;
            z.sp("selectDenomValueByCurrency", "tabela", ref b);

            return b;
        }

        public DataTable selectFavoriteCurrencies()
        {
            b.Clear();
            z.vektor = new string[0, 2];
            z.sp("selectFavoriteCurrencies", "tabela", ref b);

            return b;
        }

        public DataTable selectGjendjet(string monedha_id, string arka_id)
        {
            b.Clear();
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "monedha_id";
            z.vektor[0, 1] = monedha_id;
            z.vektor[1, 0] = "arka_id";
            z.vektor[1, 1] = arka_id;
            z.sp("selectGjendjet", "tabela", ref b);

            return b;
        }

        public DataTable selectPrerjet(string monedha_id)
        {
            b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "monedha_id";
            z.vektor[0, 1] = monedha_id;
            z.sp("selectPrerjet", "tabela", ref b);

            return b;
        }

        public DataTable getRatesFromDate(string data_specifike)
        {
            b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "data_specifike";
            z.vektor[0, 1] = data_specifike;
            z.sp("getRatesFromDate", "tabela", ref b);

            return b;
        }

        public DataTable selectRecordByUserArka(string user_id, string arka_id)
        {
            b.Clear();
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "user_id";
            z.vektor[0, 1] = user_id;
            z.vektor[1, 0] = "arka_id";
            z.vektor[1, 1] = arka_id;
            z.sp("selectRecordByUserArka", "tabela", ref b);

            return b;
        }

        public DataTable selectUserDataById(string id)
        {
            b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "id";
            z.vektor[0, 1] = id;
            z.sp("selectUserDataById", "tabela", ref b);

            return b;
        }

        public DataTable selectUsers()
        {
            b.Clear();
            z.vektor = new string[0, 2];
            z.sp("selectUsers", "tabela", ref b);

            return b;
        }

        public DataTable selectSumByPeriudha(string data_references_char)
        {
            b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "data_references_char";
            z.vektor[0, 1] = data_references_char;
            z.sp("selectSumByPeriudha", "tabela", ref b);

            return b;
        }

        public DataTable selectSumByPeriudhaBlerje(string data_references_char)
        {
            b.Clear();
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "data_references_char";
            z.vektor[0, 1] = data_references_char;
            z.sp("selectSumByPeriudhaBlerje", "tabela", ref b);

            return b;
        }

        #endregion

        #region insert/update/delete_statements

        public void deleteFromTable(string id, string table)
        {
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "table";
            z.vektor[0, 1] = table;
            z.vektor[1, 0] = "id";
            z.vektor[1, 1] = id;
            z.ip("deleteFromTable");
        }

        public void insertArka(string monedha_id, string shitje, string blerje, string dita_sotme)
        {
            z.vektor = new string[4, 2];
            z.vektor[0, 0] = "monedha_id";
            z.vektor[0, 1] = monedha_id;
            z.vektor[1, 0] = "shitje";
            z.vektor[1, 1] = shitje.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".");
            z.vektor[2, 0] = "blerje";
            z.vektor[2, 1] = blerje.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".");
            z.vektor[3, 0] = "dita_sotme";
            z.vektor[3, 1] = dita_sotme;
            z.ip("insertArka");
        }

        public void importRateFromDate(string data_specifike, string data_sotme)
        {
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "data_specifike";
            z.vektor[0, 1] = data_specifike;
            z.vektor[1, 0] = "data_sotme";
            z.vektor[1, 1] = data_sotme;
            z.ip("importRateFromDate");
        }

        public void insertArkat(string emertimi)
        {
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "emertimi";
            z.vektor[0, 1] = emertimi;
            z.ip("insertArkat");
        }

        public void perdorKursin(string kursi_id)
        {
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "kursi_id";
            z.vektor[0, 1] = kursi_id;
            z.ip("perdorKursin");
        }

        public void insertBanka(string monedha_id, string shitje, string blerje)
        {
            z.vektor = new string[3, 2];
            z.vektor[0, 0] = "monedha_id";
            z.vektor[0, 1] = monedha_id;
            z.vektor[1, 0] = "shitje";
            z.vektor[1, 1] = shitje.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, "."); ;
            z.vektor[2, 0] = "blerje";
            z.vektor[2, 1] = blerje.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, "."); ;
            z.ip("insertBanka");
        }

        public void insertGjendje(string id_curr, string[] sasia, string arka_id)
        {
            string queryBuilder1 = "";
            string queryBuilder2 = "";
            int ctr = 0;
            for (int i = 0; i < sasia.Length; i++)
            {
                if (sasia[i] != "" && sasia[i] != null)
                {
                    ctr++;
                }
            }
            for (int i = 0; i < ctr; i++)
            {
                queryBuilder1 += " Sasia" + (i + 1).ToString() + ", ";
                queryBuilder2 += " " + sasia[i] + ",";
            }
            queryBuilder1 = queryBuilder1.Substring(0, queryBuilder1.Length - 2);
            queryBuilder2 = queryBuilder2.Substring(0, queryBuilder2.Length - 1);
            string procedure_string = "insert into gjendja(id_ark, id_curr, " + queryBuilder1 + ") values (" + arka_id + ", " + id_curr + ", " + queryBuilder2 + ")";
            

            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "procedure_string";
            z.vektor[0, 1] = procedure_string;
            z.ip("insertGjendje");
        }

        public void insertMinimalDenomination(string id_cur, string min_denom)
        {
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "id_cur";
            z.vektor[0, 1] = id_cur;
            z.vektor[1, 0] = "min_denom";
            z.vektor[1, 1] = min_denom.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".");
            z.ip("insertMinimalDenomination");
        }

        public void insertMonedha(string emertimi, bool isChecked)
        {
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "emertimi";
            z.vektor[0, 1] = emertimi;
            z.vektor[1, 0] = "isChecked";
            z.vektor[1, 1] = (isChecked ? "1" : "0");
            z.ip("insertMonedha");
        }

        public void insertPrerje(string id_curr, string[] prerjet)
        {
            string queryBuilder = "";
            string queryBuilder2 = "";
            int ctr = 0;
            for (int i = 0; i < prerjet.Length; i++)
            {
                if (prerjet[i] != "" && prerjet[i] != null)
                {
                    ctr++;
                }
            }
            for (int i = 0; i < ctr; i++)
            {
                queryBuilder += " tipi" + (i + 1).ToString() + ", ";
                queryBuilder2 += prerjet[i].Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".") + ", ";
            }
            queryBuilder = queryBuilder.Substring(0, queryBuilder.Length - 2);
            queryBuilder2 = queryBuilder2.Substring(0, queryBuilder2.Length - 2);

            string procedure_string = "insert into prerjet(id_curr, " + queryBuilder + " ) values (" + id_curr + ", " + queryBuilder2 + ")";


            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "procedure_string";
            z.vektor[0, 1] = procedure_string;
            z.ip("insertPrerje");
        }

        public DataTable insertTransaction(string id_user, DateTime Dita, DateTime Ora, string Tipi1, string Sasia1, string Tipi2, string Sasia2,
                string id_arka, string Blerje_shitje, string Emri_i_Klientit, string Kursi, string Transaksion)
        {
            z.vektor = new string[12, 2];
            z.vektor[0, 0] = "id_user";
            z.vektor[0, 1] = id_user;
            z.vektor[1, 0] = "Dita";
            z.vektor[1, 1] = Dita.ToString("dd/MM/yyyy");
            z.vektor[2, 0] = "Ora";
            z.vektor[2, 1] = Ora.TimeOfDay.ToString();
            z.vektor[3, 0] = "Tipi1";
            z.vektor[3, 1] = Tipi1;
            z.vektor[4, 0] = "Sasia1";
            z.vektor[4, 1] = Sasia1.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".");
            z.vektor[5, 0] = "Tipi2";
            z.vektor[5, 1] = Tipi2;
            z.vektor[6, 0] = "Sasia2";
            z.vektor[6, 1] = Sasia2.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".");
            z.vektor[7, 0] = "id_arka";
            z.vektor[7, 1] = id_arka;
            z.vektor[8, 0] = "Blerje_shitje";
            z.vektor[8, 1] = Blerje_shitje;
            z.vektor[9, 0] = "Emri_i_Klientit";
            z.vektor[9, 1] = Emri_i_Klientit;
            z.vektor[10, 0] = "Kursi";
            z.vektor[10, 1] = Kursi.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".");
            z.vektor[11, 0] = "Transaksion";
            z.vektor[11, 1] = Transaksion;
            z.sp("insertTransaction", "tabela", ref b);

            return b;
        }

        public void insertUser(string emri, string mbiemri, string ID, string perdoruesi, string fjalekalimi, string roli)
        {
            //shitje & blerje should have correct float format
            z.vektor = new string[6, 2];
            z.vektor[0, 0] = "emri";
            z.vektor[0, 1] = emri;
            z.vektor[1, 0] = "mbiemri";
            z.vektor[1, 1] = mbiemri;
            z.vektor[2, 0] = "ID";
            z.vektor[2, 1] = ID;
            z.vektor[3, 0] = "perdoruesi";
            z.vektor[3, 1] = perdoruesi;
            z.vektor[4, 0] = "fjalekalimi";
            z.vektor[4, 1] = fjalekalimi;
            z.vektor[5, 0] = "roli";
            z.vektor[5, 1] = roli;
            z.ip("insertUser");
        }

        public void caktoPerAnulim(string transaksion_id)
        {
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "transaksion_id";
            z.vektor[0, 1] = transaksion_id;
            z.ip("caktoPerAnulim");
        }

        public void decaktoPerAnulim(string transaksion_id)
        {
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "transaksion_id";
            z.vektor[0, 1] = transaksion_id;
            z.ip("decaktoPerAnulim");
        }

        public void resetTransaction(string transaksion_id)
        {
            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "transaksion_id";
            z.vektor[0, 1] = transaksion_id;
            z.ip("resetTransaction");
        }

        public void insertUserArka(string user_id, string arka_id)
        {
            //shitje & blerje should have correct float format
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "user_id";
            z.vektor[0, 1] = user_id;
            z.vektor[1, 0] = "arka_id";
            z.vektor[1, 1] = arka_id;
            z.ip("insertUserArka");
        }

        public void updateArka(string id, string shitje, string blerje, string dita_sotme)
        {
            //shitje & blerje should have correct float format
            z.vektor = new string[4, 2];
            z.vektor[0, 0] = "blerje";
            z.vektor[0, 1] = blerje.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, "."); ;
            z.vektor[1, 0] = "shitje";
            z.vektor[1, 1] = shitje.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, "."); ;
            z.vektor[2, 0] = "id";
            z.vektor[2, 1] = id;
            z.vektor[3, 0] = "dita_sotme";
            z.vektor[3, 1] = dita_sotme;
            z.ip("updateArka");
        }

        public void updateArkat(string id, string emertimi)
        {
            //shitje & blerje should have correct float format
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "emertimi";
            z.vektor[0, 1] = emertimi;
            z.vektor[1, 0] = "id";
            z.vektor[1, 1] = id;
            z.ip("updateArkat");
        }

        public void updateBanka(string id, string shitje, string blerje)
        {
            //shitje & blerje should have correct float format
            z.vektor = new string[3, 2];
            z.vektor[0, 0] = "blerje";
            z.vektor[0, 1] = blerje.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, "."); ;
            z.vektor[1, 0] = "shitje";
            z.vektor[1, 1] = shitje.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, "."); ;
            z.vektor[2, 0] = "id";
            z.vektor[2, 1] = id;
            z.ip("updateBanka");
        }

        public void updateGjendje(string id_curr, string[] sasia, string arka_id)
        {
            string queryBuilder = "";
            int ctr = 0;
            for (int i = 0; i < sasia.Length; i++)
            {
                if (sasia[i] != "" && sasia[i] != null)
                {
                    ctr++;
                }
            }
            for (int i = 0; i < ctr; i++)
            {
                queryBuilder += " Sasia" + (i + 1).ToString() + " = " + sasia[i] + ", ";
            }
            queryBuilder = queryBuilder.Substring(0, queryBuilder.Length - 2);
            string procedure_string = "update gjendja set " + queryBuilder + " where id_curr = " + id_curr + " and id_ark = " + arka_id;

            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "procedure_string";
            z.vektor[0, 1] = procedure_string;
            z.ip("updateGjendje");
        }

        public void updateMinimalDenomination(string id, string min_denom)
        {
            //shitje & blerje should have correct float format
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "min_denom";
            z.vektor[0, 1] = min_denom.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, "."); ;
            z.vektor[1, 0] = "id";
            z.vektor[1, 1] = id;
            z.ip("updateMinimalDenomination");
        }

        public void updateMonedha(string id, string emertimi, bool isChecked)
        {
            //shitje & blerje should have correct float format
            z.vektor = new string[3, 2];
            z.vektor[0, 0] = "emertimi";
            z.vektor[0, 1] = emertimi;
            z.vektor[1, 0] = "isChecked";
            z.vektor[1, 1] = (isChecked ? "1" : "0");
            z.vektor[2, 0] = "id";
            z.vektor[2, 1] = id;
            z.ip("updateMonedha");
        }

        public void updatePrerje(string id_curr, string[] prerjet)
        {
            string queryBuilderGjendja = "";

            string queryBuilder = "";
            int ctr = 0;
            for (int i = 0; i < prerjet.Length; i++)
            {
                if (prerjet[i] != "" && prerjet[i] != null)
                {
                    ctr++;
                }
            }
            for (int i = 0; i < prerjet.Length; i++)
            {
                queryBuilder += " tipi" + (i + 1).ToString() + "=" + (prerjet[i] == "" ? "null" : prerjet[i].Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".")) +", ";
                queryBuilderGjendja += (prerjet[i] != "" ? "" : " sasia" + (i+1).ToString() + "= null,");
            }
            queryBuilder = queryBuilder.Substring(0, queryBuilder.Length - 2);
            queryBuilderGjendja = queryBuilderGjendja.Substring(0, queryBuilderGjendja.Length - 1);

            string procedure_string = "update prerjet set " + queryBuilder + " where id_curr = " + id_curr;
            string procedure_string2 = "update gjendja set " + queryBuilderGjendja + " where id_curr = " + id_curr;

            procedure_string += ";" + procedure_string2 + ";";

            z.vektor = new string[1, 2];
            z.vektor[0, 0] = "procedure_string";
            z.vektor[0, 1] = procedure_string;
            z.ip("updatePrerje");
        }

        public void updateUser(string id, string emri, string mbiemri, string id1, string perdoruesi, string fjalekalimi, string roli)
        {
            z.vektor = new string[7, 2];
            z.vektor[0, 0] = "emri";
            z.vektor[0, 1] = emri;
            z.vektor[1, 0] = "mbiemri";
            z.vektor[1, 1] = mbiemri;
            z.vektor[2, 0] = "id1";
            z.vektor[2, 1] = id1;
            z.vektor[3, 0] = "perdoruesi";
            z.vektor[3, 1] = perdoruesi;
            z.vektor[4, 0] = "fjalekalimi";
            z.vektor[4, 1] = fjalekalimi;
            z.vektor[5, 0] = "roli";
            z.vektor[5, 1] = roli;
            z.vektor[6, 0] = "id";
            z.vektor[6, 1] = id;
            z.ip("updateUser");
        }

        #endregion


        #region PunaMeSkedar
        /*
        public DataTable MerrFoto(string nrrendor, string tabela)
        {
            b.Clear();
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "nrrendor";
            z.vektor[0, 1] = nrrendor;
            z.vektor[1, 0] = "tabela";
            z.vektor[1, 1] = tabela;
            z.sp("MerFoto", "tabela", ref b);
             return b;
        }
        public string MerrFile(string Gen)
        {
            string path = "";
            b.Clear();
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "Gen";
            z.vektor[0, 1] = Gen;
            z.vektor[1, 0] = "tabela";
            z.vektor[1, 1] = "tbl_A";
            z.sp("MerFile", "tabela", ref b);
            if (b.Rows.Count > 0)
            {
                byte[] Data = (byte[])b.Rows[0]["Skedar"];
                path = @"C:\FILE\" + (string)b.Rows[0]["Emertimi"] + (string)b.Rows[0]["Ekstensioni"];
                File.WriteAllBytes(path, Data);
                if ((string)b.Rows[0]["Ekstensioni"] != ".exe" && (string)b.Rows[0]["Ekstensioni"] != ".dll")
                {
                    System.Diagnostics.Process.Start(path);
                }
                else
                {
                    System.Diagnostics.Process.Start("explorer.exe", @"C:\FILE\");
                }
                return path;
            }
            else
            {
                return "";
            }
        }
        public DataTable EXFILE(string Gen)
        {
            b.Clear();
            z.vektor = new string[2, 2];
            z.vektor[0, 0] = "Gen";
            z.vektor[0, 1] = Gen;
            z.vektor[1, 0] = "tabela";
            z.vektor[1, 1] = "tbl_A";
            z.sp("A_EX", "tabela", ref b);
             return b;
        }
        public void UPFILE(string FILENAME, string Gen)
        {
            FileStream objFileStream = new FileStream(FILENAME, FileMode.Open);
            byte[] Data;
            Data = new byte[objFileStream.Length];
            objFileStream.Read(Data, 0, Convert.ToInt32(objFileStream.Length));
            z.b = Data;
            z.vektor = new string[4, 2];
            z.vektor[0, 0] = "Emertimi";
            z.vektor[0, 1] = System.IO.Path.GetFileName(FILENAME);
            z.vektor[1, 0] = "Ekstensioni";
            z.vektor[1, 1] = System.IO.Path.GetExtension(FILENAME);
            z.vektor[2, 0] = "Gen";
            z.vektor[2, 1] = Gen;
            z.vektor[3, 0] = "Perdorues";
            z.vektor[3, 1] = LIDHJA.id_perdorues.ToString();
            z.ip("A_U");
        }
        public void INFILE(string FILENAME, string Gen)
        {
            FileStream objFileStream = new FileStream(FILENAME, FileMode.Open);
            byte[] Data;
            Data = new byte[objFileStream.Length];
            objFileStream.Read(Data, 0, Convert.ToInt32(objFileStream.Length));
            z.b = Data;
            z.vektor = new string[4, 2];
            z.vektor[0, 0] = "Emertimi";
            z.vektor[0, 1] = System.IO.Path.GetFileName(FILENAME);
            z.vektor[1, 0] = "Ekstensioni";
            z.vektor[1, 1] = System.IO.Path.GetExtension(FILENAME);
            z.vektor[2, 0] = "Gen";
            z.vektor[2, 1] = Gen;
            z.vektor[3, 0] = "Perdorues";
            z.vektor[3, 1] = LIDHJA.id_perdorues.ToString();
            z.ip("A_I");
        }
        public void XFILE(string Gen)
        {
            z.vektor = new string[3, 2];
            z.vektor[0, 0] = "Gen";
            z.vektor[0, 1] = Gen;
            z.vektor[1, 0] = "Aktiv";
            z.vektor[1, 1] = "0";
            z.vektor[2, 0] = "Perdorues";
            z.vektor[2, 1] = LIDHJA.id_perdorues.ToString();
            z.ip("A_U");
        }
        */
        //public string INFILE(string tab, string nrrec, string filename, byte[] sked)
        //{
        //    return z.file(tab, nrrec, filename, sked);
        //}

        public DataTable ASelectFileRecord(string tabela, string rekord)
        {

            b.Clear();
            z.vektor = new string[4, 2];
            z.vektor[0, 0] = "tabela";
            z.vektor[0, 1] = tabela;
            z.vektor[1, 0] = "rekord";
            z.vektor[1, 1] = rekord;
            z.sp("ASelectFileRecord", "tabela", ref b);
             return b;

        }
        public DataTable ASelectFotoRecord(string tabela, string rekord)
        {

            b.Clear();
            z.vektor = new string[4, 2];
            z.vektor[0, 0] = "tabela";
            z.vektor[0, 1] = tabela;
            z.vektor[1, 0] = "rekord";
            z.vektor[1, 1] = rekord;
            z.sp("ASelectFotoRecord", "tabela", ref b);
             return b;

        }



        public void AInsertFileRecord(string tabela, string rekord, string emeri, string ekstension, string path,string foto = "0")
        {

            b.Clear();
            z.vektor = new string[6, 2];
            z.vektor[0, 0] = "tabela";
            z.vektor[0, 1] = tabela;
            z.vektor[1, 0] = "rekord";
            z.vektor[1, 1] = rekord;
            z.vektor[2, 0] = "emeri";
            z.vektor[2, 1] = emeri;
            z.vektor[3, 0] = "ekstension";
            z.vektor[3, 1] = ekstension;
            z.vektor[4, 0] = "path";
            z.vektor[4, 1] = path;
            z.vektor[5, 0] = "foto";
            z.vektor[5, 1] = foto;
            z.ip("AInsertFileRecord");
            

        }

        #endregion
    }

    public static class imagec
    {
        static imagec()
        {

        }
        public static System.Drawing.Image merr(byte[] b)
        {
            Image a = null;
            if (b != null)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(b);
                a = Image.FromStream(ms);
            }
            return a;
        }
        public static byte[] vendos(System.Drawing.Image b)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            b.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }


}

