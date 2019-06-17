using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAInformation.Application.Commands;
using MAInformation.Application.DataTransfer;
using MAInformation.Application.Exceptions;
using MAInformation.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAInformation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {

        private IAddDirectorCommand _addDirector;
        private IDeleteDirectorCommand _deleteDirector;
        private IUpdateDirectorCommand _updateDirector;
        private IGetDirectorCommand _getDirector;

        public DirectorController(IAddDirectorCommand addDirector, IDeleteDirectorCommand deleteDirector, IUpdateDirectorCommand updateDirector, IGetDirectorCommand getDirector)
        {
            _addDirector = addDirector;
            _deleteDirector = deleteDirector;
            _updateDirector = updateDirector;
            _getDirector = getDirector;
        }




        // GET: api/Director
        [HttpGet]
        public ActionResult Get([FromQuery] DirectorSearch search)
        {
            try
            {
               

                return Ok(_getDirector.Execute(search));
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET: api/Director/5
    /*    [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        **/
        // POST: api/Director
        [HttpPost]
        public ActionResult Post([FromBody] CreateDirectorDTO dto)
        {
            try
            {
                _addDirector.Execute(dto);
                return StatusCode(201);
            } catch(EntityNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            } catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT: api/Director/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CreateDirectorDTO dto)
        {
            dto.Id = id;


            try
            {
                _updateDirector.Execute(dto);
        return NoContent();
            }
            catch(EntityNotFoundException e)
            {
                    return UnprocessableEntity(e.Message);
            } 
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
            

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteDirector.Execute(id);
                return NoContent();
            } catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            } catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
