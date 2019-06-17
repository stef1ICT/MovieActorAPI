using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAInformation.Application.Commands;
using MAInformation.Application.DataTransfer;
using MAInformation.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAInformation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private IGetGenderCommand _getGender;
        private IDeleteGenderCommand _deleteGender;
        private ICreateGenderCommand _addGender;

        public GenderController(IGetGenderCommand getGender, IDeleteGenderCommand deleteGender, ICreateGenderCommand addGender)
        {
            _getGender = getGender;
            _deleteGender = deleteGender;
            _addGender = addGender;
        }

        // GET: api/Gender
        [HttpGet]
        public ActionResult<IEnumerable<GetGenderDTO>> Get()
        {
            return Ok(_getGender.getGenders());
        }

       

        // POST: api/Gender
        [HttpPost]
        public ActionResult Post([FromBody] CreateGenderDTO dto)
        {
            try
            {
                _addGender.Execute(dto);
                return StatusCode(201);
            }catch(EntityAlReadyExistException e)
            {
                return UnprocessableEntity(e.Message);
            } catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Gender/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteGender.Execute(id);
                return NoContent();
            } catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            } catch(EntityHasRelationException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
