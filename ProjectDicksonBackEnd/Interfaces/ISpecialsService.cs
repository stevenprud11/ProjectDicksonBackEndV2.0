using System.Collections.Generic;
using ProjectDicksonBackEnd.Models;

namespace ProjectDicksonBackEnd.Services
{
    public interface ISpecialsService
    {
        List<Special> GetList();
        List<Special> OrderByCurrentDay(List<Special> list);
    }
}