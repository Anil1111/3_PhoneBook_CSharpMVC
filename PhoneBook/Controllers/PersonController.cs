using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.Controllers
{
	public class PersonController : Controller
	{
		// GET: /<controller>/
		[HttpGet]
		public IActionResult Index(int id = 1)
		{
			int prev = id - 1;
			int next = id + 1;

			if (id <= 1)
			{
				prev = 1;
			}

			ViewBag.Prev = prev;
			ViewBag.Next = next;
			ViewBag.Page = id;

			return View(SourceManager.Get(id, 3));
		}
		[HttpPost]
		public IActionResult Index(string lastName, int id = 1)
		{
			return View(SourceManager.GetLastNames(lastName));
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(PersonModel personModel)
		{
			if (ModelState.IsValid)
			{
				var id = SourceManager.Add(personModel);
				return Content("Dodano " + id);
			}
			return View(personModel);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var person = SourceManager.GetById(id);
			return View(person);
		}

		[HttpPost]
		public IActionResult Edit(int id, PersonModel personModel)
		{
			if (ModelState.IsValid)
			{
				SourceManager.Update(personModel);
			}
			return View(personModel);
		}
		[HttpGet]
		public IActionResult Remove(int id)
		{
			var person = SourceManager.GetById(id);
			return View(person);
		}

		[HttpPost]
		public IActionResult RemoveConfirm(int id)
		{

			SourceManager.Remove(id);
			return Redirect("Index");
		}
	}

	//TODO slajd 11 zmiana routingu

}
