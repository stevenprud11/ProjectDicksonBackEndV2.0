using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectDicksonBackEnd.Controllers
{
    [ApiController]
    [Route("api/about")]
    public class About : ControllerBase
    {
        [HttpGet()]
        public string Index()
        {
            return "Project Dickson V2.0. I am starting Project Dickson over now that I have more experience in software development.\n" +
                " During my intenships my knowledge and skills in programming have evolved and the original version of Project Dickson\n " +
                "has too many flaws to continue. Here I will apply my new skills and knowledge to publish Project Dickson V2.0 utilizing\n" +
                "a .NET Core backend to connect to my Postgres Database. This will be put into a container and published to the cloud.";
        }
    }
}
