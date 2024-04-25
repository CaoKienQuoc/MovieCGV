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
    public class IndexModel : PageModel
    {
        private readonly IFoodService _foodService;

        public IndexModel(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public IList<Food> Food { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == "1")
            {
                if (_foodService.GetFoods() != null)
                {
                    Food = _foodService.GetFoods();
                }
                else
                {
                    TempData["message"] = "You must be login to do this function!.";
                    Redirect("~/Home");
                }
            }
        }
    }
}
