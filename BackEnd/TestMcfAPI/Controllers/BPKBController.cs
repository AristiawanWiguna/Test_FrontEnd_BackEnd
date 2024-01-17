using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestMcfAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BPKBController : ControllerBase
    {
        private readonly DataContext _context;

        public BPKBController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<BPKB>>> Get()
        {
            return Ok(await _context.tr_Bpkb.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BPKB>> Get(int id)
        {
            var bpkb = await _context.tr_Bpkb.FindAsync(id);
            if (bpkb == null)
                return BadRequest("BPKB not found.");

            return Ok(bpkb);
        }

        [HttpPost]
        public async Task<ActionResult<List<BPKB>>> AddBPKB(BPKB bpkb)
        {   
            _context.tr_Bpkb.Add(bpkb);
            await _context.SaveChangesAsync();

            return Ok(await _context.tr_Bpkb.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<BPKB>>> UpdateBPKB(BPKB request)
        {
            var bpkb = await _context.tr_Bpkb.FindAsync(request.ID);
            if (bpkb == null)
                return BadRequest("BPKB not found.");

            bpkb.agreement_number = request.agreement_number;
            bpkb.bpkb_no = request.bpkb_no;
            bpkb.branch_id = request.branch_id;
            bpkb.bpkb_date = request.bpkb_date;
            bpkb.faktur_no = request.faktur_no;
            bpkb.faktur_date = request.faktur_date;
            bpkb.location_id = request.location_id;
            bpkb.police_no = request.police_no;
            bpkb.bpkb_date_in = request.bpkb_date_in;
            bpkb.created_by = request.created_by;
            bpkb.created_on = request.created_on;
            bpkb.last_updated_by = request.last_updated_by;
            bpkb.last_updated_on = request.last_updated_on;

            await _context.SaveChangesAsync();

            return Ok(await _context.tr_Bpkb.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<BPKB>>> Delete(int id)
        {
            var bpkb = await _context.tr_Bpkb.FindAsync(id);
            if (bpkb == null)
                return BadRequest("BPKB not found.");

            _context.tr_Bpkb.Remove(bpkb);
            await _context.SaveChangesAsync();

            return Ok(await _context.tr_Bpkb.ToListAsync());
        }
    }
}
