using Microsoft.Data.SqlClient;
using Vaskebjørnen.Models;
using Microsoft.Extensions.Configuration;

namespace Vaskebjørnen.Repositories
{
    public class ResidentRepo : IRepo<Resident>
    {
        private readonly string _connectionString;
        
        public ResidentRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("myDb1");
        }

        public void Add(Resident t)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                //Her laves insert statement ligesom du ville gøre det i Management Studio, men med en lille forskel
                //@ repræsentere et parameter, som først indsættes senere (SQL injection angreb)
                string sql = "INSERT INTO Residents (AppNr, Name, Password) " +
                             "VALUES (@AppNr, @Name, @Password)";

                //Vi skal sende en kommando til databasen
                SqlCommand command = new SqlCommand(sql, connection);
                //Her bytter vi parametrene ud
                command.Parameters.AddWithValue("@AppNr", t.AppartmentNumber);
                command.Parameters.AddWithValue("@Name", t.Name);
                command.Parameters.AddWithValue("@Password", t.Password);
                //Her udfører vi kommandoen og eftersom vi ikke skal have
                //noget tilbage så bruger vi ExecuteNonQuery
                command.ExecuteNonQuery(); // Udfører INSERT-operationen
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close(); // Lukker forbindelsen manuelt
            }
        }

        public void Delete(Resident t)
        {
            throw new NotImplementedException();
        }

        public List<Resident> GetAll()
        {
            // Opret en liste til at holde alle Residents
            // Denne liste returneres når vi er færdige
            List<Resident> residents = new List<Resident>();

            // Opret forbindelse til databasen
            SqlConnection connection = new SqlConnection(_connectionString);

            try
            {
                // Åbn forbindelsen
                // Vi skal altid have en åben forbindelse til databasen - det er et must
                connection.Open();

                // SQL-forespørgsel for at hente alle Residents
                string sql = "SELECT * FROM Residents";

                //En SqlCommand er et objekt i ADO.NET, der bruges til at udføre SQL-forespørgsler
                //Vi kan intet foretage os uden en command
                SqlCommand command = new SqlCommand(sql, connection);

                // Kør forespørgslen og hent data ved hjælp af SqlDataReader
                // En SqlDataReader er et objekt i ADO.NET, der bruges til at læse data fra en
                // SQL-forespørgsel, én række ad gangen, i fremadgående retning. 
                SqlDataReader reader = command.ExecuteReader();

                // Læs resultaterne
                // Der er en markør i reader, som hele tiden holder styr på hvilken record
                // vi har læst og vi stopper løkken efter sidste element
                while (reader.Read())
                {
                    // Opret et Resident-objekt og fyld det med data fra databasen
                    // Bemærk at det er her vi "mapper" datatyper fra SQL til C#
                    // (0) fortæller at der er tale om første attribut osv.
                    // Hvis man ændrer i rækkefølgen skal disse også ændres
                    
                    Resident r = new Resident(reader.GetString(0), reader.GetString(1), reader.GetString(2));

                    // Tilføj beboeren til listen
                    residents.Add(r);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally //Bemærk at denne blok altid bliver afviklet
            {
                // Luk forbindelsen manuelt
                // VI SKAL ALTID LUKKE FORBINDELSEN
                connection.Close();
            }

            // Returner listen af beboere
            return residents;
        }

        public Resident GetBy(Resident t)
        {
            throw new NotImplementedException();
        }

        public void Update(Resident t)
        {
            throw new NotImplementedException();
        }
    }
}
