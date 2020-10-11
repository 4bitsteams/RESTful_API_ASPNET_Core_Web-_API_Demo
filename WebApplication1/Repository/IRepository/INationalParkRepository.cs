using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NationalParkDemo.Models;

namespace NationalParkDemo.Repository.IRepository
{
    public interface INationalParkRepository
    {
        public ICollection<NationalParkDto> GetNationalParks();
        NationalParkDto GetNationalPark(int Id);

        Boolean NationalParkExists(String Name);
        Boolean NationalParkExists(int Id);
        Boolean CreateNationalParkExists(NationalParkDto nationalPark);
        Boolean UpdateNationalParkExists(NationalParkDto nationalPark);
        Boolean DeleteNationalParkExists(NationalParkDto nationalPark);
        Boolean Save();

    }
}
