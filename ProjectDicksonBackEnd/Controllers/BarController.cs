using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectDicksonBackEnd.Models;
using ProjectDicksonBackEnd.Repository;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectDicksonBackEnd.Controllers
{
    
    [Produces("application/json")]
    public class BarController : Controller
    {
        private readonly IBarQueries _barQueries;

        public BarController(IBarQueries barQueries)
        {
            _barQueries = barQueries;
        }

        //get list of all bars
        [HttpGet()]
        [Route("api/bars")]
        public List<Bar> GetBars()
        {
            List<Bar> bars = _barQueries.GetBars();

            return bars;
        }

        //get list of bars by name
        [HttpGet()]
        [Route("api/bar_search/")]
        public List<Bar> SearchBarName([FromQuery] string barName)
        {
            List<Bar> bars = _barQueries.GetBars(barName);

            return bars;
        }

        //get list of bars by location
        [HttpGet()]
        [Route("api/bar_location/")]
        public List<Bar> SearchBarLocation([FromQuery] string location)
        {
            List<Bar> bars = _barQueries.SearchBarLocation(location);

            return bars;
        }
    }
}
