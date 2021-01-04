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

        void AddLink(Guid id, LinkDataModel link);
        void UpdateLink(LinkDataModel link);
        void DeleteLink(LinkDataModel link);

        bool LinkExists(Guid LinkId);
        bool Save();
    }
}
