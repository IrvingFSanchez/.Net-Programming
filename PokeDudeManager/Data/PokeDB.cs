using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using PokeDudeManager.Models;

namespace PokeDudemanager.Data
{
    public class PokeDB : IDisposable
    {
        private SqlConnection _connection;
        private SqlCommand? _command;

        public PokeDB(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open(); // "Connect to the PokeDudeServer"
        }

        // Add a pokedude (Discover a new pokedude)
        public void AddDude(PokeDude pokeDude)
        {
            string query = "INSERT INTO PokeDudes (Name, Type, [Gender], Location, DiscoveryDate) " +
            "VALUES (@name, @type, @gend, @loc, @date)";
            using (_command = new SqlCommand(query, _connection))
            {
                _command.Parameters.AddWithValue("@name", pokeDude.Name);
                _command.Parameters.AddWithValue("@type", pokeDude.Type);
                _command.Parameters.AddWithValue("@gend", pokeDude.Gender);
                _command.Parameters.AddWithValue("@loc", pokeDude.Location);
                _command.Parameters.AddWithValue("@date", pokeDude.DiscoveryDate);
                _command.ExecuteNonQuery();
            }
        }

        // Get all pokedudes (Explore pokedudes)
        public List<PokeDude> GetAllPokeDudes()
        {
            List<PokeDude> pokeDudes = new List<PokeDude>();
            string query = "SELECT PokeDudeID, Name, Type, [Gender], Location, DiscoveryDate FROM PokeDudes";
            using (_command = new SqlCommand(query, _connection))
            using (SqlDataReader reader = _command.ExecuteReader())
            {
                while (reader.Read())
                {
                    PokeDude pokedude = new PokeDude
                    {
                        PokeDudeID = (int)reader["PokeDudeID"],
                        Name = reader["Name"]?.ToString() ?? string.Empty,
                        Type = reader["Type"]?.ToString() ?? string.Empty,
                        Gender = reader["Gender"]?.ToString() ?? string.Empty,
                        Location = reader["Location"]?.ToString() ?? string.Empty,
                        DiscoveryDate = (DateTime)reader["DiscoveryDate"]
                    };

                    pokeDudes.Add(pokedude);
                }
            }
            return pokeDudes;
        }

        // Update a pokedude (Re-describe a pokedude)
        public bool UpdatePokeDude(int id, PokeDude updatedPokeDude)
        {
            string query = "UPDATE PokeDudes SET Name = @name, Type = @type, [Gender] = @gend, " +
            "Location = @loc, DiscoveryDate = @date WHERE PokeDudeID = @id";
            using (_command = new SqlCommand(query, _connection))
            {
                _command.Parameters.AddWithValue("@name", updatedPokeDude.Name);
                _command.Parameters.AddWithValue("@type", updatedPokeDude.Type);
                _command.Parameters.AddWithValue("@gend", updatedPokeDude.Gender);
                _command.Parameters.AddWithValue("@loc", updatedPokeDude.Location);
                _command.Parameters.AddWithValue("@date", updatedPokeDude.DiscoveryDate);
                _command.Parameters.AddWithValue("@id", id);
                return _command.ExecuteNonQuery() > 0;
            }
        }

        // Release a pokedude into the wild "Similar to the pokemon games where you release your pokemon"
        public bool ReleasePokeDude(int id)
        {
            string query = "DELETE FROM PokeDudes WHERE PokeDudeID = @id";
            using (_command = new SqlCommand(query, _connection))
            {
                _command.Parameters.AddWithValue("@id", id);
                return _command.ExecuteNonQuery() > 0;
            }
        }

        // Release all pokedudes (Reset the PokeDudeServer)
        public void ReleaseAllPokeDudes()
        {
            string query = "DELETE FROM PokeDudes";
            using (_command = new SqlCommand(query, _connection))
            {
                _command.ExecuteNonQuery();
            }
        }

        // Cleanup
        public void Dispose()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
