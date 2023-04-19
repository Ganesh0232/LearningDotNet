using DMWalksAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DMWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly DMWalksDbContext dbContext;

        public RegionsController(DMWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = dbContext.Regions.ToList();
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult Get(int id)
        {
            var region =dbContext.Regions.Find(id);
            //var Rpegion = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);
        }
    }
}
