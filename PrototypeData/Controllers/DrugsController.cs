using Microsoft.AspNetCore.Mvc;
using PrototypeData.Data;
using PrototypeData.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrototypeData.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DrugsController : ControllerBase {
        private readonly PrototypeContext _ctx;

        public DrugsController(PrototypeContext ctx) {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<List<string>> Get() {
            var results = new List<string>();            
            try {
                var repo = new PrototypeRepo(_ctx);
                results = await repo.GetDrugNamesAsync();
            }
            catch(Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
            }          
            return results;
        }

        [HttpGet("{name}")]
        public async Task<List<DrugSearchResult>> Get(string name) {
            var results = new List<DrugSearchResult>();
            try {
                var repo = new PrototypeRepo(_ctx);
                results = await repo.FindByNameAsync(name);
            }
            catch(Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return results;
        }
    }
}