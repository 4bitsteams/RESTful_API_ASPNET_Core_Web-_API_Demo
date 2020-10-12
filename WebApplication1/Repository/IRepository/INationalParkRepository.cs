using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NationalParkDemo.Models;
using NationalParkDemo.Models.Dtos;

namespace NationalParkDemo.Repository.IRepository
{
    public interface INationalParkRepository
    {
        public ICollection<NationalPark> GetNationalParks();
        NationalPark GetNationalPark(int Id);

        Boolean NationalParkExists(String Name);
        Boolean NationalParkExists(int Id);
        Boolean CreateNationalPark(NationalPark nationalPark);
        Boolean UpdateNationalPark(NationalPark nationalPark);
        Boolean DeleteNationalPark(NationalPark nationalPark);
        Boolean Save();

    }
}
