using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebApplicationUsers.Models;
using WebApplicationUsers.Tests;
using WebApplicationUsers.Util;
using WebApplicationUsers.ViewModel;

namespace WebApplicationUsers.Controllers
{

    public class UserController : ApiController
    {

        public static List<UsersSignupModel> listUsers = new List<UsersSignupModel>();

        protected IHttpActionResult CustomResult(HttpStatusCode code, object data)
        {
            // Request here is the property on the controller.
            return new HttpActionResult(Request, code, data);
        }

        [HttpPost]
        [Route("User/Signup")]
        public IHttpActionResult SignupUsers(UsersSignupModel user)
        {
            try
            {
                if (String.IsNullOrEmpty(user.FirstName) || String.IsNullOrEmpty(user.LastName) ||
                    String.IsNullOrEmpty(user.Email) || String.IsNullOrEmpty(user.Password))
                {                  

                    string messageError = "Missing fields";
                    return CustomResult(HttpStatusCode.BadRequest, new
                            {
                                message = messageError,
                                errorCode = 400
                            });
                }

                UsersSignupModel usersEmail = null;
                usersEmail = listUsers.Where(p => p.Email == user.Email).Select(p => p).FirstOrDefault();

                if (usersEmail != null)
                {
                    string messageError = "E-mail already exists";
                    return CustomResult(HttpStatusCode.BadRequest, new
                    {
                        message = messageError,
                        errorCode = 400
                    });
                }

                if (!IsValid.IsValidEmail(user.Email))
                {
                    string messageError = "Invalid fields";
                    return CustomResult(HttpStatusCode.BadRequest, new
                    {
                        message = messageError,
                        errorCode = 400
                    });
                }

                var userNumber = user.Phones.Select(q => q.Number).FirstOrDefault();               

                if (!IsValid.IsInteger(userNumber.ToString()))
                {
                    string messageError = "Invalid fields";
                    return CustomResult(HttpStatusCode.BadRequest, new
                    {
                        message = messageError,
                        errorCode = 400
                    });
                }


                user.created_at = DateTime.Now;
                listUsers.Add(user);
                string messageOK = "Subscribed User";
                return CustomResult(HttpStatusCode.OK, new
                {
                    message = messageOK,
                    
                });
            }
            catch (Exception)
            {
                string messageError = "Invalid fields";
                return CustomResult(HttpStatusCode.ExpectationFailed, new
                {
                    message = messageError,
                    errorCode = 417
                });
            }

        }

        [Authorize]
        [HttpGet]
        [Route("User/Me")]
        public IHttpActionResult Users()
        {
            try
            {

              
                List<UsersSignupViewModel> usersSignupView = new List<UsersSignupViewModel>();

                foreach (var list in listUsers)
                {
                    UsersSignupViewModel user = new UsersSignupViewModel();

                    user.FirstName = list.FirstName;
                    user.LastName = list.LastName;
                    user.Email = list.Email;
                    user.Phones = list.Phones;
                    user.created_at = list.created_at;
                    user.last_login = list.last_login;


                    usersSignupView.Add(user);
                }

                if(usersSignupView.Count > 0)
                {                    
                    string messageOK = "Sucesse";
                    return CustomResult(HttpStatusCode.OK, new
                      {
                         message = messageOK,
                         userData = usersSignupView,

                       });                    

                }

                string messageError = "Missing fields";
                return CustomResult(HttpStatusCode.BadRequest, new
                {
                    message = messageError,
                    errorCode = 400
                });

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        [Route("User/Signin")]
        public IHttpActionResult SigninUser([FromBody] UserSigninModel userSignin)
        {
            UsersSignupModel users = new UsersSignupModel();
            UserSigninModel userSigninModel = new UserSigninModel();

            if (String.IsNullOrEmpty(userSignin.Email) || String.IsNullOrEmpty(userSignin.Password))
            {

                string messageError = "Missing fields";
                return CustomResult(HttpStatusCode.BadRequest, new
                {
                    message = messageError,
                    errorCode = 400
                });
            }
                       
            if (!IsValid.IsValidEmail(userSignin.Email))
            {
                string messageError = "Invalid fields";
                return CustomResult(HttpStatusCode.BadRequest, new
                {
                    message = messageError,
                    errorCode = 400
                });
            }

            //Find User
            try
            {
                users = listUsers.Where(p => p.Email == userSignin.Email && p.Password == userSignin.Password
                ).Select(p => p).FirstOrDefault();

                if (users != null)
                {
                    userSigninModel.FirstName = users.FirstName;
                    userSigninModel.LastName = users.LastName;
                    userSigninModel.Email = users.Email;
                    userSigninModel.Phones = users.Phones;                    
                    users.last_login = DateTime.Now;
                    userSigninModel.last_login = users.last_login;                    
                    listUsers.Add(users);

                    string messageOK = "Sucesse";
                    return CustomResult(HttpStatusCode.OK, new
                    {
                        message = messageOK,
                        userData = userSigninModel

                    });
                }
                else
                {
                    string messageError = "Invalid e-mail or password";
                    return CustomResult(HttpStatusCode.BadRequest, new
                    {
                        message = messageError,
                        errorCode = 400
                    });
                }

            }
            catch (Exception)
            {
                string messageError = "Invalid fields";
                return CustomResult(HttpStatusCode.ExpectationFailed, new
                {
                    message = messageError,
                    errorCode = 417
                });
            }
        }


        public static bool Login(string email, string password)
        {

            List<UsersSignupModel> list = listUsers;
            return listUsers.Any(user =>
            user.Email == email
                && user.Password == password);
        }

    }
}
