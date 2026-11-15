using System.ComponentModel;
using System.ComponentModel.Design;
using Microsoft.AspNetCore.Mvc;
using RecipeVault.Services.Interfaces;
using RecipeVault.ViewModels.Recipe;

namespace RecipeVault.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        public async Task<IActionResult> Index()
        {
            var recipes = await recipeService.GetAllAsync();
            return View(recipes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await recipeService.GetDetailsAsync(id);
            if(model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await recipeService.GetEmptyFormAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecipeFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Cuisines = await recipeService.GetCuisinesAsync();
                return View(model);
            }

            int newId = await recipeService.CreateAsync(model);
            return RedirectToAction(nameof(Details), new {id = newId});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await recipeService.GetForEditAsync(id);
            if(model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RecipeFormViewModel model)
        {
            if(!ModelState.IsValid)
            {
                model.Cuisines = await recipeService.GetCuisinesAsync();
                return View(model);
            }

            bool success = await recipeService.EditAsync(id, model);
            if(!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Details), new {id});
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await recipeService.GetDetailsAsync(id);
            if(model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: /Recipe/AddReview - leave a review on a recipe's details page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview(ReviewFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // The form lives on the Details page; pass the errors back via TempData.
                TempData["ReviewError"] = "Please fill in your name (2-50 characters) and pick a rating from 1 to 5.";
                return RedirectToAction(nameof(Details), new { id = model.RecipeId });
            }

            bool success = await recipeService.AddReviewAsync(model);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Details), new { id = model.RecipeId });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await recipeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}