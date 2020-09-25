using BankerApp.Infrastructure.Services;
using BankerApp.Infrastructure.ViewModels;
using BankerApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BankerApp.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationUserManager _manager;
        private CustomerService service = new CustomerService();

        private ApplicationUserManager UserManager
        {
            get
            {
                return _manager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

        }

        //GET
        public ActionResult CreateCustomer()
        {
            return View();
        }

        //POST
        [HttpPost]
        public async Task<ActionResult> CreateCustomer(RegisterCustomerViewModel model)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber

            };

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                int id = service.CreateCustomer(model, user.Id);
                service.CreateCustomerAccount(id, "GTB");
                //if successfully create a customer
                TempData["Message"] = "Customer created successfully";
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("1", "Failed to create customer");
            return View();
        }
    }
}