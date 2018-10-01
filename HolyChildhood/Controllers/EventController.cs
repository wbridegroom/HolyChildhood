using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolyChildhood.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HolyChildhood.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly AppDbContext dbContext;

        public EventController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return dbContext.Events.OrderBy(e => e.BeginDate).ToList();
        }
    }
}