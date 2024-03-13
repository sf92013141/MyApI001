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

        }

        public void Update(Employees employee)
        {

        }

        public void Delete(Employees employee)
        {

        }
    }
}
