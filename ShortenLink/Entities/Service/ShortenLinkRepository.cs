﻿using Entities.DBContext;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Service
{
    public class ShortenLinkRepository : IShortenLinkRepository
    {
        private readonly ShortenLinkContext _context;

        public ShortenLinkRepository(ShortenLinkContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddLink(Guid empId, LinkDataModel link)
        {
            if (empId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(empId));
            }
            if (link == null)
            {
                throw new ArgumentNullException(nameof(link));
            }
            link.EmployeeId = empId;
            _context.LinkDatas.Add(link);
        }

        public int CountAllClick()
        {
            return _context.LinkDatas.Sum(c => c.Count);
        }

        public void DeleteLink(LinkDataModel link)
        {
            if (link == null)
            {
                throw new ArgumentNullException(nameof(link));
            }
            _context.LinkDatas.Remove(link);
        }

        public IEnumerable<LinkDataModel> GetAllLink()
        {
            return _context.LinkDatas.ToList();
        }

        public IEnumerable<LinkDataModel> GetAllLinkByEmployeeId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _context.LinkDatas.Where(linkData => linkData.EmployeeId == id).OrderBy(link => link.ShortLink).ToList();
        }

        public LinkDataModel GetLinkByLinkId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _context.LinkDatas.Where(linkData => linkData.Id == id).FirstOrDefault();
        }

        public LinkDataModel GetLinkByShortLink(string shortLink)
        {
            if (shortLink == null)
            {
                throw new ArgumentNullException(nameof(shortLink));
            }
            return _context.LinkDatas.Where(linkData => linkData.ShortLink == shortLink).FirstOrDefault();
        }

        public LinkDataModel GetLinkByEmpIdLinkId(Guid empId, Guid linkId)
        {
            if (empId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(empId));
            }
            if (linkId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(linkId));
            }

            return _context.LinkDatas.Where(linkData => linkData.EmployeeId == empId && linkData.Id == linkId).FirstOrDefault();

        }

        public bool EmpExists(Guid empId)
        {
            if (empId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(empId));
            }
            return _context.Employees.Any(emp => emp.Id == empId);
        }

        public bool LinkExists(Guid linkId)
        {
            if (linkId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(linkId));
            }
            return _context.LinkDatas.Any(linkData => linkData.Id == linkId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateLink(LinkDataModel link)
        {
            
        }

       
    }
}
