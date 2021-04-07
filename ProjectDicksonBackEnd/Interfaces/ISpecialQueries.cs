using System.Collections.Generic;
using ProjectDicksonBackEnd.Models;

namespace ProjectDicksonBackEnd.Repository
{
    public interface ISpecialQueries
    {
        List<Special> GetSpecials();
    }
}