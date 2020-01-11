using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ChemicalsOverview.Controllers.Data;
using ChemicalsOverview.Controllers.Infrastracture;
using Microsoft.AspNetCore.Mvc;

namespace ChemicalsOverview.Controllers.api
{
    [Route("api/[controller]")]
    public class ChemicalsController : Controller
    {
        private readonly DbRepository _context;

        public ChemicalsController(DbRepository context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var retrieveSheetTask = new RetrieveSafetySheet(_context);

            return File(retrieveSheetTask.ExecuteAsync(id).Result, "application/octet-stream");
        }
        
    }
}
