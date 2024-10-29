using BusinessServices.Dto;
using BusinessServices.ModelDb;
using BusinessServices.Services.Interfaces;
using BusinessServices.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Definition;
using System.Reflection;
using System.Text;
using WindowsFormsAppProject.Logic;
using static BusinessServices.ModelDb.ProjectAction;

namespace WindowsFormsAppProject.Controllers
{
    public class VerifysController : Controller
    {
        private readonly ILoginService _loginService;

        private readonly IVerifyAction<ProjectAction> _verifyAction;

        private readonly IVerifyAction<Project> _verifyActionProject;

        public VerifysController(ILoginService loginService, 
            IVerifyAction<ProjectAction> verifyAction,
            IVerifyAction<Project> verifyActionProject)
        {
            _loginService = loginService;
            _verifyAction = verifyAction;
            _verifyActionProject = verifyActionProject;
        }

        //get
        public async Task<IActionResult> Index()
        {
            var results = await _verifyAction.GetAllProjectAction(new[] {"Project"} );

            List<ProjectActionViewModel> projectActionViewModel =
                new List<ProjectActionViewModel>();

            foreach (ProjectAction item in results)
            {
                projectActionViewModel.Add(new ProjectActionViewModel
                {
                    Id = item.Id,
                    IsAuthorized = item.IsAuthorized,
                    MethodName = item.MethodName,
                    Name = item.Name,
                    ProjectId = item.ProjectId,
                    isChecked = item.isChecked,
                    ActionUrl = item.ActionUrl,
                    Baseurl = item.Project.BaseUrl, // Add null check here
                    Projects = await _verifyActionProject.GetAllProject(),
                });
            }

            return View(projectActionViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<ProjectActionViewModel> projectActionViewModels)
        {
            Dictionary<int, VerifyActionReponse> verifyResults =
            new Dictionary<int, VerifyActionReponse>();


            RequestDto req = new RequestDto
            {
                BaseUrl = projectActionViewModels[3].Baseurl,
                Url = projectActionViewModels[3].ActionUrl
            };
            var login = await _loginService.LoginData(req);

            foreach (var item in projectActionViewModels)
            {
                RequestDto requestDto = new RequestDto
                {
                    BaseUrl = item.Baseurl,
                    Url = item.ActionUrl,
                    Token = login.Token,
                    RefreshToken = login.RefreshToken  
                };
                if (item.isChecked)
                {
                    object[] parameters = new object[]
                        {
                            requestDto,
                        };
                    SericesCall sericesCall = new SericesCall();

                    Type t = sericesCall.GetType();

                    object obj = Activator.CreateInstance(t);

                    MethodInfo method = t.GetMethod(item.MethodName);

                    Task<VerifyActionReponse> result =
                    (Task<VerifyActionReponse>)method.Invoke(obj, parameters);

                    var respone = await result;

                    verifyResults.Add(item.Id, respone);
                }
            }
            return View("RespobeDataModel", verifyResults);

        }

    }
}