using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Service
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeModel> GetAllEmployee();
        EmployeeModel GetEmployeeById(Guid id);

        void AddEmployee(Guid id, EmployeeModel emp);
        void UpdateEmployee(EmployeeModel emp);
        void DeleteEmployee(EmployeeModel link);

        bool EmpExists(Guid id);
        bool Save();
    }
}
