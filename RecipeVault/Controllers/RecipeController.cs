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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await recipeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}