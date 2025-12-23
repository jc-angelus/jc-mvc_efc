using TestApp.Application.Interfaces;
using TestApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestApp.Presentation.Controllers
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 02/02/2025
    /// Class: ClientsController
    /// </summary>

    [Authorize]
    public class ClientsController : Controller
    {
               
        public readonly IClientsServices _clientsServices;
        public readonly IGendersServices _genderServices;
        public readonly IMaritalStatusServices _maritalStatusServices;

        public ClientsController(IClientsServices clientsServices, IGendersServices genderServices, IMaritalStatusServices maritalStatusServices)
        {
            _clientsServices = clientsServices;
            _genderServices = genderServices;
            _maritalStatusServices = maritalStatusServices;
        }

        public IActionResult Index()
        {
          
            var seveclie = new DashboardModel
            {
                ClientsList = _clientsServices.ClientsList().Result,
                BirthDate = DateTime.Now,
                SelectListGenders = new DynamicListModel() { List = GenderList() },
                SelectListMaritalStatus = new DynamicListModel() { List = MaritalStatusList() }
            };                                         
            

            ViewBag.BreadCrumbFirstItem = "Test App";
            ViewBag.BreadCrumbSecondItem = "Clients List";
            return View(seveclie);           
            
        }

        public IActionResult Create()
        {
            var clientsModel = new ClientsModel();
            clientsModel.GendersId = 0;
            clientsModel.MaritalStatusId = 0;
            clientsModel.BirthDate = DateTime.Now;
            clientsModel = SetObjectdata(clientsModel);
            ViewBag.BreadCrumbFirstItem = "Test App";
            ViewBag.BreadCrumbSecondItem = "Clients Create";            
            return View(clientsModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClientsModel clientsModel)
        {
            ModelState.Remove("SelectListGenders");
            ModelState.Remove("SelectListMaritalStatus");            

            if (clientsModel.BirthDate > DateTime.Now)
            {
                ModelState.AddModelError("Fecha_Nac", "La fecha de nacimiento no puede ser mayor a la fecha actual, por favor verifique");
                return View("Create", clientsModel);
            }

            if (!ModelState.IsValid)
            {               
                return View("Create", clientsModel);
            }

            var seveclieCreate = _clientsServices.ClientsCreate(clientsModel).Result;

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var clientsModel = _clientsServices.ClientsRead(id).Result;
            clientsModel = SetObjectdata(clientsModel);
            ViewBag.BreadCrumbFirstItem = "Test App";
            ViewBag.BreadCrumbSecondItem = "Client Detail";            
            return View(clientsModel);
        }

        public IActionResult Edit(int id)
        {
            var clientsModel = _clientsServices.ClientsRead(id).Result;
            clientsModel = SetObjectdata(clientsModel);
            ViewBag.BreadCrumbFirstItem = "Test App";
            ViewBag.BreadCrumbSecondItem = "Client Edit";
            return View(clientsModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClientsModel clientsModel)
        {

            ModelState.Remove("SelectListGenders");
            ModelState.Remove("SelectListMaritalStatus");

            if (clientsModel.BirthDate > DateTime.Now)
            {
                ModelState.AddModelError("Fecha_Nac", "La fecha de nacimiento no puede ser mayor a la fecha actual, por favor verifique");
                return View("Edit", clientsModel);
            }

            if (!ModelState.IsValid)
            {
                return View("Edit", clientsModel);
            }

            var seveclieUpdate = _clientsServices.ClientsUpdate(clientsModel).Result;

            return RedirectToAction("Index");
        }

        
        public JsonResult Delete(int id)
        {

            var seveclieUpdate = _clientsServices.ClientsDelete(id).Result;

            return Json(new { status = "Success" });

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filter(ClientsModel clientsModel)
        {

            var clientsModelList = _clientsServices.ClientsList().Result;

            if (clientsModelList.Any()){

                if (clientsModel.DocumentId > 0)
                {
                    clientsModelList = clientsModelList.Where(x => x.DocumentId.ToString().Contains(clientsModel.DocumentId.ToString())).ToList();
                }

                if (!string.IsNullOrEmpty(clientsModel.Name))
                {
                    clientsModelList = clientsModelList.Where(x => x.Name.ToString().Contains(clientsModel.Name.ToString())).ToList();
                }

                if (clientsModel.GendersId > 0)
                {
                    clientsModelList = clientsModelList.Where(x => x.GendersId == clientsModel.GendersId).ToList();
                }

                if (clientsModel.BirthDate.Date < DateTime.Now.Date)
                {
                    clientsModelList = clientsModelList.Where(x => x.BirthDate == clientsModel.BirthDate).ToList();
                }

                if (clientsModel.MaritalStatusId > 0)
                {
                    clientsModelList = clientsModelList.Where(x => x.MaritalStatusId == clientsModel.MaritalStatusId).ToList();
                }

            }            

            var seveclie = new DashboardModel
            {                
                BirthDate = DateTime.Now,
                SelectListGenders = new DynamicListModel() { List = GenderList() },
                SelectListMaritalStatus = new DynamicListModel() { List = MaritalStatusList() },
                ClientsList = clientsModelList
            };            

            return View("Index", seveclie);
        }

        public IActionResult FilterClear()
        {
            return RedirectToAction("Index");
        }

        private IEnumerable<SelectListItem> GenderList()
        {

            var items = new List<SelectListItem>();

            var genderList = _genderServices.GenderList().Result;

            items.AddRange(genderList.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = Convert.ToString(p.Id),
                Selected = false
            }));

            items.Insert(0, new SelectListItem() { Text = "Select", Selected = true });

            return items;

        }

        private IEnumerable<SelectListItem> MaritalStatusList()
        {

            var items = new List<SelectListItem>();

            var civilStatusList = _maritalStatusServices.MaritalStatusList().Result;

            items.AddRange(civilStatusList.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = Convert.ToString(p.Id),
                Selected = false
            }));

            items.Insert(0, new SelectListItem() { Text = "Select", Selected = true });

            return items;

        }

        private ClientsModel SetObjectdata(ClientsModel clientsModel)
        {
            clientsModel.SelectListGenders = new DynamicListModel() { List = GenderList() };
            clientsModel.SelectListMaritalStatus = new DynamicListModel() { List = MaritalStatusList() };
            return clientsModel;
        }
    }
}
