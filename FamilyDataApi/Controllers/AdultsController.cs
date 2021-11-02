using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdultDataAPI.Data;
using AdultDataAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace AdultDataAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class AdultsController : ControllerBase {
        private IAdultService adultService;

        public AdultsController(IAdultService adultService) {
            this.adultService = adultService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults([FromQuery] string name) {
            try {
                IList<Adult> adults = await adultService.GetAdults();
                if (name != null) {
                    IList<Adult> adultsToShow = new List<Adult>(adults.Where(adult =>
                        adult.FirstName.Contains(name) || adult.LastName.Contains(name)));
                    return Ok(adultsToShow);
                }

                return Ok(adults);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> GetAdult([FromRoute] int id) {
            try {
                Adult adult = await adultService.Get(id);
                return Ok(adult);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id) {
            try {
                Console.WriteLine("asking to remove adult with id" + id);
                await adultService.RemoveAdult(id);
                return Ok();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddAdult([FromBody] Adult adult) {
            try {
                Console.WriteLine("httppost");
                await adultService.AddAdult(adult);
                return Ok();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}