using BusinessObject.Datalayer;
using MovieTheaterRepo.Interface;
using MovieTheaterService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterService.Implement
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository foodRepository;

        public FoodService(IFoodRepository repository)
        {
            foodRepository = repository;
        }
        public void AddFood(Food food)
        {
            foodRepository.AddFood(food);
        }

        public Food GetFoodById(int? id)
        {
            return foodRepository.GetFoodById(id);
        }

        public List<Food> GetFoods()
        {
            return foodRepository.GetFoods();
        }

        public void RemoveFood(int id)
        {
            foodRepository.RemoveFood(id);
        }

        public void UpdateFood(Food food)
        {
            foodRepository.UpdateFood(food);
        }
    }
}
