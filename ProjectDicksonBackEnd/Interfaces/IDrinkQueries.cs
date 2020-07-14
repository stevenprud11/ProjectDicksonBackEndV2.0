using System.Collections.Generic;
using ProjectDicksonBackEnd.Models;

namespace ProjectDicksonBackEnd.Repository
{
    public interface IDrinkQueries
    {
        public List<Drink> GetDrinks();
        public List<Drink> GetDrinks(string drinkName);
        public List<Drink> GetDrinksFrom(string barName);
    }
}