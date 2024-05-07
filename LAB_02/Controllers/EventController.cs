using LAB_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB_02.Controllers
{
    public class EventController : Controller
    {
        private static List<EventModel> events = new List<EventModel>() {
            new EventModel() { Id = 1, Ime="Event1", Lokacija="Lokacija1"},
            new EventModel() { Id = 2, Ime="Event2", Lokacija="Lokacija2"},
            new EventModel() { Id = 3, Ime="Event3", Lokacija="Lokacija3"}
        };
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowAllEvents()
        {
            return View(events);
        }
        public EventModel getEventWithId(int id) {
            //foreach (var el in events) { 
            //    if (el.Id == id) return el;
            //}

            return events.Find(e=>e.Id == id);
        }
        public ActionResult EditEvent(int id)
        {
            EventModel model = getEventWithId(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEventInList(EventModel model)
        {
           
            if (!ModelState.IsValid)
            {
                return View("EditEvent", model);
            }
            
            EventModel e = getEventWithId(model.Id);
            if (e != null)
            {
                e.Ime = model.Ime;
                e.Lokacija = model.Lokacija;
            }

            return RedirectToAction("ShowAllEvents");
        }
        public ActionResult DeleteEvent(int id)
        {
            events.Remove(getEventWithId(id));

            return RedirectToAction("ShowAllEvents");
        }
        public ActionResult ShowEvent(int id) {
            EventModel model = getEventWithId(id);
            return View(model);
        }

        public ActionResult AddEvent() {
            EventModel model = new EventModel();
            return View(model);
        }

        public ActionResult InsertNewEvent(EventModel model) {
            if (!ModelState.IsValid) { 
                return View("AddEvent",model);
            }
            EventModel newEvent = model;
            if (events.Count == 0)
            {
                newEvent.Id = 1;
            }
            else
            {
                newEvent.Id = events.Max(e => e.Id) + 1;
            }
            events.Add(newEvent);
            return View("ShowEvent",newEvent);
        }
    }
}