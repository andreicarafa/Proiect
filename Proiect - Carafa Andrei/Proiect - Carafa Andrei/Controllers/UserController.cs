using Microsoft.AspNetCore.Mvc;
using Proiect___Carafa_Andrei.ViewModels;

namespace Proiect___Carafa_Andrei.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            UserModel userModel = new UserModel();
            return View(userModel) ;
        }
        public IActionResult GenerareParola(int id)
        {
            Random rand = new Random();
            UserModel userModel = new UserModel();
            userModel.userId = (int)id;
            userModel.password = (rand.Next(100000, 999999)).ToString();
            userModel.isPassword = true;
            userModel.date = DateTime.Now;
            userModel.dateExpired = userModel.date.AddSeconds(30);
            
            return View(userModel);
        }

        [HttpGet]

        public IActionResult SubmitParola(UserModel userModel)
        {
            if (userModel.passwordSubmit == null)
                userModel.message = "Nici un continut";
            else if ((DateTime.Now - userModel.date).TotalSeconds > 30)
            {
                userModel.message = "Parola expirata";
               
            }
            else if (userModel.password != userModel.passwordSubmit)
            {
                userModel.message = "Introduceti o parola valida";
                
            }
            else
            {
                userModel.message = "Parola valida ";
            }
            return View(userModel);
        }
    }
}
