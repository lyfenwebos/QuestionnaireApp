using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO.IsolatedStorage;

namespace QuestionannaireApp
{
    public class LicenseCheck
    {
        private static bool Activated { get; set; }
        public static string myConnectionString = String.Empty;

        public static bool isActivated(string key)
        {
            MySqlConnection myconn = new MySqlConnection(myConnectionString);
            MySqlCommand cmd;
            myconn.Open();
            try
            {
                cmd = myconn.CreateCommand();
                cmd.CommandText = "SELECT activated FROM activationTable WHERE serialKey =@key";
                cmd.Parameters.AddWithValue("@key", key);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result > 0)
                {
                    return true;
                }
                return false;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (myconn.State == System.Data.ConnectionState.Open)
                {
                    myconn.Close();
                }
            }


        }
        public static void activateSoftware(string key)
        {
            if (!isActivated(key))
            {
                MySqlConnection myconn = new MySqlConnection(myConnectionString);
                MySqlCommand cmd;
                myconn.Open();
                try
                {
                    cmd = myconn.CreateCommand();
                    cmd.CommandText = "SELECT Count(*) FROM activationTable WHERE serialKey =@key";
                    cmd.Parameters.AddWithValue("@key", key);
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result > 0)
                    {
                        updateActivation(key);
                        using (IsolatedStorageFile isolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
                        {
                            using (IsolatedStorageFileStream isolatedStorageFileStream = new IsolatedStorageFileStream("license.lic", System.IO.FileMode.CreateNew, isolatedStorageFile))
                            {
                                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(isolatedStorageFileStream))
                                {
                                    sw.WriteLine(key);
                                }
                            }
                        }
                        Activated = true;
                    }
                    else
                    {
                        MessageBox.Show("Your key was incorrect");
                        Activated = false;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (myconn.State == System.Data.ConnectionState.Open)
                    {
                        myconn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Your software is already activated!");
                Activated = true;
            }
        }
        
        private static void updateActivation(string key)
        {
            MySqlConnection myconn = new MySqlConnection(myConnectionString);
            MySqlCommand cmd;
            myconn.Open();
            try
            {
                cmd = myconn.CreateCommand();
                cmd.CommandText= "UPDATE activationTable SET activated = 1 WHERE serialKey =@key";
                cmd.Parameters.AddWithValue("@key", key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Activated!");
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                if (myconn.State == System.Data.ConnectionState.Open)
                {
                    myconn.Close();
                }
            }
            
        }
    }
}
