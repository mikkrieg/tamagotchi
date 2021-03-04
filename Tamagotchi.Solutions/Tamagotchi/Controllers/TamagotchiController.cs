using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using System.Collections.Generic;
using System;

namespace Tamagotchi.Controllers
{
  public class TamagotchiController : Controller
  {
    [HttpGet("/tamagotchi")]
      public ActionResult Index()
      {
        List<Pet> allPets = Pet.GetAll();
        Pet.DecreaseStats();
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
    public ActionResult EditFood(int id)
    {
      Pet findPet = Pet.Find(id);
      findPet.IncreaseFood();
      return RedirectToAction("Show", new { findPet.Id });
    }

    [HttpGet("/tamagotchi/{id}/interact")]
    public ActionResult EditAttention(int id)
    {
      Pet findPet = Pet.Find(id);   
      findPet.IncreaseAttention();
      return RedirectToAction("Show", new { findPet.Id });
    }

    [HttpGet("/tamagotchi/{id}/sleep")]
    public ActionResult EditSleep(int id)
    {
      Pet findPet = Pet.Find(id);
      findPet.IncreaseSleep();
      return RedirectToAction("Show", new { findPet.Id });
    }

    [HttpPost("/tamagotchi/delete/{id}")]
    public ActionResult DeletePet(int id)
    {
      Pet.RemovePet(id);
      return RedirectToAction("Index");
    }
  }
}