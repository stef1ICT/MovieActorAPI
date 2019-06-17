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

namespace MAInformation.MVC.Controllers
{
    public class ActorController : Controller
    {
        private IGetActors _getActors;
        private IAddActorCommand _addActor;
        private IUpdateActorCommand _updateActor;
        private IDeleteActorCommand _deleteActor;

        public ActorController(IGetActors getActors, IAddActorCommand addActor, IUpdateActorCommand updateActor, IDeleteActorCommand deleteActor)
        {
            _getActors = getActors;
            _addActor = addActor;
            _updateActor = updateActor;
            _deleteActor = deleteActor;
        }







        // GET: Actor
        public ActionResult Index(ActorSearch search)
        {
            var actors = _getActors.Execute(search);
            
            return View(actors);
        }

        // GET: Actor/Details/5
        public ActionResult Details(int id)
        {
            var actorSearch = new ActorSearch { Id = id };
            var actor = _getActors.Execute(actorSearch).Data.FirstOrDefault();
            return View(actor);
        }

        // GET: Actor/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Actor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateActorDTO dto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(dto);
                }
                // TODO: Add insert logic here
                _addActor.Execute(dto);
                return RedirectToAction(nameof(Index));
            } catch(EntityNotFoundException e)
            {
                
                TempData["GenderError"] = "Gender doesn't exist";
                return View();
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Actor/Edit/5
        public ActionResult Edit(int id)
        {
            var actorSearch = new ActorSearch { Id = id };
            var actorGetDTO = _getActors.Execute(actorSearch).Data.FirstOrDefault();
            var actor = new CreateActorDTO
            {
                DateOfBirth = actorGetDTO.DateOfBirth,
                Id = actorGetDTO.Id,
                Country = actorGetDTO.Country,
                FirstName = actorGetDTO.FirstName,
                GenderId = (int)actorGetDTO.GenderId,
                Height = actorGetDTO.Height,
                HomeTown = actorGetDTO.HomeTown,
                LastName = actorGetDTO.LastName,
                Picture = actorGetDTO.Picture,
                Weight = actorGetDTO.Weight
            };
            return View(actor);
        }

        // POST: Actor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( CreateActorDTO dto)
        {
            
            try
            {
                _updateActor.Execute(dto);
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch(EntityNotFoundException e)
            {
                if (e.Message == "Genre doesn't exist.")
                {
                    TempData["GenderError"] = "Gender doesn't exist!";
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
             
            
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        

        // POST: Actor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _deleteActor.Execute(id);
                return RedirectToAction(nameof(Index));
            } catch(EntityNotFoundException)
            {
                TempData["DeleteError"] = "This movie doesn't exist";
                return View();
            }
          
            catch
            {
                return View();
            }
        }
    }
}