using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using NationalParkDemo.Data;
using NationalParkDemo.Models;
using NationalParkDemo.Models.Dtos;
using NationalParkDemo.Repository.IRepository;

namespace NationalParkDemo.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _db;
        public NationalParkRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Add(nationalPark);

            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Remove(nationalPark);

            return Save();
        }

        public NationalPark GetNationalPark(int Id)
        {
            return _db.NationalParks.FirstOrDefault(x => x.Id.Equals(Id));
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _db.NationalParks.OrderBy(x => x.Name).ToList();
        }

        public bool NationalParkExists(string Name)
        {
            Boolean value = _db.NationalParks.Any(a => a.Name.ToLower().Trim() == Name.ToLower().Trim());
            return value;
        }

        public bool NationalParkExists(int Id)
        {
            return _db.NationalParks.Any(a => a.Id.Equals(Id));
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Update(nationalPark);

            return Save();
        }
    }
}
