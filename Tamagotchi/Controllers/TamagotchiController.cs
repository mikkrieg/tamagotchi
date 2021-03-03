using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using System.Collections.Generic;

namespace Tamagotchi.Controllers
{
  public class TamagotchiController : Controller
  {
    [HttpGet("/tamagotchi")]
      public ActionResult Index()
      {
        List<Pet> allPets = Pet.GetAll();
        return View(allPets);
      }
    [HttpGet("/tamagotchi/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpPost("/tamagotchi")]
    public ActionResult Create(string name)
    {
      Pet newPet = new Pet(name);
      return RedirectToAction("Index");
    }
    [HttpGet("/tamagotchi/{id}")]
    public ActionResult Show(int id)
    {
      Pet findPet = Pet.Find(id);
      return View(findPet);
    }
    [HttpGet("/tamagotchi/{id}/feed")]
    public ActionResult Edit(int id)
    {
      Pet findPet = Pet.Find(id);
    

      return RedirectToAction("Show", findPet);
    }
  }
}