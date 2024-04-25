using BusinessObject.Datalayer;
using MovieTheaterDAO;
using MovieTheaterRepo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterRepo.Implement
{
    public class FoodRepository : IFoodRepository
    {
        public void AddFood(Food food) => FoodDAO.Instance.AddFood(food);

        public Food GetFoodById(int? id) => FoodDAO.Instance.GetFoodById(id);
        public List<Food> GetFoods() => FoodDAO.Instance.GetFoods();

        public void RemoveFood(int id) => FoodDAO.Instance.RemoveFood(id);

        public void UpdateFood(Food food) => FoodDAO.Instance.UpdateFood(food);
    }
}
