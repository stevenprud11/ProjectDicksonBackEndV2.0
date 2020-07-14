using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectDicksonBackEnd.Models;
using ProjectDicksonBackEnd.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectDicksonBackEnd.Controllers
{
    [Produces("application/json")]
    public class DrinkController : Controller
    {
        private readonly IDrinkQueries _drinkQueries;

        public DrinkController(IDrinkQueries drinkQueries)
        {
            _drinkQueries = drinkQueries;
        }

        [HttpGet()]
        [Route("api/drinks")]
        public List<Drink> GetDrinks()
        {
            List<Drink> drinks = _drinkQueries.GetDrinks();

            return drinks;
        }

        [HttpGet()]
        [Route("api/drink_search/")]
        public List<Drink> GetDrinks([FromQuery] string drinkName)
        {
            List<Drink> drinks = _drinkQueries.GetDrinks(drinkName);

            return drinks;
        }

    }
}
