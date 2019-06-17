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
    public class MovieGenreController : ControllerBase
    {
        private IAddMovieGanreRelationCommand _addMovieGenreRelation;
        private IDeleteMovieGenreRelationCommand _deleteMovieGenreRelation;

        public MovieGenreController(IAddMovieGanreRelationCommand addMovieGenreRelation, IDeleteMovieGenreRelationCommand deleteMovieGenreRelation)
        {
            _addMovieGenreRelation = addMovieGenreRelation;
            _deleteMovieGenreRelation = deleteMovieGenreRelation;
        }


        // GET: api/MovieGenre


        // POST: api/MovieGenre
        [HttpPost]
        public ActionResult Post([FromBody] GanreMovieRelationDTO dto)
        {
            try
            {
                _addMovieGenreRelation.Execute(dto);
                return StatusCode(201);
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (RelationAlreadyExistException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }



        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id, [FromBody]GanreMovieRelationDTO  dto)
        {
            try
            {
                dto.GanreId = id;
                _deleteMovieGenreRelation.Execute(dto);
                return NoContent();
            } catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }catch(RelationDoesntExistException e)
            {
                return UnprocessableEntity(e.Message);
            }catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
