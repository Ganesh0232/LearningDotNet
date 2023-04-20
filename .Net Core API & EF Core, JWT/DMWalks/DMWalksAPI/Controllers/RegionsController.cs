using DMWalksAPI.Data;
using DMWalksAPI.Models.Domain;
using DMWalksAPI.Models.Domain.DTO;
using DMWalksAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DMWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly DMWalksDbContext dbContext;
        private readonly IRegionRepo regionRepo;

        public RegionsController(DMWalksDbContext dbContext, IRegionRepo regionRepo)
        {
            this.dbContext = dbContext;
            this.regionRepo = regionRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //get Data from Database -Domain models
            //  var regionsDomain = await dbContext.Regions.ToListAsync();
            var regionDomain = await regionRepo.GetAllAsync();

            //Map Domain models to DTO's
            var regionDto = new List<RegionDTO>();
            foreach (var region in regionDomain)
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
        public async Task<IActionResult> Get(Guid id)
        {
            //Get Region Domain Model from Database
            //  var regionDomain =await dbContext.Regions.FindAsync(id);
            //var Rpegion = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            //Calling from repository

            var regionDomain = await regionRepo.GetByIdAsync(id);
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
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or convert DTO to Domain Model
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            //Use Domain Model to create Region

            // await dbContext.Regions.AddAsync(regionDomainModel);
            regionDomainModel = await regionRepo.CreateAsync(regionDomainModel);
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
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //Map DTO to DomainModel
            var regionDomainModel = new Region
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageUrl = updateRegionRequestDto.RegionUrl
            };

            //Check if region exists

            //  var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
             regionDomainModel = await regionRepo.UpdateAsync(id, regionDomainModel );

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
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepo.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Delete region

            //dbContext.Regions.Remove(regionDomainModel);
            //await dbContext.SaveChangesAsync();

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
