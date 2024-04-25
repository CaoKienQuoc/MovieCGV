using BusinessObject.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterService.Interface
{
    public interface IFoodService 
    {
        public List<Food> GetFoods();
        public Food GetFoodById(int? id);
        public void AddFood(Food food);
        public void RemoveFood(int id);
        public void UpdateFood(Food food);
    }
}
