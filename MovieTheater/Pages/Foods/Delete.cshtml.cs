using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Datalayer;
using MovieTheaterService.Interface;

namespace MovieTheater.Pages.Foods
{
    public class DeleteModel : PageModel
    {
        private readonly IFoodService _foodService;

        public DeleteModel(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [BindProperty]
        public Food Food { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == "1")
            {
                if (id == null || _foodService.GetFoods() == null)
                {
                    return NotFound();
                }

                var food = _foodService.GetFoodById(id);

                if (food == null)
                {
                    return NotFound();
                }
                else
                {
                    Food = food;
                }
                return Page();
            }
            else
            {
                TempData["message"] = "You must be login to do this function!.";
                return Redirect("~/Home");
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == "1")
            {
                if (id == null || _foodService.GetFoods() == null)
                {
                    return NotFound();
                }
                var food = _foodService.GetFoodById(id);

                if (food != null)
                {
                    Food = food;
                    _foodService.RemoveFood(Food.FoodId);
                    TempData["message"] = "Delete Successfull!";
                }

                return RedirectToPage("/Foods/Index");
            }
            else
            {
                TempData["message"] = "You must be login to do this function!.";
                return Redirect("~/Home");
            }
        }
    }
}
