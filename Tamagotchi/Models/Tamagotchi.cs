using System;
using System.Collections.Generic;

namespace Tamagotchi.Models
{
  public class Pet
  {
    public int Food { get; } = 100;
    public int Attention { get; } = 100;
    public int Sleep { get; } = 100;

    public string Mood { get; }
    public string Name { get; set; }
    public int Id { get; }

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

  }
}


// Form that takes a name and then redirects
// Properties: Food, Attention, Rest (Private), (getters/setters)
// HomePage displays all the properties and names
// Buttons Feed, Play, Sleep should affect their respective properties
// Make time pass each button press (decrease all properties by an amount)
// If any property hits 0, it should announce that its dead