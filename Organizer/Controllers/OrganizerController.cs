
using Newtonsoft.Json;
using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizer.Controllers
{
    // Organizer/notes
    // organizer/CreateNote

    // Class Organizer + суфикс Controller который используеться сервером. Наследуеться от Controller
    public class OrganizerController : Controller
    {
        // Обьявление поля, которое являеться экземпляром класа  OrganizerDbDataContext
        // который являеться обектно ориентированой моделью базы данных. (напримере универа)
        private OrganizerDbDataContext db_context;  

        public OrganizerController()//конструктор класса Organizer
        {
            db_context =  new OrganizerDbDataContext();// инициализия db_context в консруктре Organizer
        }

        // =============================================


   [HttpGet]//атрибут для сервера
        public JsonResult Notes () // метод с возвращаемым типом JsonResult  
        {
            var notes = db_context.Notes.ToArray();
            var settings = new JsonSerializerSettings  { TypeNameHandling = TypeNameHandling.Auto };
            var jsonAsNotes = JsonConvert.SerializeObject(notes, settings); // конвертирует обьекты в 
                                                                                  // JSon тоесть строку...
            
            return Json( jsonAsNotes, JsonRequestBehavior.AllowGet); // возвращаем наш jsonAsNotes/ строку
        }

        //===============================================================================


        //[HttpPost]
         public JsonResult CreateNote (string title, string content)
        {
            
            this.db_context.CreateNote(title,content, DateTime.Now);
            db_context.SubmitChanges();
            return Json(null,JsonRequestBehavior.AllowGet);
        }
     

        public ActionResult Index ()
        {
            return View();
        }
    }
}