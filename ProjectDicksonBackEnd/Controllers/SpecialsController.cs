using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectDicksonBackEnd.Models;
using ProjectDicksonBackEnd.Repository;

namespace ProjectDicksonBackEnd.Controllers
{
    [Produces("application/json")]
    public class SpecialsController
    {
        private readonly ISpecialQueries _specialQueries;

        public SpecialsController(ISpecialQueries specialQueries)
        {
            _specialQueries = specialQueries;
        }

        [HttpGet()]
        [Route("api/specials")]
        public List<Special> GetSpecials()
        {
            List<Special> specials = _specialQueries.GetSpecials();

            return specials;
        }
    }
}
