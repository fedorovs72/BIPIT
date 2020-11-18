using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace server
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        String connectionString = "Data Source=serega123.mssql.somee.com;Initial Catalog=serega123;User Id=iren418827_SQLLogin_1;Password=697w6xerz1";

        public void DoWork()
        {
        }

        public void ConnectionInfo(string name, string port, string localPath, string uri, string scheme)
        {
            Console.WriteLine();
            Console.WriteLine("***** Host Info *****");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Port: {port}");
            Console.WriteLine($"LocalPath: {localPath}");
            Console.WriteLine($"Uri: {uri}");
            Console.WriteLine($"Scheme: {scheme}");
            Console.WriteLine("***********************************");
            Console.WriteLine();
        }

        public void CountOfDBRows(string count) =>
            Console.WriteLine($"Количество записей в БД: {count}");

        public string InsertMethod(string id_exp, string id_h, string date, string autor_order)
        {
            var connect = new SqlConnection(connectionString);
            connect.Open();
            var query = $"INSERT INTO [transfers] VALUES ({id_exp},{id_h},'{date}','{autor_order}')";
            SqlCommand command = connect.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            connect.Close();
            return "Готово";
        }

        public DataTable GetData()
        {
            var query = "SELECT [transfers].id_tr, [transfers].id_exp_fk, [expanate].name_exp, [transfers].id_h_fk, [hall].name_h, [transfers].date, [transfers].autor_order " +
                        "FROM [transfers] " +
                        "INNER JOIN [hall] ON [hall].id_h = [transfers].id_h_fk " +
                        "INNER JOIN [expanate] ON [expanate].id_exp = [transfers].id_exp_fk";
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "transfers";
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }


        public string RecCheck(string id_exp, string id_h, string date, string autor_order)
        {
            string query = $"SELECT COUNT(1) FROM [transfers] WHERE [transfers].id_exp_fk = {id_exp} AND [transfers].id_h_fk = {id_h} AND [transfers].date = '{date}' AND [transfers].autor_order='{autor_order}'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "transfers";
                            sda.Fill(dt);
                            return dt.Rows[0][0].ToString();
                        }
                    }
                }
            }
        }

        public DataTable GetExpSelectData()
        {
            string query = "SELECT * FROM expanate";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "expanate";
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public DataTable GetHallSelectData()
        {
            string query = "SELECT * FROM hall";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "hall";
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
    }
}
