using Microsoft.Data.SqlClient;
using MVCWithRazor.Interfaces;
using MVCWithRazor.Models;
using System.Data;

namespace MVCWithRazor.Repository
{
    public class DepartmentRepo : IDepartment
    {
        private readonly string _connectionString;

        public DepartmentRepo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("con");
        }

        public async Task<List<Department>> GetAll()
        {
            var departments = new List<Department>();

            try
            {
                using (var connection = await GetConnectionAsync())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "GetAllDepartments";

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var department = new Department
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name"))
                                };
                                departments.Add(department);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception message
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }

            return departments;
        }

        private async Task<SqlConnection> GetConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
