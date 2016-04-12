using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TopAtlantaRealEstate.ViewModels;
using TopAtlantaRealEstate.Services;
using TopAtlantaRealEstate.Models;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TopAtlantaRealEstate.Controllers
{
    public class CustomerController : Controller
    {
        private ITopAtlantaRepository _repository;
        private ICustomerSearch _customerSearch;

        public CustomerController(ICustomerSearch customerSearch, ITopAtlantaRepository repository)
        {
            _customerSearch = customerSearch;
            _repository = repository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var customers = _repository.GetAllCustomers();

            CustomerSearchViewModel model = new CustomerSearchViewModel();
            model.Customers = customers;

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CustomerSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_customerSearch.CustomerSearch(model.Name,model.Phone,model.Email))
                {
                    ModelState.Clear();
                    ViewBag.Message = "Thanks!";
                }
            }

            return View();
        }
    }
}
