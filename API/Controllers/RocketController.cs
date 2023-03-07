using API.Models;
using API.Processors;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{

    [ApiController]
    [Route("api/v1[controller]")] //TO DO: INSERT ROUTE ONCE DB IS READY 
    public class RocketController: ControllerBase
    {
        private readonly IRocketProcessor _rocketProcessor;

        public RocketController(IRocketProcessor rocketProcessor)
        {
            _rocketProcessor = rocketProcessor ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Add a rocket
        /// </summary>
        /// <param name="rocketModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RocketModel rocketModel)
        {
            try
            {
                rocketModel.Id = String.Empty;
                await _rocketProcessor.Create(rocketModel);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all rockets
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                JsonLdParser rockets = await _rocketProcessor.GetAll();
                return Ok(rockets);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get rocket by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([Required] string id)
        {
            try
            {
                JsonLdParser rocket = await _rocketProcessor.Get(id);
                return Ok(rocket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update rocket by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rocket"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([Required] string id, [FromBody] RocketModel rocket)
        {
            try
            {
                 await _rocketProcessor.Update(id,rocket);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Delete rocket by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] string id)
        {
            try
            {
                await _rocketProcessor.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
