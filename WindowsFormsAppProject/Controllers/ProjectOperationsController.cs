using BusinessServices.InterfacesViewModel;
using BusinessServices.ModelDb;
using BusinessServices.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace WindowsFormsAppProject.Controllers
{
    public class ProjectOperationsController : Controller
    {
        private readonly IProjectOperation<Project> _projectOperation;

        private readonly IToastNotification _toastNotification;

        public ProjectOperationsController(IProjectOperation<Project> projectOperation,
            IToastNotification toastNotification)
        {
            _projectOperation = projectOperation;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _projectOperation.GetAllProjectAsync();
            return View(results);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await Task.Delay(2000);
            return PartialView("_ProjectModelPartial");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await Task.Delay(2000);

            var results = _projectOperation.CreateProject(model);

            if (results is null)
            {
                return NotFound();
            }

            _toastNotification.AddSuccessToastMessage("ok added");

            return PartialView("_ProjectModelPartial", model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var results = await _projectOperation.GetDataEditProject(id);
            return PartialView("_ProjectModelEditPartial", results);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProjectViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _projectOperation.Update(model);

            _toastNotification.AddSuccessToastMessage("ok edit");

            return PartialView("_ProjectModelEditPartial", model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _projectOperation.Delete(id);

            return Ok();
        }

    }
}
