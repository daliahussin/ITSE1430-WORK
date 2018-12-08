/* ITSE 1430
 * Dalia Hussin
 * 12/8/2018
 */
using EventPlanner.Mvc.App_Start;
using EventPlanner.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanner.Mvc.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        // Get only private events
        public ActionResult My()
        {
            EventCriteria criteria = new EventCriteria();
            criteria.IncludePublic = false;
            criteria.IncludePrivate = true;
            
            List<ScheduledEventModel> models = new List<ScheduledEventModel>();

            foreach(ScheduledEvent scheduledEvent in DatabaseFactory.Database.GetAll(criteria))
            {
                ScheduledEventModel model = new ScheduledEventModel();
                model.Description = scheduledEvent.Description;
                model.EndDate = scheduledEvent.EndDate;
                model.Id = scheduledEvent.Id;
                model.Name = scheduledEvent.Name;
                model.StartDate = scheduledEvent.StartDate;
                model.IsPublic = scheduledEvent.IsPublic;

                if(DateTime.Now <= model.EndDate)
                    models.Add(model);
            }

            return View(models.OrderBy(m => m.StartDate));
        }
        
        // Get only public events
        public ActionResult Public()
        {
            EventCriteria criteria = new EventCriteria();
            criteria.IncludePublic = true;
            criteria.IncludePrivate = false;

            List<ScheduledEventModel> models = new List<ScheduledEventModel>();

            foreach (ScheduledEvent scheduledEvent in DatabaseFactory.Database.GetAll(criteria))
            {
                ScheduledEventModel model = new ScheduledEventModel();
                model.Description = scheduledEvent.Description;
                model.EndDate = scheduledEvent.EndDate;
                model.Id = scheduledEvent.Id;
                model.Name = scheduledEvent.Name;
                model.StartDate = scheduledEvent.StartDate;
                model.IsPublic = scheduledEvent.IsPublic;

                if (DateTime.Now <= model.EndDate)
                    models.Add(model);
            }

            return View(models.OrderBy(m => m.StartDate));
        }

        // Get details of an event
        public ActionResult Details(int id)
        {
            EventCriteria criteria = new EventCriteria();
            criteria.IncludePublic = true;
            criteria.IncludePrivate = true;

            ScheduledEvent scheduledEvent = (from m in DatabaseFactory.Database.GetAll(criteria)
                                             where m.Id == id
                                             select m).SingleOrDefault();

            if(scheduledEvent == null)
                return new HttpNotFoundResult("Event not found.");

            ScheduledEventModel model = new ScheduledEventModel();
            model.Description = scheduledEvent.Description;
            model.EndDate = scheduledEvent.EndDate;
            model.Id = scheduledEvent.Id;
            model.Name = scheduledEvent.Name;
            model.StartDate = scheduledEvent.StartDate;
            model.IsPublic = scheduledEvent.IsPublic;

            return View(model);
        }

        // Show view for creating event
        public ActionResult Create()
        {
            return View();
        }

        // Add a new event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScheduledEventModel model)
        {
            ScheduledEvent scheduledEvent = new ScheduledEvent();
            scheduledEvent.Id = model.Id;
            scheduledEvent.IsPublic = model.IsPublic;
            scheduledEvent.Name = model.Name;
            scheduledEvent.StartDate = model.StartDate;
            scheduledEvent.EndDate = model.EndDate;
            scheduledEvent.Description = model.Description;

            if (scheduledEvent.StartDate == null)
                scheduledEvent.StartDate = DateTime.Now;

            if (scheduledEvent.EndDate == null)
                scheduledEvent.EndDate = DateTime.Now;

            if(ModelState.IsValid)
            {
                DatabaseFactory.Database.Add(scheduledEvent);

                if (scheduledEvent.IsPublic)
                    return RedirectToAction("Public", "Event");
                else
                    return RedirectToAction("My", "Event");
            }

            return View();
        }

        // Get the event to be edited
        public ActionResult Edit(int id)
        {
            EventCriteria criteria = new EventCriteria();
            criteria.IncludePublic = true;
            criteria.IncludePrivate = true;

            ScheduledEvent scheduledEvent = (from m in DatabaseFactory.Database.GetAll(criteria)
                                             where m.Id == id
                                             select m).SingleOrDefault();

            if (scheduledEvent == null)
                return new HttpNotFoundResult("Event not found.");

            ScheduledEventModel model = new ScheduledEventModel();
            model.Description = scheduledEvent.Description;
            model.EndDate = scheduledEvent.EndDate;
            model.Id = scheduledEvent.Id;
            model.Name = scheduledEvent.Name;
            model.StartDate = scheduledEvent.StartDate;
            model.IsPublic = scheduledEvent.IsPublic;

            return View(model);
        }

        // Update an event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScheduledEventModel model)
        {
            ScheduledEvent scheduledEvent = new ScheduledEvent();
            scheduledEvent.Id = model.Id;
            scheduledEvent.IsPublic = model.IsPublic;
            scheduledEvent.Name = model.Name;
            scheduledEvent.StartDate = model.StartDate;
            scheduledEvent.EndDate = model.EndDate;
            scheduledEvent.Description = model.Description;

            if (ModelState.IsValid)
            {
                DatabaseFactory.Database.Update(scheduledEvent.Id, scheduledEvent);

                if (scheduledEvent.IsPublic)
                    return RedirectToAction("Public", "Event");
                else
                    return RedirectToAction("My", "Event");
            }

            return View(model);
        }

        // Get the schedule to be deleted
        public ActionResult Delete(int id)
        {
            EventCriteria criteria = new EventCriteria();
            criteria.IncludePublic = true;
            criteria.IncludePrivate = true;

            ScheduledEvent scheduledEvent = (from m in DatabaseFactory.Database.GetAll(criteria)
                                             where m.Id == id
                                             select m).SingleOrDefault();

            if (scheduledEvent == null)
                return new HttpNotFoundResult("Event not found.");

            ScheduledEventModel model = new ScheduledEventModel();
            model.Description = scheduledEvent.Description;
            model.EndDate = scheduledEvent.EndDate;
            model.Id = scheduledEvent.Id;
            model.Name = scheduledEvent.Name;
            model.StartDate = scheduledEvent.StartDate;
            model.IsPublic = scheduledEvent.IsPublic;

            return View(model);
        }

        // Delete the schedule
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            EventCriteria criteria = new EventCriteria();
            criteria.IncludePublic = true;
            criteria.IncludePrivate = true;

            ScheduledEvent scheduledEvent = (from m in DatabaseFactory.Database.GetAll(criteria)
                                             where m.Id == id
                                             select m).SingleOrDefault();

            if (scheduledEvent == null)
                return new HttpNotFoundResult("Event not found.");

            DatabaseFactory.Database.Remove(id);

            if (scheduledEvent.IsPublic)
                return RedirectToAction("Public", "Event");

            return RedirectToAction("My", "Event");
        }
    }
}