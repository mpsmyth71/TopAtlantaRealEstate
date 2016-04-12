using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TopAtlantaRealEstate.Models;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Net;
using TopAtlantaRealEstate.ViewModels.API;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TopAtlantaRealEstate.Controllers.API
{
    [Route("api/Customers/{customerId}/emails")]
    public class EmailController : Controller
    {
        private ILogger<EmailController> _logger;
        private ITopAtlantaRepository _repository;

        public EmailController(ITopAtlantaRepository repository, ILogger<EmailController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get(int customerId)
        {
            try
            {
                var results = _repository.GetEmailByCustomerId(customerId);

                if (results == null)
                {
                    return Json(null);
                }
                return Json(Mapper.Map<IEnumerable<EmailViewModel>>(results.Emails));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get emails for CustomerId {customerId}", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occurred finding email");
            }

        }

        [HttpPost("")]
        public JsonResult Post(int customerId, [FromBody]EmailViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newEmail = Mapper.Map<Email>(vm);

                    _repository.addEmail(customerId, newEmail);

                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<EmailViewModel>(newEmail));
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to save email for CustomerId {customerId}", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occurred saving email");
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }

    }
}
