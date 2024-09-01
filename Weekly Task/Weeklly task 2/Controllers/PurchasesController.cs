using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECOM_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECOM_MVC.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly EcomContext _context;

        public PurchasesController(EcomContext context)
        {
            _context = context;
        }

        // Display the list of purchases
        public IActionResult Index()
        {
            var ecomContext = _context.Purchases.Include(p => p.Product).Include(p => p.User).ToList();
            return View(ecomContext);
        }

        // Show details of a specific purchase
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = _context.Purchases
                .Include(p => p.Product)
                .Include(p => p.User)
                .FirstOrDefault(p => p.PurchaseId == id);

            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // Load the create purchase form
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // Create a new purchase in the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PurchaseId,UserId,ProductId,PurchaseDate")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                _context.Purchases.Add(purchase);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", purchase.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", purchase.UserId);
            return View(purchase);
        }

        // Load the edit purchase form
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = _context.Purchases.Find(id);

            if (purchase == null)
            {
                return NotFound();
            }

            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", purchase.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", purchase.UserId);
            return View(purchase);
        }

        // Update an existing purchase in the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PurchaseId,UserId,ProductId,PurchaseDate")] Purchase purchase)
        {
            if (id != purchase.PurchaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Purchases.Update(purchase);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseExists(purchase.PurchaseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", purchase.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", purchase.UserId);
            return View(purchase);
        }

        // Load the delete confirmation page
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = _context.Purchases
                .Include(p => p.Product)
                .Include(p => p.User)
                .FirstOrDefault(p => p.PurchaseId == id);

            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // Confirm the deletion of a purchase
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var purchase = _context.Purchases.Find(id);

            if (purchase != null)
            {
                _context.Purchases.Remove(purchase);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        // Check if a purchase exists by its ID
        private bool PurchaseExists(int id)
        {
            return _context.Purchases.Any(e => e.PurchaseId == id);
        }
    }
}
