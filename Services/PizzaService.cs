using System.Collections.Generic;
using System.Linq;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public static class PizzaService
    {
        static List<Pizza> Pizzas { get; }

        static int nextId = 3;

        static PizzaService()
        {
            Pizzas = new()
            {
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
            };
        }

        public static List<Pizza> GetAll() => Pizzas;

        public static Pizza Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

        public static void Add(Pizza p)
        {
            p.Id = nextId++;
            Pizzas.Add(p);
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
                return;
            Pizzas.Remove(pizza);
        }

        public static void Update(Pizza p)
        {
            var index = Pizzas.FindIndex(pizza => pizza.Id == p.Id);
            if (index == -1)
                return;
            Pizzas[index] = p;
        }

    }
}