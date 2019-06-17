using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAInformation.Application.Commands;
using MAInformation.Application.DataTransfer;
using MAInformation.Application.Exceptions;
using MAInformation.Application.Responses;
using MAInformation.Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAInformation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IAddMovieCommand _addMovie;
        private IDeleteMovieCommand _deleteMovie;
        private IUpdateMovieCommand _updateMovie;
        private IGetMovieCommand _getMovies;

        public MovieController(IAddMovieCommand addMovie, IDeleteMovieCommand deleteMovie, IUpdateMovieCommand updateMovie, IGetMovieCommand getMovies)
        {
            _addMovie = addMovie;
            _deleteMovie = deleteMovie;
            _updateMovie = updateMovie;
            _getMovies = getMovies;
        }



        // GET: api/Movie
        [HttpGet]
        public ActionResult<PagedResponse<GetMovieDTO>> Get([FromQuery] MovieSearch search)
        {
            try
            {
               
                return Ok(_getMovies.Execute(search));
            } catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        

        // POST: api/Movie
        [HttpPost]
        public ActionResult Post([FromBody] CreateMovieDTO dto)
        {

            try
            {
                _addMovie.Execute(dto);
                return StatusCode(201);
            } catch(EntityNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            }

            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CreateMovieDTO dto)
        {
            try
            {
                dto.Id = id;
                _updateMovie.Execute(dto);
                return NoContent();
            } catch(EntityNotFoundException e)
            {
                return UnprocessableEntity(e.Message);
            } catch(BadValueException e)
            {
               return StatusCode(409, e.Message);
            } catch(Exception e)
            {
              return  StatusCode(500, e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            try
            {
                _deleteMovie.Execute(id);
                return NoContent();
            } catch (EntityNotFoundException e)
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
