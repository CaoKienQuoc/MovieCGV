using BusinessObject.Datalayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterDAO
{
    public class FoodDAO
    {
        private readonly MovieTheaterCGVContext _dbContext;
        private static FoodDAO _instance;

        public FoodDAO()
        {
            _dbContext = new MovieTheaterCGVContext();
        }

        public static FoodDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FoodDAO();
                }
                return _instance;
            }
        }

        public List<Food> GetFoods()
        {
             return _dbContext.Foods.ToList();
        }
        public Food GetFoodById(int? id)
        {
            return _dbContext.Foods.FirstOrDefault(f => f.FoodId.Equals(id));
        }
        public void AddFood(Food food)
        {
            if (GetFoodById(food.FoodId) == null)
            {
                _dbContext.Foods.Add(food);
                _dbContext.SaveChanges();
            }
        }
        public void RemoveFood(int id)
        {
            Food food = GetFoodById(id);
            if (food != null)
            {
                _dbContext.Foods.Remove(food);
                _dbContext.SaveChanges();
            }
        }
        public void UpdateFood(Food food)
        {
            Food f = GetFoodById(food.FoodId);
            if (f !=  null)
            {
                f.Name = food.Name;
                f.Price = food.Price;
                _dbContext.SaveChanges();
            }
        }
    }
}
