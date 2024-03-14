using MyApI001.Models;
using MyApI001.Repository.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyApI001.Repository.Repo
{
    public class EmployeesRepo : IEmployeesRepo
    {
        public EmployeesRepo() { }

        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\Data\northwind.mdf"";Integrated Security=True;Connect Timeout=30";
        public List<Employees> GetAll()
        {

            var res = new List<Employees>();
            using (var connection = new SqlConnection(connectionString))
            {
                var sqlstr = @"SELECT [EmployeeID]
      ,[LastName]
      ,[FirstName]
      ,[Title]
      ,[TitleOfCourtesy]
      ,[BirthDate]
      ,[HireDate]
      ,[Address]
      ,[City]
      ,[Region]
      ,[PostalCode]
      ,[Country]
      ,[HomePhone]
      ,[Extension]
      ,[Photo]
      ,[Notes]
      ,[ReportsTo]
      ,[PhotoPath]
  FROM [Employees]";
                var command = new SqlCommand(sqlstr, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res.Add(new Employees
                        {
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            LastName = reader["LastName"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            Title = reader["Title"].ToString(),
                            TitleOfCourtesy = reader["TitleOfCourtesy"].ToString(),
                            BirthDate = reader["BirthDate"] as DateTime?,
                            HireDate = reader["HireDate"] as DateTime?,
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            Region = reader["Region"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            Country = reader["Country"].ToString(),
                            HomePhone = reader["HomePhone"].ToString(),
                            Extension = reader["Extension"].ToString(),
                            Photo = reader["Photo"] as byte[],
                            Notes = reader["Notes"].ToString(),
                            ReportsTo = reader.IsDBNull(reader.GetOrdinal("ReportsTo")) ? null : (int?)reader["ReportsTo"],
                            PhotoPath = reader["PhotoPath"].ToString()
                        });
                    }
                }
            }
            return res;
        }

        public Employees GetId(int id)
        {

            Employees res = null;

            using (var connection = new SqlConnection(connectionString))
            {
                var sqlstr = @"SELECT [EmployeeID]
      ,[LastName]
      ,[FirstName]
      ,[Title]
      ,[TitleOfCourtesy]
      ,[BirthDate]
      ,[HireDate]
      ,[Address]
      ,[City]
      ,[Region]
      ,[PostalCode]
      ,[Country]
      ,[HomePhone]
      ,[Extension]
      ,[Photo]
      ,[Notes]
      ,[ReportsTo]
      ,[PhotoPath]
  FROM [Employees] where EmployeeID=@EmployeeID";

                using (var command = new SqlCommand(sqlstr, connection))
                {
                    command.Parameters.Add(new SqlParameter("@EmployeeID", id));
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            res = new Employees
                            {
                                EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                Title = reader["Title"].ToString(),
                                TitleOfCourtesy = reader["TitleOfCourtesy"].ToString(),
                                BirthDate = reader["BirthDate"] as DateTime?,
                                HireDate = reader["HireDate"] as DateTime?,
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                Region = reader["Region"].ToString(),
                                PostalCode = reader["PostalCode"].ToString(),
                                Country = reader["Country"].ToString(),
                                HomePhone = reader["HomePhone"].ToString(),
                                Extension = reader["Extension"].ToString(),
                                Photo = reader["Photo"] as byte[],
                                Notes = reader["Notes"].ToString(),
                                ReportsTo = reader.IsDBNull(reader.GetOrdinal("ReportsTo")) ? null : (int?)reader["ReportsTo"],
                                PhotoPath = reader["PhotoPath"].ToString()
                            };
                        }
                    }
                }
            }
            return res;
        }
        public void Create(Employees employee)
        {
          
            using (var connection = new SqlConnection(connectionString))
            {
                var sqlstr = @"INSERT INTO [Employees] 
            ([LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], 
            [HireDate], [Address], [City], [Region], [PostalCode], [Country], 
            [HomePhone], [Extension], [Photo], [Notes], [ReportsTo], [PhotoPath])
            VALUES 
            (@LastName, @FirstName, @Title, @TitleOfCourtesy, @BirthDate, 
            @HireDate, @Address, @City, @Region, @PostalCode, @Country, 
            @HomePhone, @Extension, @Photo, @Notes, @ReportsTo, @PhotoPath)";

                using (var command = new SqlCommand(sqlstr, connection))
                {
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@Title", employee.Title ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@TitleOfCourtesy", employee.TitleOfCourtesy ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@BirthDate", employee.BirthDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@HireDate", employee.HireDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Address", employee.Address ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@City", employee.City ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Region", employee.Region ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PostalCode", employee.PostalCode ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Country", employee.Country ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@HomePhone", employee.HomePhone ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Extension", employee.Extension ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Photo", employee.Photo ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Notes", employee.Notes ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ReportsTo", employee.ReportsTo ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PhotoPath", employee.PhotoPath ?? (object)DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public void Update(Employees employee)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sqlstr = @"UPDATE [Employees] SET 
            [LastName] = @LastName, 
            [FirstName] = @FirstName, 
            [Title] = @Title, 
            [TitleOfCourtesy] = @TitleOfCourtesy, 
            [BirthDate] = @BirthDate, 
            [HireDate] = @HireDate, 
            [Address] = @Address, 
            [City] = @City, 
            [Region] = @Region, 
            [PostalCode] = @PostalCode, 
            [Country] = @Country, 
            [HomePhone] = @HomePhone, 
            [Extension] = @Extension, 
            [Photo] = @Photo, 
            [Notes] = @Notes, 
            [ReportsTo] = @ReportsTo, 
            [PhotoPath] = @PhotoPath
            WHERE [EmployeeID] = @EmployeeID";

                using (var command = new SqlCommand(sqlstr, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                    command.Parameters.AddWithValue("@LastName", employee.LastName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Title", employee.Title ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@TitleOfCourtesy", employee.TitleOfCourtesy ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@BirthDate", employee.BirthDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@HireDate", employee.HireDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Address", employee.Address ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@City", employee.City ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Region", employee.Region ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PostalCode", employee.PostalCode ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Country", employee.Country ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@HomePhone", employee.HomePhone ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Extension", employee.Extension ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Photo", (employee.Photo != null && employee.Photo.Length > 0) ? (object)employee.Photo : DBNull.Value);
                    command.Parameters.AddWithValue("@Notes", employee.Notes ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ReportsTo", employee.ReportsTo ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PhotoPath", employee.PhotoPath ?? (object)DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sqlstr = @"DELETE FROM [Employees] WHERE [EmployeeID] = @EmployeeID";

                using (var command = new SqlCommand(sqlstr, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeID", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
