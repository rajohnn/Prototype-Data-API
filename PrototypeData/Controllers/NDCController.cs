﻿using Microsoft.AspNetCore.Mvc;
using PrototypeData.Data;
using PrototypeData.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrototypeData.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class NDCController : ControllerBase {
        private readonly PrototypeContext _ctx;

        public NDCController(PrototypeContext ctx) {
            _ctx = ctx;
        }

        [HttpGet("{id}")]
        public async Task<List<DrugSearchResult>> Get(string id) {
            var results = new List<DrugSearchResult>();
            try {
                var repo = new PrototypeRepo(_ctx);
                results = await repo.FindByNDCAsync(id);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return results;
        }
    }
}