using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonFruit;

namespace RestServer1.Manager
{
    public class FruitManager
    {
        public static List<Fruit> fruits;

        public FruitManager()
        {
            fruits = new List<Fruit>();
            fruits.Add(new Fruit("Banana"));
            fruits.Add(new Fruit("Apple"));
            fruits.Add(new Fruit("Rotten Banana"));
            fruits.Add(new Fruit("Good Apple"));
        }

        public List<Fruit> GetList(string substring)
        {
            List<Fruit> result = new List<Fruit>(fruits);
            if (substring != null)
            {
                result = result.FindAll(fruit => fruit.typeOfFruit.Contains(substring,StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
    }
}
