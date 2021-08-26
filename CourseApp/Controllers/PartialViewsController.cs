using CourseApp.Models;
using CourseApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Controllers
{
    public class PartialViewsController : Controller
    {

        public IActionResult Index() {
            var categories = new List<Category>() {
             new Category() { Name="Kategori 1"},
             new Category() { Name="Kategori 2"},
             new Category() { Name="Kategori 3"}
            };
            var products = new List<Product>()
            {
                new Product() { Name="Product 1"},
                new Product() { Name="Product 2"},
                new Product() { Name ="Product 3"}
            };

            var ProductcategoriesViewModel = new ProductsCategoriesViewModel();
            ProductcategoriesViewModel.Categories=categories;
            ProductcategoriesViewModel.Products = products;
             
            return View(ProductcategoriesViewModel);
        }
        public IActionResult About() {
            var categories = new List<Category>() {
             new Category() { Name="Kategori 1"},
             new Category() { Name="Kategori 2"},
             new Category() { Name="Kategori 3"}
            };
            var products = new List<Product>()
            {
                new Product() { Name="Product 1"},
                new Product() { Name="Product 2"},
                new Product() { Name ="Product 3"}
            };

            var ProductcategoriesViewModel = new ProductsCategoriesViewModel();
            ProductcategoriesViewModel.Categories = categories;
            ProductcategoriesViewModel.Products = products;
             
            return View(ProductcategoriesViewModel);
        }
    }
}
