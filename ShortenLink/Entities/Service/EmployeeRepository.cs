using Entities.DBContext;
using Entities.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ShortenLinkContext _context;

        public EmployeeRepository(ShortenLinkContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddEmployee(Guid RoleId, EmployeeModel emp)
        {
            if (emp == null)
                throw new ArgumentNullException(nameof(emp));
            if (RoleId == Guid.Empty)
            {
                emp.RoleId = Guid.Parse("6f6c4608-4b39-11eb-ae93-0242ac130002");
            }
            _context.Employees.Add(emp);
        }

        public bool ComparePassword(string hashedPassword, string curPassword)
        {
            var passwordVerificationResult = new PasswordHasher<object>().VerifyHashedPassword(null, hashedPassword, curPassword);
            switch (passwordVerificationResult)
            {
                case PasswordVerificationResult.Failed:
                    return false;

                case PasswordVerificationResult.Success:
                    return true;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }        

        public void DeleteEmployee(EmployeeModel emp)
        {
            if (emp == null)
            {
                throw new ArgumentNullException(nameof(emp));
            }
            _context.Employees.Remove(emp);
        }

        public bool EmpExists(Guid empId)
        {
            if (empId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(empId));
            }
            return _context.Employees.Any(emp => emp.Id == empId);
        }

        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            return _context.Employees.OrderBy(emp => emp.UserName).ToList();
        }

        public EmployeeModel GetEmployeeByEmail(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            return _context.Employees.Where(emp => emp.Email == email).FirstOrDefault();
        }

        public EmployeeModel GetEmployeeById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _context.Employees.Where(emp => emp.Id == id).FirstOrDefault();
        }

        public EmployeeModel GetEmployeeByUserName(string userName)
        {
            if (userName == null)
            {
                throw new ArgumentNullException(nameof(userName));
            }

            return _context.Employees.Where(emp => emp.UserName == userName).FirstOrDefault();
        }

        public string GetRoleNameByRoleId(Guid roleId)
        {
            if (roleId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(roleId));
            }

            RoleModel cur = _context.RoleModels.Where(role => role.Id == roleId).FirstOrDefault();
            return cur.RoleName;

        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateEmployee(EmployeeModel emp)
        {
            
        }
    }
}
