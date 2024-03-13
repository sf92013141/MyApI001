using MyApI001.Models;
using MyApI001.Repository.Interfaces;
using MyApI001.Services.Interfaces;
using System.Data.SqlClient;

namespace MyApI001.Services.Service
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeesRepo _employeeRepo;
        public EmployeeService(IEmployeesRepo employeeRepo) {
            _employeeRepo = employeeRepo;
        }

        public async Task<List<Employees>> GetAll()
        {
            return _employeeRepo.GetAll();
        }
        public async Task<Employees> GetId(int id)
        {
            return _employeeRepo.GetId(id);
        }
        public async Task  Create(Employees entity)
        {
            _employeeRepo.Create(entity);
        }

        public async Task Update(Employees entity)
        {
            _employeeRepo.Update(entity);
        }

        public async Task Delete(Employees entity)
        {
            _employeeRepo.Delete(entity);
        }
    }
}
