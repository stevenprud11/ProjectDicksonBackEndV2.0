using System.Collections.Generic;
using ProjectDicksonBackEnd.Models;

namespace ProjectDicksonBackEnd.Repository
{
    public interface IDrinkQueries
    {
        string ConnectionStringBuilder();
        public List<Drink> GetDrinks();
        public List<Drink> GetDrinks(string drinkName); 
        
    }
}