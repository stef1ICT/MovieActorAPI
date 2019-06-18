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
    public class LanguageController : ControllerBase
    {
        private IGetLanguages _getLanguage;
        private IAddLanguageCommand _addLanguage;
        private IDeleteLanguageCommand _deleteLanguage;

        public LanguageController(IGetLanguages getLanguage, IAddLanguageCommand addLanguage, IDeleteLanguageCommand deleteLanguage)
        {
            _getLanguage = getLanguage;
            _addLanguage = addLanguage;
            _deleteLanguage = deleteLanguage;
        }

        // GET: api/Language
        [HttpGet]
        public ActionResult<IEnumerable<GetLanguageDTO>> Get()
        {
            return Ok(_getLanguage.GetLanguages());
        }

        // GET: api/Language/5
      

        // POST: api/Language
        [HttpPost]
        public IActionResult Post([FromBody] CreateLanguageDTO language)
        {
                try
            {
                _addLanguage.Execute(language); 
                return StatusCode(201);
            } catch(EntityAlReadyExistException e)
            {
                return UnprocessableEntity(e.Message);
            } catch(Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Language/5
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public  ActionResult Delete(int id)
        {
            try
            {
                _deleteLanguage.Execute(id);
                return NoContent();
            }catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }catch(EntityHasRelationException e)
            {
                return StatusCode(419, e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
