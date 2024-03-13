using MyApI001.Models;

namespace MyApI001.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<Employees>> GetAll();

        public Task<Employees> GetId(int id);
        public  Task Create(Employees entity);

        public  Task Update(Employees entity);

        public  Task Delete(Employees entity);
    }
}
