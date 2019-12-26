using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OA.Service;
using OA.Web.ViewModel;
using AutoMapper;
using OA.Data;

namespace OA.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
         
        public UserController( IUserService userService)
        {
            this.userService = userService;        
        }
        public IActionResult Index()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserViewModel,User >();
            });
            IMapper iMapper = config.CreateMapper();
            var user = userService.GetUsers();
            var userViewModels = iMapper.Map<IEnumerable<UserViewModel>>(user);
            return View(userViewModels); 
        }

    }
}