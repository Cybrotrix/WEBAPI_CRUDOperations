using System.Collections.Generic;

namespace WEBAPI_CRUDOperations.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int ID);
        Employee Insert(Employee item);
        bool Delete(int ID);
        bool Update(Employee item);
    }
}