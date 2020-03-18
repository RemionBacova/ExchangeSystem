using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace Exchange
{
    class dbconnection
    {
        #region declarative_section

        OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\dtb.mde;Jet OLEDB:Database Password=1L0v3Acce55;");

        #endregion
        
        public dbconnection()
        {

        }

        #region select_queries

        public DataTable selectAllRecFromTable(string table)
        {
            return getQuery("Select * From " + table);
        }//ok

        public DataTable selectDenomValueByCurrency(string id_cur)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("id_cur", id_cur)
            };

            string query = "Select id, min_denom from min_denom where id_cur = @id_cur";
            return getQuery(query, prm);
        }//ok

        public DataTable selectUserDataById(string id)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("id", id)
            };
            string query = "select * from users where id = @id";
            return getQuery(query, prm);
        }//ok

        public DataTable selectUsers()
        {
            string query = "select id, Emri + ' ' + Mbiemri as Emri, Roli from Users";
            return getQuery(query);
        }//ok

        public DataTable getBlerjeShitjeMonedhe(string monedha_id)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("monedha_id", monedha_id)
            };

            string query = "select blerje, shitje from arka where id_curr = @monedha_id";
            return getQuery(query, prm);
        }//ok

        public DataTable getMinDenomByCurrency(string id_cur)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("id_cur", id_cur)
            };
            string query = "select min_denom from min_denom where id_cur = @id_cur";
            return getQuery(query, prm);
        }//ok

        public DataTable selectPrerjet(string monedha_id)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("monedha_id", monedha_id)
            };

            string query = "select * from prerjet where id_curr = @monedha_id";
            return getQuery(query, prm);
        }//ok

        public DataTable selectGjendjet(string monedha_id, string arka_id)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("monedha_id", monedha_id),
                new OleDbParameter("arka_id", arka_id)
            };

            string query = "select * from gjendja where id_curr = @monedha_id and id_ark = @arka_id";
            return getQuery(query, prm);
        }//ok

        public DataTable getKursiBankesByMonedha(string monedha_id)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("monedha_id", monedha_id)
            };

            string query = "select shitje from banka where id_curr = @monedha_id";
            return getQuery(query, prm);
        }//ok

        public DataTable getUserInfoByUsernamePassword(string username, string password)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("username", username),
                new OleDbParameter("password", password)
            };

            string query = "select * from users where perdoruesi = @username and fjalkalimi = @password";
            return getQuery(query, prm);
        }//ok

        public DataTable getQuerySimple(string query)
        {
            return getQuery(query);
        }//not SQL procedure

        public DataTable getQuerySimpleParametric(string query, OleDbParameter[] prm)
        {
            return getQuery(query, prm);
        }//not SQL procedure

        public DataTable selectFavoriteCurrencies()
        {
            return getQuery("select * From monedhat where favorite = true");
        }//ok

        public DataTable selectArkatByUser(string user_id)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("user_id", user_id)
            };
            string query = "select arkat.* from user_arka inner join arkat on user_arka.arka_id = arkat.id where user_arka.user_id = @user_id";
            return getQuery(query, prm);
        }//ok

        public DataTable selectRecordByUserArka(string user_id, string arka_id)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("user_id", user_id),
                new OleDbParameter("arka_id", arka_id)
            };
            string query = "select count(*) from user_arka where user_id = @user_id and arka_id = @arka_id";
            return getQuery(query, prm);
        }//ok

        #endregion

        #region insert/update_queries

        public void insertArka(string monedha_id, string shitje, string blerje)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("monedha_id", monedha_id),
                new OleDbParameter("shitje", shitje),
                new OleDbParameter("blerje", blerje)
            };

            string query = "insert into arka(id_curr, shitje, blerje) values (@monedha_id, @shitje, @blerje)";
            getQuery(query, prm);
        }//ok

        public void insertBanka(string monedha_id, string shitje, string blerje)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("monedha_id", monedha_id),
                new OleDbParameter("shitje", shitje),
                new OleDbParameter("blerje", blerje)
            };

            string query = "insert into banka(id_curr, shitje, blerje) values(@monedha_id, @shitje, @blerje)";
            getQuery(query, prm);
        }//ok

        public void updateArka(string id, string shitje, string blerje)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("blerje", blerje),
                new OleDbParameter("shitje", shitje),
                new OleDbParameter("id", id)
            };

            string query = "update arka set Blerje = @blerje, Shitje = @shitje where id = @id";
            getQuery(query, prm);
        }//ok

        public void updateBanka(string id, string shitje, string blerje)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("blerje", blerje),
                new OleDbParameter("shitje", shitje),
                new OleDbParameter("id", id)
            };

            string query = "update banka set Blerje = @blerje, Shitje = @shitje where id = @id";
            getQuery(query, prm);
        }//ok

        public void insertMonedha(string emertimi, bool isChecked)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("emertimi", emertimi),
                new OleDbParameter("isChecked", isChecked)
            };

            string query = "insert into monedhat (Monedha, favorite) values (@emertimi, @isChecked)";
            getQuery(query, prm);
        }//ok

        public void updateMonedha(string id, string emertimi, bool isChecked)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("emertimi", emertimi),
                new OleDbParameter("isChecked", isChecked),
                new OleDbParameter("id", id)
            };

            string query = "update monedhat set [Monedha] = @emertimi, favorite = @isChecked where id = @id ";
            getQuery(query, prm);
        }//ok

        public void insertArkat(string emertimi)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("emertimi", emertimi)
            };

            string query = "insert into arkat (Arka) values (@emertimi)";
            getQuery(query, prm);
        }//ok

        public void updateArkat(string id, string emertimi)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("emertimi", emertimi),
                new OleDbParameter("id", id)
            };

            string query = "update arkat set [Arka] = @emertimi where id = @id ";
            getQuery(query, prm);
        }//ok

        public void deleteFromTable(string id, string table)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("id", id)
            };

            string query = "delete from "+table+" where id = @id";
            getQuery(query, prm);
        }//ok

        public void insertMinimalDenomination(string id_cur, string min_denom)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("id_cur", id_cur),
                new OleDbParameter("min_denom", min_denom)
            };
            string query = "insert into min_denom (id_cur, min_denom) values (@id_cur, @min_denom)";
            getQuery(query, prm);
        }//ok

        public void updateMinimalDenomination(string id, string min_denom)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("min_denom", min_denom),
                new OleDbParameter("id", id)
            };
            string query = "update min_denom set min_denom = @min_denom where id = @id";
            getQuery(query, prm);
        }//ok

        public void insertUser(string emri, string mbiemri, string id, string perdoruesi, string fjalekalimi, string roli)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("emri", emri),
                new OleDbParameter("mbiemri", mbiemri),
                new OleDbParameter("ID", id),
                new OleDbParameter("perdoruesi", perdoruesi),
                new OleDbParameter("fjalekalimi", fjalekalimi),
                new OleDbParameter("roli", roli)
            };
            string query = "insert into Users (Emri, Mbiemri, ID_, Perdoruesi, Fjalkalimi, Roli) values (@emri, @mbiemri, @ID, @perdoruesi, @fjalekalimi, @roli)";
            getQuery(query, prm);
        }//ok

        public void updateUser(string id, string emri, string mbiemri, string id1, string perdoruesi, string fjalekalimi, string roli)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("emri", emri),
                new OleDbParameter("mbiemri", mbiemri),
                new OleDbParameter("id1", id1),
                new OleDbParameter("perdoruesi", perdoruesi),
                new OleDbParameter("fjalekalimi", fjalekalimi),
                new OleDbParameter("roli", roli),
                new OleDbParameter("id", id)
            };
            string query = "update users set emri = @emri, mbiemri = @mbiemri, ID_ = @id1, perdoruesi = @perdoruesi, fjalkalimi = @fjalekalimi, roli = @roli where id = @id";
            getQuery(query, prm);
        }//ok

        public void insertTransaction(string id_user, DateTime Dita, DateTime Ora, string Tipi1, string Sasia1, string Tipi2, string Sasia2, string id_arka, string Blerje_shitje,
            string Emri_i_Klientit, string Kursi)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("id_user", id_user),
                new OleDbParameter("Dita", Dita),
                new OleDbParameter("Ora", Ora),
                new OleDbParameter("Tipi1", Tipi1),
                new OleDbParameter("Sasia1", Sasia1.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".")),
                new OleDbParameter("Tipi2", Tipi2),
                new OleDbParameter("Sasia2", Sasia2.Replace(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".")),
                new OleDbParameter("id_arka", id_arka),
                new OleDbParameter("Blerje_Shitje", Blerje_shitje),
                new OleDbParameter("Emri_i_Klientit", Emri_i_Klientit),
                new OleDbParameter("Kursi", Kursi),
                new OleDbParameter("Aktiv", true)
            };

            string query = "insert into Transaksione(id_user, Dita, Ora, Tipi1, Sasia1, Tipi2, Sasia2, id_arka, Blerje_shitje, Emri_i_Klientit, Kursi, Aktiv) " +
                "values(@id_user, @Dita, @Ora, @Tipi1, @Sasia1, @Tipi2, @Sasia2, @id_arka, @Blerje_shitje, @Emri_i_Klientit, @Kursi, @Aktiv)";
            getQuery(query, prm);
        }//ok

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

            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("arka_id", arka_id),
                new OleDbParameter("id_curr", id_curr)
            };
            string query = "insert into gjendja(id_ark, id_curr, " + queryBuilder1 + ") values (@id_ark, @id_curr, " + queryBuilder2 + ")";
            getQuery(query, prm);
        }//keep in class

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
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("id_curr", id_curr),
                new OleDbParameter("arka_id", arka_id)
            };
            string query = "update gjendja set " + queryBuilder + " where id_curr = @id_curr and id_ark = @arka_id";
            getQuery(query, prm);
        }//keep in class

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
                queryBuilder2 += prerjet[i] + ", ";
            }
            queryBuilder = queryBuilder.Substring(0, queryBuilder.Length - 2);
            queryBuilder2 = queryBuilder2.Substring(0, queryBuilder2.Length - 2);

            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("id_curr", id_curr)
            };
            string query = "insert into prerjet(id_curr, " + queryBuilder + " ) values (@id_curr, " + queryBuilder2 + ")";
            getQuery(query, prm);
        }//keep in class
        
        public void updatePrerje(string id_curr, string[] prerjet)
        {
            string queryBuilder = "";
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
                queryBuilder += " tipi" + (i + 1).ToString() + "=" + prerjet[i] + ", ";
            }
            queryBuilder = queryBuilder.Substring(0, queryBuilder.Length - 2);

            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("id_curr", id_curr)
            };
            string query = "update prerjet set " + queryBuilder + " where id_curr = @id_curr";
            getQuery(query, prm);
        }//keep in class

        public void insertUserArka(string user_id, string arka_id)
        {
            OleDbParameter[] prm = new OleDbParameter[]
            {
                new OleDbParameter("user_id", user_id),
                new OleDbParameter("arka_id", arka_id)
            };
            string query = "insert into user_arka(user_id, arka_id) values (@user_id, @arka_id)";
            getQuery(query, prm);
        }//ok

        #endregion


        public DataTable getQuery(string query, OleDbParameter[] prm)
        {
            OleDbCommand odc = new OleDbCommand(query, cn);
            for (int i = 0; i < prm.Length; i++)
            {
                odc.Parameters.Add(prm[i]);
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter(odc);
           
            cn.Open();
            DataTable resultSet = new DataTable();
            adapter.Fill(resultSet);
            cn.Close();
            return resultSet;
        }

        public DataTable getQuery(string query)
        {
            OleDbCommand odc = new OleDbCommand(query, cn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(odc);
            
            cn.Open();
            DataTable resultSet = new DataTable();
            adapter.Fill(resultSet);
            cn.Close();
            return resultSet;
        }
    }
}
