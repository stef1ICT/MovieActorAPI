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
    public class GenreController : ControllerBase
    {
        private IAddGenreCommand _addGenre;
        private IDeleteGenreCommand _deleteGenre;
        private IUpdateGenreCommand _updateGenre;
        private IGetGenreCommand _getGenre;

        public GenreController(IAddGenreCommand addGenre, IDeleteGenreCommand deleteGenre, IUpdateGenreCommand updateGenre, IGetGenreCommand getGenre)
        {
            _addGenre = addGenre;
            _deleteGenre = deleteGenre;
            _updateGenre = updateGenre;
            _getGenre = getGenre;
        }



        // GET: api/Genre
        [HttpGet]
        public ActionResult<IEnumerable<GetGenreDTO>> Get([FromQuery] GenreSearch search)
        {
            try
            {

                return Ok(_getGenre.Execute(search));
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET: api/Genre/5
        

        // POST: api/Genre
        [HttpPost]
        public ActionResult Post([FromBody] CreateGenreDTO dto)
        {

            try
            {

                _addGenre.Execute(dto);
                return StatusCode(201);
            } catch(EntityAlReadyExistException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT: api/Genre/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CreateGenreDTO dto)
        {
            try
            {
                dto.Id = id;
                _updateGenre.Execute(dto);
                return NoContent();
            } catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            } catch(EntityAlReadyExistException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch(Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteGenre.Execute(id);
                return NoContent();
            } catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);

            } catch(GenreHasMoviesException e)
            {
                return UnprocessableEntity(e.Message);
            } catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
