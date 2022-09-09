using ACS.AppDBContext;
using ACS.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ACS.Helpers
{
    public class SearchHelpers
    {
        private readonly AppDbContext _context;
        public SearchHelpers(AppDbContext context)
        {
            _context = context;
        }

        //public IEnumerable GetAll(string? search = "", string? IsActive = "")
        //{
        //    var _data = _context.RoomAllotment
        //        .Include(x => x.Party)
        //        .Where(x => (search == null || search == "") || x.Party.PartyName.Contains(search) || x.RoomNo.Contains(search));

        //    if (IsActive != "")
        //    {
        //        _data = _data.Where(x => x.IsActive);
        //    }

        //    return _data.Select(x => new RoomAllotmentView
        //    {

        //        PartyID = x.PartyID,
        //        PartyName = x.Party.PartyName,
        //        RoomNo = x.RoomNo,
        //        MonthlyRent = x.MonthlyRent,
        //        StartDate = x.StartDate,

        //    })
        //        .ToArray();

        //}
    }
}
