using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NameController : Controller
    {

        private readonly INameService _iplanService;
        private readonly ILogger<NameController> logger;

        public NameController(INameService iplanService, ILogger<NameController> logger)
        {
            _iplanService = iplanService;
            this.logger = logger;
        }

        //post:to create a new todolist
        [HttpPost]
        public ActionResult<NameItem> Create(NameItem plan)
        {
            _iplanService.insert(plan);
            _iplanService.save();
            return Json(new { message = "inserted  Successfully" });
        }

        [HttpGet]
        public ActionResult<IEnumerable<NameItem>> GetPlans()
        {
            logger.LogInformation("Getting all the Details");
            return _iplanService.GetAll();
        }
        // GET: TodoItems/Details/5

        [HttpGet("{id}")]
        public ActionResult<NameItem> Details(int id)
        {
            logger.LogDebug("getting by id......");//logger activities
            var plan = _iplanService.GetByID(id);
            if (plan != null)
            {
                return Ok(plan);
            }
            else
            {
                return Json(new { message = "This id is not found to get the data Successfully" });

            }
        }


        [HttpPut]
        //put:to update the data of the todolist
        public IActionResult Edit(NameItem plan)
        {
            _iplanService.update(plan);
            _iplanService.save();
            return Json(new { message = "updated Successfully" });
        }

        //Delete:to delete the todolist
        [HttpDelete("{id}")]
        public ActionResult<NameItem> Delete(int id)
        {
            var todoItem = _iplanService.GetByID(id);
            if (todoItem != null)
            {
                _iplanService.Deleted(id);
                _iplanService.save();
                return Json(new { message = "deleted Successfully" });

            }
            else
            {
                return Json(new { message = "This id is not found to deleted the data Successfully" });
            }

        }
        ////Get:to get and show  the values in json file
        //[Route("Json")]
        //[HttpGet]
        //public ActionResult<IEnumerable<jsonproperty>> Details()
        //{
        //    return Content(JsonConvert.SerializeObject(jsonprop));
        //}
    }
}
