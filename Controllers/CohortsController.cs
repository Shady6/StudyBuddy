using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stud_bud_back.Entities;
using stud_bud_back.Helpers;
using stud_bud_back.Models.Cohort;
using stud_bud_back.Services;

namespace stud_bud_back.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CohortsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ICohortService _cohortService;

        public CohortsController(DataContext context, IMapper mapper, IUserService userService, ICohortService cohortService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _cohortService = cohortService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cohort>>> GetCohorts()
        {
            return await _context.Cohorts.ToListAsync();
        }

        // GET: api/Cohorts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cohort>> GetCohort(int id)
        {
            var cohort = await _context.Cohorts.FindAsync(id);

            if (cohort == null)
            {
                return NotFound();
            }

            return cohort;
        }

        // PUT: api/Cohorts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCohort(int id, Cohort cohort)
        {
            if (id != cohort.Id)
            {
                return BadRequest();
            }

            _context.Entry(cohort).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CohortExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cohorts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cohort>> PostCohort([FromBody] CohortCreationModel cohort)
        {
            var cohortEntity = _mapper.Map<Cohort>(cohort);

            _cohortService.Create(cohortEntity);

            return Ok();
        }

        // DELETE: api/Cohorts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cohort>> DeleteCohort(int id)
        {
            var cohort = await _context.Cohorts.FindAsync(id);
            if (cohort == null)
            {
                return NotFound();
            }

            _context.Cohorts.Remove(cohort);
            await _context.SaveChangesAsync();

            return cohort;
        }

        private bool CohortExists(int id)
        {
            return _context.Cohorts.Any(e => e.Id == id);
        }
    }
}
