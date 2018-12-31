using FakeMobileCarrier.CallCenter.WebApp.Models.Home;
using FakeMobileCarrier.Model;
using System.Linq;
using System.Web.Mvc;

namespace FakeMobileCarrier.CallCenter.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFakeMobileCarrierDbContext _context;

        public HomeController(IFakeMobileCarrierDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var searchModel = new _HomeSearchUserModel();

            return Index(searchModel);
        }

        [HttpPost]
        public ActionResult Index(_HomeSearchUserModel searchModel)
        {
            var model = new HomeModel();

            model.SearchUserModel = searchModel;
            model.UserListModel.Users = _context.Users
                .Where(user => user.FirstName == searchModel.FirstName)
                .Where(user => user.LastName == searchModel.LastName)
                .Where(user => user.PhoneNumber == searchModel.PhoneNumber)
                .Select(user => new _HomeUserModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    PESEL = user.Pesel
                })
                .ToList();

            return View("HomeView", model);
        }
    }
}