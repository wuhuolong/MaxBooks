using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mono.Data.Sqlite;

namespace EncryptSqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 2)
            {
                string strFilePath = args[0];
                string password = args[1];
                try
                {
                    Console.WriteLine("Begin to encrypt sqlite file: " + strFilePath);

                    SqliteConnection dbConnection = new SqliteConnection("URI=file:" + strFilePath);
                    dbConnection.Open();
                    dbConnection.ChangePassword(password);
                    dbConnection.Dispose();
                    dbConnection.Close();

                    Console.WriteLine("Encrypt sqlite file success!!!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            else
            {
                Console.WriteLine("Error in EncryptSqliteTool, args length is wrong!!!");
            }
        }
    }
}
