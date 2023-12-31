﻿using Microsoft.AspNetCore.Mvc;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Role;

namespace ShoppingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private IRole role;
        private Response res;

        public RoleController(IRole _role)
        {
            role = _role;
            res = new Response();
        }

        [HttpGet]
        [Route("listRole")]
        public object Get()
        {
            res = role.GetsRole();
            return Ok(res);
        }

        [HttpPost]
        [Route("createRole")]
        public object CreateRole(CreateUpdateRoleViewModel model)
        {
            res = role.CreateRole(model);
            return Ok(res);
        }

        [HttpPost]
        [Route("updateRole")]
        public object UpdateRole(CreateUpdateRoleViewModel model)
        {
            res = role.UpdateRole(model);
            return Ok(res);
        }

        [HttpDelete]
        [Route("deleteRole")]
        public object DeleteRole(int idRole)
        {
            res = role.DeleteRole(idRole);
            return Ok(res);
        }
    }
}
