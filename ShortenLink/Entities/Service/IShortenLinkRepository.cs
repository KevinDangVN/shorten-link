using Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Service
{
    public interface IShortenLinkRepository
    {
        IEnumerable<LinkDataModel> GetAllLink();
        IEnumerable<LinkDataModel> GetAllLinkByEmployeeId(Guid id);
        LinkDataModel GetLinkByLinkId(Guid id);
        LinkDataModel GetLinkByShortLink(string shortLink);
        LinkDataModel GetLinkByEmpIdLinkId(Guid empId, Guid linkId);
        int CountAllClick();

        void AddLink(Guid id, LinkDataModel link);
        void UpdateLink(LinkDataModel link);
        void DeleteLink(LinkDataModel link);

        bool EmpExists(Guid empId);
        bool LinkExists(Guid linkId);
        bool Save();
    }
}
