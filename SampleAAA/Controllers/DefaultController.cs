using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleAAA.Models;

namespace SampleAAA.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IPersonRepository personRepository;

        public DefaultController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Person person)
        {
            if(ModelState.IsValid)
            {
                personRepository.AddPerson(person);
                return RedirectToAction(nameof(GetPeople));
            }
            return View(person);
        }
        public IActionResult GetPeople()
        {
            return View(personRepository.GetPeople());
        }
        [HttpPost]
        public IActionResult DeletePerson(int id)
        {
            personRepository.DeletePerson(id);
            return RedirectToAction(nameof(GetPeople));
        }
        public IActionResult EditPerson(int id)
        {
          return View(personRepository.SearchPersonById(id));
        }
        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                personRepository.EditPerson(person);
                return RedirectToAction(nameof(GetPeople));
            }
            return View(person);
        }

    }
}