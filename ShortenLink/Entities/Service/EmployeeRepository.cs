﻿using Entities.DBContext;
using Entities.Model;
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

        public EmployeeModel GetEmployeeById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _context.Employees.Where(emp => emp.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateEmployee(EmployeeModel emp)
        {
            throw new NotImplementedException();
        }
    }
}
