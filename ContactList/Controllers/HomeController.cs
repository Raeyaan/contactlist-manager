﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactList.Models;

namespace MovieList.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context { get; set; }

        public HomeController(ContactContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var contacts = context.Contacts
                .Include(m => m.Category)
                .OrderBy(m => m.FirstName)
                .OrderBy(m => m.LastName)
                .ToList();
            return View(contacts);
        }
    }
}