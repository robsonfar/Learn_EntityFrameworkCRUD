﻿using Learn_EntityFrameworkCRUD.Data;
using Learn_EntityFrameworkCRUD.Models;

using Microsoft.AspNetCore.Mvc;

namespace Learn_EntityFrameworkCRUD.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductTypeController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            List<ProductType> productTypeList = _applicationDbContext.ProductType.ToList();

            return View(productTypeList);
        }

        public IActionResult Edit(int? id)
        {
            ProductType? obj;

            if (id == null)
            {
                obj = new ProductType();
            }
            else
            {
                obj = _applicationDbContext.ProductType.Find(id);
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            ProductType? obj = _applicationDbContext.ProductType.Find(id);

            _applicationDbContext.ProductType.Remove(obj);

            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(ProductType obj)
        {
            if (obj.Id == 0)
            {
                _applicationDbContext.ProductType.Add(obj);
            }
            else
            {
                ProductType? updObj = _applicationDbContext.ProductType.Find(obj.Id);

                updObj.Name = obj.Name;

                _applicationDbContext.ProductType.Update(updObj);
            }

            _applicationDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
