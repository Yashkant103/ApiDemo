using ApiDemo.BAL;
using ApiDemo.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            User_BALBase bal = new User_BALBase();
            List<UserModel> users = bal.PR_SELECT_ALL_USER();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (users.Count > 0 && users != null)
            {
                response.Add("status", true);
                response.Add("message", "data found.");
                response.Add("data", users);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data not Found.");
                response.Add("data", null);
                return NotFound(response);
            }

        }
        [HttpGet("{User_ID}")]
        public IActionResult Get(int User_ID)
        {
            User_BALBase bal = new User_BALBase();
            UserModel userModel = bal.PR_SELECT_BY_PK_USER(User_ID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (userModel.User_ID != null)
            {
                response.Add("status", true);
                response.Add("message", "data found.");
                response.Add("data", userModel);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int User_ID)
        {
            User_BALBase bal = new User_BALBase();
            bool IsSuccess = bal.PR_DELETE_USER(User_ID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data deleted.");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data not Found.");
                return NotFound(response);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] UserModel userModel)
        {
            User_BALBase bal = new User_BALBase();
            bool IsSuccess = bal.PR_INSERT_USER(userModel);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data inserted Successfully.");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data not Found.");
                return NotFound(response);
            }
        }
        [HttpPut]
        public IActionResult Put(int User_ID, [FromBody] UserModel userModel)
        {
            User_BALBase bal = new User_BALBase();
            userModel.User_ID = User_ID;
            bool IsSuccess = bal.PR_UPDATE_USER(User_ID, userModel);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data updated Successfully.");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data not Found.");
                return NotFound(response);
            }
        }
    }
}