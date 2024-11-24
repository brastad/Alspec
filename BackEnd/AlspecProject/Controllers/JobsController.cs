using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alspec.DataAccess.Data.Repository.IRepository;
using Alspec.Models.Entities;
using Alspec.Models.Entities.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlspecProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public JobsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet(Name = "api/jobs")]

        public IActionResult Get()
        {
            return Json(_unitOfWork.Job.GetAll(x => x.Include(x => x.SubItems)) );
        }
       
               

        
        [HttpDelete(Name = "api/Jobs/{Id}")]

        public IActionResult Delete(string Id)
        {
           _unitOfWork.Job.Remove(Id);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleted" });
        }

        [HttpPost(Name = "api/Jobs/")]
        public IActionResult AddNewJob(JobCreateDTO jobDTO)
        {
            Job job = new()
            {
                Id = jobDTO.Id,
                Title = jobDTO.Title,
                Description = jobDTO.Description,

            };
            _unitOfWork.Job.Add(job);

            _unitOfWork.Save();
            return Json(new { success = true, message = "Added" });

        }


        [HttpPut(Name = "api/Jobs/")]
        public IActionResult UpdateJob(Job job)
        {
            _unitOfWork.Job.Update(job);

            _unitOfWork.Save();
            return Json(new { success = true, message = "Updated" });

        }

    }
}

