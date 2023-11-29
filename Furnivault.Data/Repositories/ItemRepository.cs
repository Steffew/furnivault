using System.Data.SqlClient;
using Furnivault.Core.Interfaces;
using Furnivault.Data.DTOs;

namespace Furnivault.Data.Repositories
{
    public class ItemRepository : IRepository<ItemDTO>
    {
        private readonly string _connectionString;

        public ItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ItemDTO> GetAll()
        {
            var items = new List<ItemDTO>();
            using SqlConnection connection = new(_connectionString);

            string sql = "SELECT ItemId, Name, Identifier, Favorite, Description, Image FROM Items";
            using var command = new SqlCommand(sql, connection);
            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                items.Add(new ItemDTO
                {
                    ItemId = reader.GetInt32(reader.GetOrdinal("ItemId")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Identifier = reader.IsDBNull(reader.GetOrdinal("Identifier")) ? null : reader.GetString(reader.GetOrdinal("Identifier")),
                    Favorite = reader.GetBoolean(reader.GetOrdinal("Favorite")),
                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                    Image = reader.IsDBNull(reader.GetOrdinal("Image")) ? null : (byte[])reader["Image"]
                });
            }

            return items;
        }

        public ItemDTO GetById(int itemId)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT ItemId, Name, Identifier, Favorite, Description, Image FROM Items WHERE ItemId = @ItemId";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ItemId", itemId);
            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new ItemDTO
                {
                    ItemId = reader.GetInt32(reader.GetOrdinal("ItemId")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Identifier = reader.IsDBNull(reader.GetOrdinal("Identifier")) ? null : reader.GetString(reader.GetOrdinal("Identifier")),
                    Favorite = reader.GetBoolean(reader.GetOrdinal("Favorite")),
                    Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                    Image = reader.IsDBNull(reader.GetOrdinal("Image")) ? null : (byte[])reader["Image"]
                };
            }
            return null;
        }

        public void Add(ItemDTO item)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "INSERT INTO Items (Name, Identifier, Description) VALUES (@Name, @Identifier, @Description)";
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Identifier", item.Identifier ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Description", item.Description ?? (object)DBNull.Value);
            //command.Parameters.AddWithValue("@Favorite", item.Favorite);
            //command.Parameters.AddWithValue("@Image", item.Image ?? (object)DBNull.Value);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Update(ItemDTO item)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "UPDATE Items SET Name = @Name, Identifier = @Identifier, Favorite = @Favorite, Description = @Description, Image = @Image WHERE ItemId = @ItemId";
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Identifier", item.Identifier ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Favorite", item.Favorite);
            command.Parameters.AddWithValue("@Description", item.Description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Image", item.Image ?? (object)DBNull.Value);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Delete(int itemId)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "DELETE FROM Items WHERE ItemId = @ItemId";

            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@ItemId", itemId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}