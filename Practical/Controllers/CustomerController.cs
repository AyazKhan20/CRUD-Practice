using Microsoft.AspNetCore.Mvc;
using Practical.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Practical.Controllers
{
    public class CustomerController : Controller
    {

        private readonly CustomerDbContext _Db;
        public CustomerController(CustomerDbContext context)
        {
            this._Db = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _Db.Customers.ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer Obj)
        {
            try {
                if (ModelState.IsValid)
                {
                    _Db.Add(Obj);
                    await _Db.SaveChangesAsync();
                    TempData["successmessage"] = "Customer Added Successfully";
                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception ex)
            {
                TempData["errormessage"] = "Customer not found";
            }
            return View(Obj);

        }

        public async Task<IActionResult> Edit(int id)
        {
            
            var customer = await _Db.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Customer Obj)
        {
            try 
            {
                if (id != Obj.Customer_Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    _Db.Update(Obj);
                    await _Db.SaveChangesAsync();
                    TempData["successmessage"] = "Customer Updated Successfully";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["errormessage"] = "Customer not found";
            }


            return View(Obj);
        }
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _Db.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _Db.Customers.FindAsync(id);
            if (customer != null)
            {
               _Db.Customers.Remove(customer);
                await _Db.SaveChangesAsync();
                TempData["successmessage"] = "Customer Deleted Successfully";

            }
            else
            {
                TempData["errormessage"] = "Customer not found";
            }
                return RedirectToAction("Index");
        }
    }
}
