using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Online_razmjena.Data;
using Online_razmjena.Data.FileManager;
using Online_razmjena.Models;
using Online_razmjena.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Online_razmjena.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IPostRepository _repo;
        private IFileManager _fileManager;

        public HomeController(ILogger<HomeController> logger, IPostRepository repo, IFileManager fileManager)
        {
            _logger = logger;
            _repo = repo;
            _fileManager = fileManager;
        }

        public IActionResult Index()
        {
            var posts = _repo.GetAllPosts();
            return View(posts);
        }
        public IActionResult Post(int id)
        {
            var post = _repo.GetPost(id);
            return View(post);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new PostViewModel());
            }
            else
            {
                var post = _repo.GetPost((int)id);
                return View(new PostViewModel
                {
                    Id=post.Id,
                    Naziv=post.Naziv,
                    Tip=post.Tip,
                    Opis=post.Opis,
                    Korisnik=post.Korisnik
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            var post = new Post
            {
                Id = vm.Id,
                Naziv = vm.Naziv,
                Tip = vm.Tip,
                Opis = vm.Opis,
                Korisnik = vm.Korisnik,
                Image = await _fileManager.SaveImage(vm.Image)
            };
            if (post.Id > 0)
            {
                _repo.UpdatePost(post);
            }
            else
            {
                _repo.AddPost(post);
            }
                if (await _repo.SaveChangesAsync())
                    return RedirectToAction("Index");
                else
                    return View(post);
            
        }
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePost(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet("/Image/{image}")]
        public IActionResult image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
