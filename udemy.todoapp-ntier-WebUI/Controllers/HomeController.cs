using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using udemy.todoapp_ntier_Business.Services.Abstract;
using udemy.todoapp_ntier_Common.ResponseObjects.Concrete;
using udemy.todoapp_ntier_DTO.WorkDTOs;
using udemy.todoapp_ntier_WebUI.Extensions;

namespace udemy.todoapp_ntier_WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _workService;

        public HomeController(IWorkService workService)
        {
            _workService = workService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _workService.GetAll();
            return View(response.Data);
        }

        public IActionResult Create()
        {
            return View(new WorkCreateDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDTO dTO)
        {
            var response = await _workService.Create(dTO);
            return this.ResponseRedirectToAction(response, "Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _workService.GetByID<WorkUpdateDTO>(id);
            return this.ResponseView(response); 
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDTO dTO)
        {
           
            var response = await _workService.Update(dTO);
            return this.ResponseRedirectToAction(response, "Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var response = await _workService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
        }

        public  IActionResult NotFound(int code)
        {
            return View();
        }
    }
}
