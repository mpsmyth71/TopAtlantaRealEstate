using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TopAtlantaRealEstate.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using AutoMapper;
using TopAtlantaRealEstate.ViewModels.API;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TopAtlantaRealEstate.Controllers.API
{
    [Route("api/Customers/{customerId}/phones")]
    public class PhoneController : Controller
    {
        private ILogger<PhoneController> _logger;
        private ITopAtlantaRepository _repository;

        public PhoneController(ITopAtlantaRepository repository, ILogger<PhoneController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get(int customerId)
        {
            try
            {
                var results = _repository.GetPhoneByCustomerId(customerId);

                if(results == null)
                {
                    return Json(null);
                }
                return Json(Mapper.Map<IEnumerable<PhoneViewModel>>(results.Phones));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get phone numbers for CustomerId {customerId}", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occurred finding phone number");
            }

        }

        [HttpPost("")]
        public JsonResult Post(int customerId, [FromBody]PhoneViewModel vm)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var newPhone = Mapper.Map<Phone>(vm);

                    _repository.addPhone(customerId, newPhone);

                    if(_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<PhoneViewModel>(newPhone));
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to save phone for CustomerId {customerId}", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occurred saving phone number");
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }
    }
}
