using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeApp.Data;
using ResumeApp.Data.Interfaces;
using ResumeApp.Data.Dtos;
using AutoMapper;
using ResumeApp.Data.Models;

namespace ResumeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreesController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IDegreeService _service;
        private readonly IMapper _mapper;

        public DegreesController(AppDBContext context, IDegreeService service, IMapper mapper)
        {
            _context = context;
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Degrees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DegreeDto>>> GetDegree()
        {
            var allDegrees = await _service.GetAllDegrees();
            return Ok(allDegrees);
            //return await _context.Degree.ToListAsync();
        }

        // GET: api/Degrees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DegreeDto>> GetDegree(int id)
        {
            var Degree = await _context.degree.FindAsync(id);
            DegreeDto response = _mapper.Map<DegreeDto>(Degree);

            if (Degree == null)
            {
                return NotFound();
            }

            return response;
        }

        // PUT: api/Degrees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDegree(int id, DegreeDto Degree)
        {
            if (id != Degree.Id)
            {
                return BadRequest();
            }
            var entity = _mapper.Map<Degree>(Degree);
            await _service.UpdateDegree(entity.Id, entity);

            return NoContent();
        }

        // POST: api/Degrees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DegreeDto>> PostDegree(DegreeDto Degree)
        {
            var entity = _mapper.Map<Degree>(Degree);
            await _service.AddDegree(entity);
            return Ok(Degree);
        }

        // DELETE: api/Degrees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDegree(int id)
        {
            bool success = await _service.DeleteDegree(id);

            if (!success)
            {
               return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Degrees/
        [HttpDelete]
        public async Task<IActionResult> DeleteAllUnusedDegrees()
        {
            bool success = await _service.DeleteAllUnusedDegrees();

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
