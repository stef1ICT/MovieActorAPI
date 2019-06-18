using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAInformation.Application.Commands;
using MAInformation.Application.DataTransfer;
using MAInformation.Application.Exceptions;
using MAInformation.Application.Searches;
using MAInformation.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAInformation.MVC.Controllers
{
    public class MovieController : Controller
    {

 


        private IGetMovieCommand _getMovie;
        private IAddMovieCommand _addMovie;
        private IUpdateMovieCommand _updateMovie;
        private IGetMovieMVCDTO _getCreateDto;
        private IDeleteMovieCommand _deleteMovie;

        private IGetAllActors _getActors;
        private IMovieActorRelationCommand _movieAddActor;

        public MovieController(IGetMovieCommand getMovie, IAddMovieCommand addMovie, IUpdateMovieCommand updateMovie, IGetMovieMVCDTO getCreateDto, IDeleteMovieCommand deleteMovie, IGetAllActors getActors, IMovieActorRelationCommand movieAddActor)
        {
            _getMovie = getMovie;
            _addMovie = addMovie;
            _updateMovie = updateMovie;
            _getCreateDto = getCreateDto;
            _deleteMovie = deleteMovie;
            _getActors = getActors;
            _movieAddActor = movieAddActor;
        }








        // GET: Movie
        public ActionResult Index(MovieSearch search)
        {
            var movies = _getMovie.Execute(search);
            return View(movies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            var movieSearch = new MovieSearch { Id = id };
            var movie = _getMovie.Execute(movieSearch).Data.FirstOrDefault();
            if (movie == null)
            {
                TempData["MovieNotFound"] = "Movie not found!";
                return View();
            }
            return View(movie);
        }
        
        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AddActorToMovie(int id)
        {
            var actors = _getActors.GetActors().ToList();
            var MovieId = id;
            var dto = new ActorListAndMovieRelationDataModel { actors = actors, MovieId = MovieId };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActorToMovie(MovieAndActorRelationDTO dto)
        { try
            {
                _movieAddActor.Execute(dto);
                return View(nameof(Index));
            } catch(Exception )
            {
                return View();

            }
           
           
        }



        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMovieDTO dto)
        {
            try
            {
                _addMovie.Execute(dto);
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch(BadValueException e)
            {
                if(e.Message == "Premiere Date bad value.")
                {
                    TempData["BadDate"] = "You need to set premiere date";
                } else
                {
                    TempData["BadRating"] = "Rating must be between 1-10";
                }
         
                return View(dto);
            }catch(EntityNotFoundException e)
            {
                if(e.Message == "Language doesn't exist.") 
                {
                    TempData["LanguageError"] = "This language doesn't exist.";
                 
                } else
                {
                    TempData["DirectorError"] = "This director doesn't exist.";
                }
                return View(dto);
            }
         
            catch
            {
                return View(dto);
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            var dto = _getCreateDto.Execute(id);
            return View(dto);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateMovieDTO dto)
        {
            try
            {
                // TODO: Add update logic here
           _updateMovie.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (BadValueException e)
            {
                if (e.Message == "Premiere Date bad value.")
                {
                    TempData["BadDate"] = "You need to set premiere date";
                }
                else
                {
                    TempData["BadRating"] = "Rating must be between 1-10";
                }

                return View(dto);
            }
            catch (EntityNotFoundException e)
            {
                if (e.Message == "Language doesn't exist.")
                {
                    TempData["LanguageError"] = "This language doesn't exist.";

                }
                else
                {
                    TempData["DirectorError"] = "This director doesn't exist.";
                }
                return View(dto);
            }
            catch
            {
                return View(dto);
            }
        }

        // GET: Movie/Delete/5
       

        // POST: Movie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                try
                {
                    _deleteMovie.Execute(id);
                    return RedirectToAction(nameof(Index));
                } catch(EntityNotFoundException )
                {
                    TempData["MovieError"] = "This movie doesn't exist!";
                    return RedirectToAction(nameof(Index));
                }
                // TODO: Add delete logic 
            }

            catch
            {
                return View();
            }
        }
    }
}