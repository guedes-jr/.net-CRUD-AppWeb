﻿using Microsoft.AspNetCore.Mvc;
using RazorPagesPizza.Models;
using RazorPagesPizza.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesPizza.Pages
{
    public class PizzaModel : PageModel
    {
        public List<Pizza> pizzas = new();

        [BindProperty]
        public Pizza NewPizza { get; set; } = new();

        public void OnGet()
        {
            pizzas = PizzaService.GetAll();
        }

        public string GlutenFreeText(Pizza pizza)
        {
            return pizza.IsGlutenFree ? "Sem glútem": "Com glútem";
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PizzaService.Add(NewPizza);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            PizzaService.Delete(id);
            return RedirectToAction("Get");
        }
    }
}