using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Gizmox.WebGUI.Forms.VisualEffects;

namespace CRMMobileDemo
{
    public class LIDHJA : IDisposable
    {
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

        private string connectionString;//stringa lidhjes me databazen
        public static int id_perdorues = 0;//variabel per identifikimin e id se perdoruesit
        public LIDHJA(/*string constring*/)
        {
            connectionString = "Data Source=" + OSIRISLIDHJA.INSTC + ";" +
                "Initial Catalog=" + OSIRISLIDHJA.BAZA + ";" +
                "Persist Security Info=True;" +
                "User ID=" + OSIRISLIDHJA.USQL + ";" +
                "Password=" + OSIRISLIDHJA.PSQL + ";";
        }//konstruktori
        //public string[] v1;
        //public string[] v2;
        public string[,] vektor;
        public byte[] b = null;
        //internal void vector_transform()
        //{
        //    vektor = new string[v1.Length, 2];
        //    for (int i = 0; i < v1.Length; i++)
        //    {
        //        vektor[i, 0] = v1[i];
        //        vektor[i, 1] = v2[i];
        //    }

        //}

        public string sp(string procedureString, string tabela, ref DataTable products)
        {
            //vector_transform();
            try
            {
                using (SqlConnection mySqlConnection = new SqlConnection(connectionString))//nderto dhe perdor objektin sqlconnection
                {
                    try
                    {
                        using (SqlCommand mySqlCommand = mySqlConnection.CreateCommand())//nderto dhe per mysqlcommand
                        {
                            mySqlCommand.CommandText = procedureString;
                            mySqlCommand.CommandType = CommandType.StoredProcedure;


                            // cikel per shtimin e parametrave
                            try
                            {
                                if (vektor.Length > 0)
                                {
                                    for (int i = 0; i < vektor.Length / 2; i++)
                                    {
                                        if (vektor[i, 0] != null && vektor[i, 1] != null && vektor[i, 1] != "")
                                        {
                                            mySqlCommand.Parameters.AddWithValue(vektor[i, 0], vektor[i, 1]);
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                return "Nuk mund te shtohen parametrat e procedures!!! " + ex.Message.ToString();
                            }
                            //cikel per shtimin e parametrave
                            try
                            {
                                mySqlConnection.Open();//tento hapjen e lidhjes
                            }
                            catch (Exception ex)
                            {
                                return "Nuk mund te lidhet me bazen e te dhenave!!! " + ex.Message.ToString();

                            }
                            try
                            {
                                //mySqlCommand.ExecuteNonQuery();//tento ekzekutimin e storeprocedure
                            }
                            catch (Exception ex)
                            {
                                return "Store Procedure ne Server nuk mund te ekzekutohet!!! " + ex.Message.ToString();

                            }
                            using (SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter())//nderto dhe perdor sqldataadapter
                            {
                                mySqlDataAdapter.SelectCommand = mySqlCommand;
                                try
                                {
                                    using (DataSet myDataSet = new DataSet())//nderto dhe perdor dataset
                                    {
                                        try
                                        {
                                            mySqlDataAdapter.Fill(myDataSet, tabela);//tento te mbushesh datasetin
                                        }
                                        catch (Exception ex)
                                        {
                                            return "Te dhenat nuk mund te trasferohen!!! " + ex.Message.ToString();
                                        }
                                        try
                                        {
                                            products = myDataSet.Tables[tabela];
                                            mySqlConnection.Close();
                                            return "";

                                        }
                                        catch (Exception ex)
                                        {
                                            return "Probleme me trasferimin e te dhenave ose me mbylljen e seksionit!!! " + ex.Message.ToString();
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    return "Probleme me ndertimin e DataSet!!! " + ex.Message.ToString();

                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return "Probleme me ndertimin e komandes SQL!!! " + ex.Message.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                return "Probleme me ndertimin e Connection String!!! " + ex.Message.ToString();
            }
        }//END OF SP

        public string ip(string procedureString)
        {
            //vector_transform();
            try
            {
                using (SqlConnection mySqlConnection = new SqlConnection(connectionString))//nderto dhe perdor objektin sqlconnection
                {
                    try
                    {
                        using (SqlCommand mySqlCommand = mySqlConnection.CreateCommand())//nderto dhe per mysqlcommand
                        {
                            mySqlCommand.CommandText = procedureString;
                            mySqlCommand.CommandType = CommandType.StoredProcedure;

                            // cikel per shtimin e parametrave

                            if (vektor.Length > 0)
                            {
                                for (int i = 0; i < vektor.Length / 2; i++)
                                {
                                    if (vektor[i, 0] != null && vektor[i, 1] != null)
                                    {
                                        mySqlCommand.Parameters.AddWithValue(vektor[i, 0], vektor[i, 1]);
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                            if (b != null) //shtimi nese ka foto
                            {
                                if (procedureString == "A_I" || procedureString == "A_U")
                                {
                                    mySqlCommand.Parameters.AddWithValue("@Skedar", b);
                                }
                                else
                                {
                                    mySqlCommand.Parameters.AddWithValue("@FOTO", b);
                                }

                            }
                            //mySqlCommand.Parameters.AddWithValue("@Perdorues", id_perdorues.ToString());
                            //hiq komentin me lart per shtimin e perdoruesve
                            //cikel per shtimin e parametrave
                            try
                            {
                                mySqlConnection.Open();//tento hapjen e lidhjes
                            }
                            catch (Exception ex)
                            {
                                return "Nuk mund te lidhet me bazen e te dhenave!!! " + ex.Message.ToString();
                            }
                            try
                            {
                                mySqlCommand.ExecuteNonQuery();//tento ekzekutimin e storeprocedure
                                return "";
                            }
                            catch (Exception ex)
                            {
                                return ex.Message;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return "Probleme me ndertimin e komandes SQL!!! " + ex.Message.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Probleme me ndertimin e Connection String!!! " + ex.Message.ToString();
            }
        }//END OF IP
  
        
    }//END OF CLASS

    static class OSIRISLIDHJA
    {
        public static string PSQL = PasSql();
        public static string USQL = UsernameSql();
        public static string INSTC = Instanca();
        public static string BAZA = Baza();
        public static string SERIALI = Seriali();
        public static string INIPATH = Inipath();

        private static string Inipath()
        {
            string ret = "";
            ret = ConfigurationManager.AppSettings["INIPATH"];
            if (ret == null)
                ret = "";
            return ret;
        }
        private static string Seriali()
        {
            string ret = "";
            ret = ConfigurationManager.AppSettings["SERIALI"];
            if (ret == null)
                ret = "";
            return ret;
        }
        private static string Instanca()
        {
            string ret = "";
            ret = ConfigurationManager.AppSettings["INSTANCA"];
            if (ret == null)
                ret = "";
            return ret;
        }
        private static string Baza()
        {
            string ret = "";
            ret = ConfigurationManager.AppSettings["BAZA"];
            if (ret == null)
                ret = "";
            return ret;
        }

        private static string PasSql()
        {
            string ret = "";
            ret = ConfigurationManager.AppSettings["PSQL"];
            if (ret == null)
                ret = "";
            return ret;
        }
        private static string UsernameSql()
        {
            string ret = "";
            ret = ConfigurationManager.AppSettings["USQL"];
            if (ret == null)
                ret = "";
            return ret;
        }
        public static byte[] GetPhoto(string filePath)
        {
            if (File.Exists(filePath))
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] photo = br.ReadBytes((int)fs.Length);

                br.Close();
                fs.Close();

                return photo;
            }
            else
            {
                FileStream fs = new FileStream("na.bmp", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] photo = br.ReadBytes((int)fs.Length);

                br.Close();
                fs.Close();

                return photo;
            }

        }

    }
}//END OF NAMESPACE
