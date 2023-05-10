using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendResetPasswordEmail(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a new instance of LoginViewModel and set its RecipientEmail property to the email entered by the user
                LoginViewModel loginViewModel = new LoginViewModel
                {
                    RecipientEmail = model.RecipientEmail
                };

                // Call the PassReset method of the LoginViewModel instance and pass the email as a parameter
                loginViewModel.PassReset(loginViewModel.RecipientEmail);

                // Return a success message to the client
                return Ok("Email sent successfully");
            }

            // Return a bad request response if the model state is invalid
            return BadRequest(ModelState);
        }

    }
}
