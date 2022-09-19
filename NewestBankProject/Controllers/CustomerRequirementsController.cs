using Microsoft.AspNetCore.Mvc;
using NewestBankProject.Data;
using NewestBankProject.Models;
using System.ComponentModel;

namespace NewestBankProject.Controllers
{
    public class CustomerRequirementsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomerRequirementsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CustomerRequirements> objCustomerRequirementsList = _db.customerRequirements;
            return View(objCustomerRequirementsList);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerRequirements obj)
        {
            if (ModelState.IsValid)
            {
                _db.customerRequirements.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
                 return View(obj);
          
        }

        public IActionResult Edit(int? CustomerID)
        {
            if(CustomerID == null || CustomerID == 0)
            {
                return NotFound();
            }
            var CustomerRequirementsFromDb = _db.customerRequirements.Find(CustomerID);
           

            if (CustomerRequirementsFromDb == null)
            {
                return NotFound();
            }
            return View(CustomerRequirementsFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CustomerRequirements obj)
        {
            if (ModelState.IsValid)
            {
                _db.customerRequirements.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);

        }
        public IActionResult Delete(int? CustomerID)
        {
            if (CustomerID == null || CustomerID == 0)
            {
                return NotFound();
            }
            var CustomerRequirementsFromDb = _db.customerRequirements.Find(CustomerID);


            if (CustomerRequirementsFromDb == null)
            {
                return NotFound();
            }
            return View(CustomerRequirementsFromDb);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? CustomerID)
        {
            var obj = _db.customerRequirements.Find(CustomerID);
            if (obj == null)
            {
                return NotFound();
            }
            
                _db.customerRequirements.Remove(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            
          

        }
    }
}
