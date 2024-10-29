using BusinessServices.InterfacesViewModel;
using BusinessServices.ModelDb;
using BusinessServices.ViewModel;
using DataLayer.RepositoryAction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WindowsFormsAppProject.Controllers
{
    public class ProjectActionOperationWebController : Controller
    {
        private readonly IProjectActionOperation<ProjectAction> _projectActionOperation;

        public ProjectActionOperationWebController(IProjectActionOperation<ProjectAction>
            projectActionOperation)
        {
            _projectActionOperation = projectActionOperation;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var results = await _projectActionOperation.GetAllProjectActionData();
            return View(results);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await Task.Delay(2000);
            return PartialView("_ProjectActionModelCreatePartial");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectActionViewModeltwo model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await Task.Delay(2000);

            var results = _projectActionOperation.Create(model);

            if (results is null)
            {
                return NotFound();
            }

            return PartialView("_ProjectActionModelCreatePartial", model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var results = await _projectActionOperation.GetDataEditProjectAction(id);
            return PartialView("_ProjectActionModelEditPartial", results);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProjectActionViewModeltwo model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _projectActionOperation.Update(model);

            return PartialView("_ProjectActionModelEditPartial", model);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _projectActionOperation.Delete(id);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetDataById(int id)
        {
            var result = await _projectActionOperation.GetProjectAcyionId(id);

            if (result == null)
            {
                return NotFound();
            }
            return View(nameof(Index), result);
        }

    }
}
