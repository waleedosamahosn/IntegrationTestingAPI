using BusinessServices.InterfacesViewModel;
using BusinessServices.ModelDb;
using BusinessServices.ViewModel;
using DataLayer.RepositoryAction;
using Microsoft.AspNetCore.Mvc;

namespace WindowsFormsAppProject.Controllers
{
    public class ProjectActionParametersQueryController : Controller
    {
        private readonly IProjectActionParameterOperation<ProjectActionParameter> _projectActionParameterOperation;

        public ProjectActionParametersQueryController(
            IProjectActionParameterOperation<ProjectActionParameter> projectActionParameterOperation)
        {
            _projectActionParameterOperation = projectActionParameterOperation;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _projectActionParameterOperation.GetAllData();
            return View(results);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await Task.Delay(2000);
            ProjectActionParameter projectActionParameter = new ProjectActionParameter();
            return PartialView("_ProjectParameterModelCreatePartial", projectActionParameter);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectActionParameterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _projectActionParameterOperation.Create(model);

            return PartialView("_ProjectParameterModelCreatePartial", model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var results = await _projectActionParameterOperation.GetDataUpdate(id);
            return PartialView("_ProjectParameterModelEditPartial", results);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProjectActionParameterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _projectActionParameterOperation.Update(model);
            return PartialView("_ProjectParameterModelEditPartial", model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _projectActionParameterOperation.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetIdData(int id)
        {
            var result = await _projectActionParameterOperation.SelectById(id);

            if (result == null)
            {
                return NotFound();
            }
            return View(nameof(Index), result);
        }

    }
}
