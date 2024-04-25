using BusinessObject.Datalayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTheaterRepo.Interface
{
    public interface IFoodRepository
    {
        public List<Food> GetFoods();
        public Food GetFoodById(int? id);
        public void AddFood(Food food);
        public void RemoveFood(int id);
        public void UpdateFood(Food food);
    }
}
