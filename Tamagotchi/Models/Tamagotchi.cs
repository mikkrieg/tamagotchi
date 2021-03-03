using System;
using System.Collections.Generic;

namespace Tamagotchi.Models
{
  public class Pet
  {
    public int Food { get; set; } = 100;
    public int Attention { get; set; } = 100;
    public int Sleep { get; set; } = 100;

    public string Mood { get; }
    public string Name { get; set; }
    public int Id { get; set;}

    private static List<Pet> _instances = new List<Pet> {};

    public Pet (string name)
    {
      Name = name;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Pet> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Pet Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public static void DecreaseStats()
    {
      foreach(Pet pet in _instances)
      {
        pet.Food -= 10;
        pet.Attention -= 10;
        pet.Sleep -= 10;
      }
    }

    public void IncreaseFood()
    {
      this.Food = 100;
    }

      public void IncreaseAttention()
    {
      this.Attention = 100;
    }

      public void IncreaseSleep()
    {
      this.Sleep = 100;
    }
    
    public static void RemovePet(int searchId)
    {
      Pet petToRemove = Pet.Find(searchId);
      _instances.Remove(petToRemove);

    //reassign ids
      for(int i=0; i < _instances.Count; i++)
      {
        _instances[i].Id = i+1;
      }
    }
  }
}


// Form that takes a name and then redirects
// Properties: Food, Attention, Rest (Private), (getters/setters)
// HomePage displays all the properties and names
// Buttons Feed, Play, Sleep should affect their respective properties
// Make time pass each button press (decrease all properties by an amount)
// If any property hits 0, it should announce that its dead