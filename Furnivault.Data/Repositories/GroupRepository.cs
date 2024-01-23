using System.Data.SqlClient;
using Furnivault.Core.Entities;
using Furnivault.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Furnivault.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly string _connectionString;

        public GroupRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection") ?? throw new NullReferenceException("Connection string is null");
        }

        public IEnumerable<Group> GetAll()
        {
            var groups = new List<Group>();
            using var connection = new SqlConnection(_connectionString);
            const string sql = "SELECT Id, Name FROM Groups";
            using var command = new SqlCommand(sql, connection);
            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var group = new Group(
                    reader.GetString(reader.GetOrdinal("Name"))
                );
                group.SetGroupId(reader.GetInt32(reader.GetOrdinal("Id")));
                groups.Add(group);
            }

            return groups;
        }

        public Group GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT Id, Name FROM Groups WHERE Id = @Id";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                var group = new Group(
                    reader.GetString(reader.GetOrdinal("Name"))
                );
                group.SetGroupId(reader.GetInt32(reader.GetOrdinal("Id")));
                return group;
            }
            return null;
        }

        public void Add(Group group)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "INSERT INTO Groups (Name) OUTPUT INSERTED.Id VALUES (@Name)";
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Name", group.Name);

            connection.Open();
            var newId = (int)command.ExecuteScalar();
            group.SetGroupId(newId);
        }

        public void Update(int id, string name)
        {
            using var connection = new SqlConnection(_connectionString);
            const string sql = "UPDATE Groups SET Name = @Name WHERE Id = @Id";
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Name", name);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            const string sql = "DELETE FROM Groups WHERE Id = @Id";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
