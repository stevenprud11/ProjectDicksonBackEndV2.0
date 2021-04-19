using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectDicksonBackEnd.Models;
using ProjectDicksonBackEnd.Services;

namespace ProjectDicksonBackEnd.Controllers
{
    [Produces("application/json")]
    public class SpecialsController
    {
        private readonly ISpecialsService _specialsService;

        public SpecialsController(ISpecialsService specialsService)
        {
            _specialsService = specialsService;
        }

        [HttpGet()]
        [Route("api/specials")]
        public List<Special> GetSpecials()
        {
            List<Special> specials = _specialsService.GetList();

            return specials;
        }
    }
}
