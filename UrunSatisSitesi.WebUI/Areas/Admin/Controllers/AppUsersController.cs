using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrunSatisSitesi.Entities;
using UrunSatisSitesi.Service.Repositories;

namespace UrunSatisSitesi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUsersController : Controller
    {
        // GET: AppUsersController
        private readonly IRepository<AppUser> _repository; // DI-Dependency injection yöntemiyle

        public AppUsersController(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        // GET: AppUsersController
        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: AppUsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AppUsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppUsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.AddAsync(appUser);
                    await _repository.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(appUser);
        }

        // GET: AppUsersController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var kayit = await _repository.FindAsync(id);

            if (kayit == null) return NotFound();

            return View(kayit);
        }

        // POST: AppUsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(appUser);
                    await _repository.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(appUser);
        }

        // GET: AppUsersController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var kayit = await _repository.FindAsync(id);

            if (kayit == null) return NotFound();

            return View(kayit);
        }

        // POST: AppUsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AppUser appUser)
        {
            try
            {
                _repository.Delete(appUser);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
