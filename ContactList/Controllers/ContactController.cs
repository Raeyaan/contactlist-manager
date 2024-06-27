using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContactList.Models;

namespace ContactList.Controllers
{
    public class ContactController : Controller
    {
        private ContactContext context { get; set; }

        public ContactController(ContactContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
            ViewBag.Referrer = "Add";
            return View("Edit", new Contact());
        }


        [HttpGet]
        public IActionResult Edit(int id, string slug)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
            var contact = context.Contacts.Find(id);
            var url = Url.RouteUrl("editRoute", new { id, slug });
            return View(contact);
        }


        [HttpGet]
        public IActionResult Detail(int id, string slug)
        {
            ViewBag.Action = "Detail";
            ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
            var contact = context.Contacts.Find(id);
            var url = Url.RouteUrl("contactRoute", new { id, slug });
            return View(contact);
        }


        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactId == 0) 
                    context.Contacts.Add(contact);
                else 
                    context.Contacts.Update(contact);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (contact.ContactId == 0) ? "Add": "Edit";
                ViewBag.Categories = context.Categories.OrderBy(g => g.Name).ToList();
                var url = Url.RouteUrl("contactRoute", new { contact.ContactId, contact.Slug });
                return View(contact);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id, string slug)
        {
            var contact = context.Contacts.Find(id);
            var url = Url.RouteUrl("deleteRoute", new { id, slug });
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


    }
}