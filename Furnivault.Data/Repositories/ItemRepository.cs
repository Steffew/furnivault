using Furnivault.Data.DTOs;
using System.Data.SqlClient;

namespace Furnivault.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly string _connectionString;

        public ItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ItemDTO> GetAllItems()
        {
            var items = new List<ItemDTO>();
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT ItemId, Name, Identifier, Favorite, Description, Image FROM Items";
                using (var command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
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
                    }
                }
            }
            return items;
        }
        public ItemDTO GetItemById(int itemId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT ItemId, Name, Identifier, Favorite, Description, Image FROM Items WHERE ItemId = @ItemId";
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ItemId", itemId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
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
                    }
                }
            }
            return null;
        }

        public void AddItem(ItemDTO item)
        {
        }

        public void UpdateItem(ItemDTO item)
        {
        }

        public void DeleteItem(int itemId)
        {
        }
    }
}
