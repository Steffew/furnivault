using System.Collections.Generic;
using System.Data.SqlClient;
using Furnivault.Core.Interfaces;
using Furnivault.Core.Entities;

namespace Furnivault.Data.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private readonly string _connectionString;

        public ItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Item> GetAll()
        {
            var items = new List<Item>();
            using var connection = new SqlConnection(_connectionString);
            const string sql = "SELECT ItemId, Name, Identifier, Favorite, Description FROM Items";
            using var command = new SqlCommand(sql, connection);
            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var item = new Item(
                    reader.GetString(reader.GetOrdinal("Name")),
                    reader.GetString(reader.GetOrdinal("Identifier")),
                    reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                    reader.GetBoolean(reader.GetOrdinal("Favorite"))
                );
                items.Add(item);
            }

            return items;
        }

        public Item GetById(int itemId)
        {
            using var connection = new SqlConnection(_connectionString);
            const string sql = "SELECT ItemId, Name, Identifier, Favorite, Description FROM Items WHERE ItemId = @ItemId";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ItemId", itemId);
            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Item(
                    reader.GetString(reader.GetOrdinal("Name")),
                    reader.GetString(reader.GetOrdinal("Identifier")),
                    reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                    reader.GetBoolean(reader.GetOrdinal("Favorite"))
                );
            }
            return null;
        }

        public void Add(Item item)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "INSERT INTO Items (Name, Identifier, Description) OUTPUT INSERTED.ItemId VALUES (@Name, @Identifier, @Description)";
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Identifier", item.Identifier ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Description", item.Description ?? (object)DBNull.Value);

            connection.Open();

            var newId = (int)command.ExecuteScalar();
            item.SetItemId(newId);
        }


        public void Update(Item item)
        {
            using var connection = new SqlConnection(_connectionString);
            const string sql = "UPDATE Items SET Name = @Name, Identifier = @Identifier, Description = @Description, Favorite = @Favorite WHERE ItemId = @ItemId";
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@ItemId", item.ItemId);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Identifier", item.Identifier ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Description", item.Description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Favorite", item.Favorite);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Delete(int itemId)
        {
            using var connection = new SqlConnection(_connectionString);
            const string sql = "DELETE FROM Items WHERE ItemId = @ItemId";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ItemId", itemId);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}