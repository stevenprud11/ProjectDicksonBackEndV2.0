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
    public class PriceController : Controller
    {
        private readonly IPriceQueries _priceQueries;

        public PriceController(IPriceQueries priceQueries)
        {
            _priceQueries = priceQueries;
        }

        [HttpGet()]
        [Route("api/price_under/")]
        public List<Drink> GetDrinks([FromQuery]double price)
        {
            List<Drink> drinks = _priceQueries.GetDrinkUnderPrice(price);

            return drinks;
        }

        [HttpGet()]
        [Route("api/price_between/")]
        public List<Drink> GetDrinks([FromQuery] double low,[FromQuery] double high)
        {
            List<Drink> drinks = _priceQueries.GetDrinkBetweenPrice(low, high);

            return drinks;
        }
    }
}
