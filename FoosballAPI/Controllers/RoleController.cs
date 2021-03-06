﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoosballAPI.Data;
using FoosballAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace FoosballAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ApiContext _context;

        public RoleController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Role
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        // GET: api/Role/{roleID}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

    }
}
