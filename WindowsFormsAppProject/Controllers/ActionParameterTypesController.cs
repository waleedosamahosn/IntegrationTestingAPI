using BusinessServices.InterfacesViewModel;
using BusinessServices.ModelDb;
using BusinessServices.ViewModel;
using DataLayer.RepositoryAction;
using Microsoft.AspNetCore.Mvc;

namespace WindowsFormsAppProject.Controllers
{
    
    public class ActionParameterTypesController : Controller
    {
        private readonly IActionParameterType<ActionParameterType> _actionParameterType;

        public ActionParameterTypesController(IActionParameterType<ActionParameterType> actionParameterType)
        {
            _actionParameterType = actionParameterType;
        }

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var result = await _actionParameterType.GetAllTypeAsyncData();
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            await Task.Delay(2000);
            return PartialView("_ActionParameterTypeCreatePartial");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActionParameterTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await Task.Delay(2000);

            var results = _actionParameterType.Create(model);

            if (results is null)
            {
                return NotFound();
            }

            return PartialView("_ActionParameterTypeCreatePartial", model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var results = await _actionParameterType.GetDataEditActionParamatertype(id);
            return PartialView("_ActionparameterTypeModelEditPartial", results);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ActionParameterTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _actionParameterType.Update(model);

            return PartialView("_ActionparameterTypeModelEditPartial", model);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _actionParameterType.Delete(id);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetDataById(int id)
        {
            var result = await _actionParameterType.GetDataEditActionParamatertype(id);

            if (result == null)
            {
                return NotFound();
            }
            return View(nameof(Index), result);
        }



    }
}
