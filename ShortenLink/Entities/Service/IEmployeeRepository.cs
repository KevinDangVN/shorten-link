using Entities.DTO;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Service
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeWithRoleNameDTO> GetAllEmployee();
        EmployeeModel GetEmployeeById(Guid id);
        EmployeeModel GetEmployeeByEmail(string email);
        EmployeeModel GetEmployeeByUserName(string userName);
        IEnumerable<RoleModel> GetRoleId();

        string GetRoleNameByRoleId(Guid roleId);

        void AddEmployee(Guid RoleId, EmployeeModel emp);
        void UpdateEmployee(EmployeeModel emp);
        void DeleteEmployee(EmployeeModel link);

        bool EmpExists(Guid id);
        bool ComparePassword(string hashedPassword, string curPassword);
        bool Save();
    }
}
