using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PostgresTest.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly EpraContext _ctx;

        public CompanyController(EpraContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<Company[]>GetCompanies()
        {
            var result = await _ctx.companies.Include(c => c.CompanyType).ToArrayAsync();
            return result;
        }
    }
}
