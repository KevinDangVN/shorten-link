using Entities.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Service
{
    class EmployeeRepository
    {
        private readonly ShortenLinkContext _context;

        public EmployeeRepository(ShortenLinkContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
