using System;
using System.Collections.Generic;
using ProjectDicksonBackEnd.Models;
using ProjectDicksonBackEnd.Repository;

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
            return OrderByCurrentDay(list);

            
        }



        public List<Special> OrderByCurrentDay(List<Special> list)
        {
            foreach (Special s in list)
                s.setDayOfWeekOrder();
            list.Sort();

            return list;
        }
    }
}
