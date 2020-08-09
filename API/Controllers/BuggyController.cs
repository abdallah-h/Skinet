using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    public class BuggyController : BaseApiController {
        private readonly StoreContext _storeContext;
        public BuggyController (StoreContext storeContext) {
            _storeContext = storeContext;
        }

        [HttpGet ("notfound")]
        public ActionResult GetNotFoundRequest () {
            var req = _storeContext.Products.Find (42);
            if (req == null) {
                return NotFound (new ApiResponse (404));
            }
            return Ok ();
        }

        [HttpGet ("servererror")]
        public ActionResult GetServerError () {
            var req = _storeContext.Products.Find (42);
            var ret = req.ToString ();
            return Ok ();
        }

        [HttpGet ("badrequest")]
        public ActionResult GetBadRequest () {

            return BadRequest (new ApiResponse (400));
        }

        [HttpGet ("badrequest/{id}")]
        public ActionResult GetNotFoundRequest (int id) {
            return Ok ();
        }
    }
}