using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectDicksonBackEnd.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectDicksonBackEnd.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
        private readonly ISql _sql;

        public TestController(ISql sql)
        {
            _sql = sql;
        }

        [HttpGet()]
        public string Index()
        {
            _sql.TestConnection();
            return "Success";
        }
    }
}
