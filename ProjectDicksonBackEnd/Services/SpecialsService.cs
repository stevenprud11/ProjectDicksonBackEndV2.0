using System;
using System.Collections.Generic;
using ProjectDicksonBackEnd.Models;
using ProjectDicksonBackEnd.Repository;
using System.Linq;

namespace ProjectDicksonBackEnd.Services
{
    public class SpecialsService : ISpecialsService
    {
        private readonly ISpecialQueries _specialsQueries;

        public SpecialsService(ISpecialQueries specialQueries)
        {
            _specialsQueries = specialQueries;
        }

        public List<Special> GetList()
        {
            List<Special> list = _specialsQueries.GetSpecials();
            foreach (Special s in list)
                s.setDayOfWeekOrder();

            List<Special> sorted = list.OrderBy(x => x.DayofWeek).ThenBy(x => x.BarName).ThenBy(x => x.Price).ToList();

            return sorted;
            
        }

        public List<Special> GetListByBar(string barname)
        {
            List<Special> list = _specialsQueries.GetSpecialsByBar(barname);
            foreach (Special s in list)
                s.setDayOfWeekOrder();

            List<Special> sorted = list.OrderBy(x => x.DayofWeek).ThenBy(x => x.Price).ToList();

            return sorted;
        }
    }
}
