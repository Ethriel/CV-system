﻿using API_Real_Base_Test_Own_Context.Contexts;
using API_Real_Base_Test_Own_Context.Helpers;
using API_Real_Base_Test_Own_Context.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Real_Base_Test_Own_Context.Controllers
{
    [Route("api/getHobbies")]
    [ApiController]
    public class HobbiesController
    {
        [HttpGet]
        public ActionResult<IEnumerable<Hobbies>> Get()
        {
            using (HobbiesContext db = new HobbiesContext(OptionsHelper<HobbiesContext>.GetOptions()))
            {
                var hobbies = db.Hobbies.ToList();
                return hobbies;
            }
        }
    }
}
