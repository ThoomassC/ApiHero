using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.SqlClient;
using ApiHero.Models;

namespace Animal.Models
{
    public class BDD: Hero
    {
        public BDD(string name, string power) : base(name, power)
        { }

        public void ConnectionDataBase()
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Hero;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection.Open();
                Console.WriteLine("La connexion à la base de données a réussi.");

                Console.WriteLine("Etat : " + connection.State);

                string insert = $"INSERT INTO TableHero (name, power) VALUES ('{Name}', '{Power}')";
                SqlCommand insertCommand = new SqlCommand(insert, connection);
                insertCommand.ExecuteNonQuery();

                string select = "SELECT * FROM TableHero";
                SqlCommand selectCommand = new SqlCommand(select, connection);
                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["Name"] + " " + reader["Power"]);
                }

                int rowsAffected = insertCommand.ExecuteNonQuery();
                Console.WriteLine("{0} ligne(s) insérée(s).", rowsAffected);

                reader.Close();
                connection.Close();
                Console.WriteLine("Etat : " + connection.State);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la connexion à la base de données : " + ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connexion fermée.");
            }
        }
    }
}