using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Datalayer;
using MovieTheaterService.Interface;

namespace MovieTheater.Pages.Foods
{
    public class CreateModel : PageModel
    {
        private readonly IFoodService _foodService;

        public CreateModel(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public IActionResult OnGet()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == "1")
            {
                return Page();
            }
            else
            {
                TempData["message"] = "You Are Not Admin!.";
                return Redirect("~/Home");
            }
        }

        [BindProperty]
        public Food Food { get; set; } = default!;
        

        
        public async Task<IActionResult> OnPostAsync()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == "1")
            {
                if (!ModelState.IsValid || _foodService.GetFoods() == null || Food == null)
            {
                return Page();
            }
            if (!IsValidName(Food.Name) || !IsValidPrice(Food.Price))
            {
                ModelState.AddModelError(string.Empty, "Invalid Type.");
                return Page();
            }

            _foodService.AddFood(Food);
            TempData["message"] = "Add Food Succesfull!";
            return Page();
            }
            else
            {
                TempData["message"] = "You must be login to do this function!.";
                return Redirect("~/Home");
            }
        }

        private bool IsValidName(string name)
        {
            // Kiểm tra xem tên món ăn có chỉ chứa ký tự chữ không
            return !string.IsNullOrEmpty(name) && name.All(char.IsLetter);

        }

        private bool IsValidPrice(decimal? price)
        {
            // Kiểm tra xem giá tiền có là một số không
            return price >= 0;
        }
    }
}
