using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using udemy.todoapp_ntier_Business.Services.Abstract;
using udemy.todoapp_ntier_DTO.WorkDTOs;

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
            var workList = await _workService.GetAll();
            return View(workList);
        }

        public IActionResult Create()
        {
            return View(new WorkCreateDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDTO dTO)
        {
            if( ModelState.IsValid )
            {
                await _workService.Create(dTO);
                return RedirectToAction("Index");
            }            
            return View(dTO);
        }

        public async Task<IActionResult> Update(int id)
        {
            var dto = await _workService.GetByID(id);
            
            return View(new WorkUpdateDTO
            {
                ID = dto.ID,
                Definition = dto.Definition,
                IsCompleted = dto.IsCompleted,
            });   
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDTO dTO)
        {
            if(ModelState.IsValid)
            {
                await _workService.Update(dTO);
                return RedirectToAction("Index");
            }
            return View(dTO);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _workService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
