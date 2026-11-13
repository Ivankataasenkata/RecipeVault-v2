using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RecipeVault.Models;
using RecipeVault.Services.Interfaces;

namespace RecipeVault.Controllers;

public class HomeController : Controller
{
    private readonly IRecipeService recipeService;

    public HomeController(IRecipeService recipeService)
    {
        this.recipeService = recipeService;
    }

    public async Task<IActionResult> Index()
    {
        var latestRecipes = await recipeService.GetLatestAsync(3);
        return View(latestRecipes);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
