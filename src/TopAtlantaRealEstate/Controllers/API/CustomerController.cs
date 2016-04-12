using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TopAtlantaRealEstate.Models;
using System.Net;
using TopAtlantaRealEstate.ViewModels.API;
using AutoMapper;
using Microsoft.Extensions.Logging;
using TopAtlantaRealEstate.Services;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TopAtlantaRealEstate.Controllers.API
{
    [Route("api/Customers")]
    public class CustomerController : Controller
    {
        private GeoLocationService _geoLocationService;
        private ILogger<CustomerController> _logger;
        private ITopAtlantaRepository _repository;

        public CustomerController(ITopAtlantaRepository repository, ILogger<CustomerController> logger, GeoLocationService geoLocationService)
        {
            _repository = repository;
            _logger = logger;
            _geoLocationService = geoLocationService;
        }

        [HttpGet("")]
        public async Task<JsonResult> Get()
        {
            var results = _repository.GetAllCustomers();

            var geoResult = await _geoLocationService.Lookup("Atlanta, GA");

            return Json(Mapper.Map<IEnumerable<CustomerViewModel>>(results));
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]CustomerViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newCustomer = Mapper.Map<Customer>(vm);
                    _logger.LogInformation("Saving New Customer");
                    _repository.AddCustomer(newCustomer);

                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<CustomerViewModel>(newCustomer));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new Customer", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message});
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }
    }
}
