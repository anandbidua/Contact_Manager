
using ContactInformation.Models;
using ContactsService;
using System.Web.Mvc;

namespace ContactInformation.Controllers
{
    public class ContactController : Controller
    {
       private readonly IContactsService _iContactsService;
        public ContactController(IContactsService iContactsService) {

            _iContactsService = iContactsService;
        }
        public ActionResult Index()
        {
            return View(_iContactsService.GetContacts());
        }

        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Contacts contacts)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
               var result= _iContactsService.CreateContact(Utility.Converter.Map(contacts));
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Contact already exists for given email or phone.";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int Id)
        {
            Contacts contacts = Utility.Converter.Map(_iContactsService.EditContact(Id));
            return View(contacts);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                _iContactsService.EditContact(Utility.Converter.Map(collection));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int Id) {

            _iContactsService.DeleteContact(Id);

            return RedirectToAction("Index");
        }
    }
}