using DMWalksAPI.Data;
using DMWalksAPI.Models.Domain;
using DMWalksAPI.Models.Domain.DTO;
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
            //get Data from Database -Domain models
            var regionsDomain = dbContext.Regions.ToList();

            //Map Domain models to DTO's
            var regionDto = new List<RegionDTO>();
            foreach (var region in regionsDomain)
            {
                regionDto.Add(new RegionDTO()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl

                });
            }

            //Return Dto's
            return Ok(regionDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult Get(int id)
        {
            //Get Region Domain Model from Database
            var regionDomain = dbContext.Regions.Find(id);
            //var Rpegion = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map region domain model to Region DTO

            var regionDto = new List<RegionDTO>();
            regionDto.Add(new RegionDTO()
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl

            });

            //Return Dto back to client
            return Ok(regionDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or convert DTO to Domain Model
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            //Use Domain Model to create Region

            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();
            // Map domain model back to DTO

            var regionDto = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl

            };

            return CreatedAtAction(nameof(Get), new { id = regionDto.Id }, regionDto);

        }

        [HttpPut]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //Check if region exists

            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Map Dto to Domain model
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionUrl;

            dbContext.SaveChanges();

            // Convert Domain model to Dto

            var regionDto = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var regionDomainModel = dbContext.Regions.FirstOrDefault(y => y.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Delete region

            dbContext.Regions.Remove(regionDomainModel);
            dbContext.SaveChanges();

            //Map domain model to DTO
            var regionDto = new RegionDTO 
            { 
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };    

            return Ok(regionDto);

        }
    }
}
