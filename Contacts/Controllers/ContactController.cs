using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Contacts.Entities;
using Contacts.Contexts;
using Contacts.Models;
using Contacts.br.com.satelital.www;

namespace Contacts.Controllers
{
    public class ContactController : Controller
    {
        private readonly DataContext _db = new DataContext();

        //
        // GET: /Contact/

        public ActionResult Index(DTOSearchContact model)
        {
            ModelState.Remove("Id");
            var contacts = _db.Contacts.ToList();

            if (model.Id > 0)
            {
                int id = model.Id;
                contacts = contacts.Where(c => c.Id == id).ToList();
            }

            if (!string.IsNullOrEmpty(model.Name))
            {
                string name = model.Name;
                contacts = contacts.Where(c => c.Name.Contains(name)).ToList();
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                string email = model.Email;
                contacts = contacts.Where(c => c.Email.Contains(email)).ToList();
            }

            ViewBag.Message = "Listagem de Contatos";
            return View(contacts);
        }

        //
        // GET: /Contact/Details/5

        public ActionResult Details(int id = 0)
        {
            Contact contact = _db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            ViewBag.Message = "Detalhes do Contato";
            return View(contact);
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            ViewBag.Message = "Cadastrar Contato";
            return View();
        }

        //
        // POST: /Contact/Create

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.CreateDate = DateTime.Now;
                contact.State = contact.State.ToUpper();
                _db.Contacts.Add(contact);
                _db.SaveChanges();
                TempData["msg"] = "Registro inserido com sucesso.";
                return RedirectToAction("Index");
            }

            ViewBag.Message = "Cadastrar Contato";
            return View(contact);
        }

        //
        // GET: /Contact/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contact contact = _db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            ViewBag.Message = "Editar Contato";
            return View(contact);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.State = contact.State.ToUpper();
                _db.Entry(contact).State = EntityState.Modified;
                _db.SaveChanges();
                TempData["msg"] = "Registro editado com sucesso.";
                return RedirectToAction("Index");
            }

            ViewBag.Message = "Editar Contato";
            return View(contact);
        }

        //
        // GET: /Contact/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contact contact = _db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            ViewBag.Message = "Excluir Contato";
            return View(contact);
        }

        //
        // POST: /Contact/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = _db.Contacts.Find(id);
            _db.Contacts.Remove(contact);
            _db.SaveChanges();
            TempData["msg"] = "Registro exluído com sucesso.";
            return RedirectToAction("Index");
        }

        //
        // Get: /Contact/GetBreeds?ZipCode = ?

        public JsonResult GetAddress(string zipCode)
        {
            var zipCodeTmp = Convert.ToInt32(zipCode.Replace("-", ""));
            _db.Configuration.ProxyCreationEnabled = false;
            var obj = new AddressService();
            var result = obj.GetAddress("3713F255-4568-4DF9-B55B-6B17DC084A0E", "brasil", zipCodeTmp, true);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
