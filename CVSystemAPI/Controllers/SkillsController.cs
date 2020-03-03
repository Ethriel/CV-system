﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVSystemAPI.Helpers;
using CVSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CVSystemAPI.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : Controller
    {
        ControllerHelper ch = new ControllerHelper();

        [HttpGet("get")]
        public IActionResult Get()
        {
            using (CVContext db = new CVContext(OptionsHelper<CVContext>.GetOptions()))
            {
                var skills = db.Skills.ToList();
                return ch.GetResultForGET(skills);
            }
        }
        [HttpGet("get/person/{personId}")]
        public IActionResult GetSkillsByPersonId(int personId)
        {
            using (CVContext db = new CVContext(OptionsHelper<CVContext>.GetOptions()))
            {
                var skills = db.Skills.Include(s => s.PersonSoftwareSkill).Where(x => x.PersonSoftwareSkill.Where(y => y.PersonalDataId == personId).Any()).ToList();
                return ch.GetResultForGET(skills);
            }
        }
        [HttpGet("get/person/{firstName}&{lastName}")]
        public IActionResult GetSkillsByPersonFullName(string firstName, string lastName)
        {
            using (CVContext db = new CVContext(OptionsHelper<CVContext>.GetOptions()))
            {
                var skills = db.Skills.Include(s => s.PersonSoftwareSkill).Where(
                    x => x.PersonSoftwareSkill.Where(
                    y => y.PersonalData.FirstName.ToLower().Equals(firstName.ToLower()) && y.PersonalData.LastName.ToLower().Equals(lastName.ToLower()))
                    .Any()).ToList();
                return ch.GetResultForGET(skills);
            }
        }
    }
}
