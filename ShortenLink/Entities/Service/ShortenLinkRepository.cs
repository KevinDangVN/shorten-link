using Entities.DBContext;
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

        public void AddLink(Guid id, LinkDataModel link)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (link == null)
            {
                throw new ArgumentNullException(nameof(link));
            }
            link.Id = id;
            _context.LinkDatas.Add(link);
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

        public bool EmpWithLinkExists(Guid empId)
        {
            if (empId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(empId));
            }
            return _context.LinkDatas.Any(linkData => linkData.EmployeeId == empId);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateLink(LinkDataModel link)
        {
            throw new NotImplementedException();
        }
    }
}
