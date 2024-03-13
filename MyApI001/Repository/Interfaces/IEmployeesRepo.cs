using MyApI001.Models;

namespace MyApI001.Repository.Interfaces
{
    public interface IEmployeesRepo
    {
        public List<Employees> GetAll();

        public Employees GetId(int id);
        public void Create(Employees employee);


        public void Update(Employees employee);


        public void Delete(Employees employee);
 
    }
}
