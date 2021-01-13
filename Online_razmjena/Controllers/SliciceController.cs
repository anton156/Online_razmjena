using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_razmjena.Models;
using Online_razmjena.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Online_razmjena.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Online_razmjena.Controllers
{
    public class SliciceController : Controller
    {
        
        private readonly ISliciceRepository _sliciceRepository = null;
        private readonly ZamjenaRepository _zamjenaRepository = null;
        private readonly AlbumRepository _albumRepository = null;
        private readonly ApplicationDbContext _context = null;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SliciceController(ISliciceRepository sliciceRepository,
            IWebHostEnvironment webHostEnvironment, ApplicationDbContext context,ZamjenaRepository zamjenaRepository, AlbumRepository albumRepository)
        {
            _zamjenaRepository = zamjenaRepository;
            _albumRepository = albumRepository;
            _context = context;
            _sliciceRepository = sliciceRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        
        public async Task<ViewResult> Index(string search)
        {
            var data = await _sliciceRepository.Index(search);

            return View(data);
        }
        [Authorize]
        public async Task<ViewResult> MySlicice(string search)
        {
            var data = await _sliciceRepository.Index(search);

            return View(data);
        }

        [Route("slicice-details/{id:int:min(1)}", Name = "Details")]
        public async Task<ViewResult> Details(int id)
        {
            var data = await _sliciceRepository.GetSliciceById(id);

            return View(data);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var slicica = await _context.Slicice.FindAsync(id);
            _context.Slicice.Remove(slicica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MySlicice));
        }

        public List<SliciceModel> SearchSlicice(string sliciceNaziv)
        {
            return _sliciceRepository.SearchSlicice(sliciceNaziv);
        }

        [Authorize]
        public async Task<ViewResult> Create(bool isSuccess = false, int sliciceId = 0)
        {
            
            var model = new SliciceModel();
            ViewBag.Albumi = new SelectList( await _albumRepository.GetAlbum(), "AlbumId","Naziv");
            ViewBag.Zamjene = new SelectList( await _zamjenaRepository.GetZamjena(), "ZamjenaId","Nacin");
            ViewBag.IsSuccess = isSuccess;
            ViewBag.SliciceId = sliciceId;
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(SliciceModel sliciceModel)
        {
            if (ModelState.IsValid)
            {
                if (sliciceModel.CoverPhoto != null)
                {
                    string folder = "slicice/cover/";
                    sliciceModel.CoverImageUrl = await UploadImage(folder, sliciceModel.CoverPhoto);
                }

                if (sliciceModel.GalleryFiles != null)
                {
                    string folder = "slicice/gallery/";

                    sliciceModel.Gallery = new List<GalleryModel>();

                    foreach (var file in sliciceModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Naziv = file.FileName,
                            URL = await UploadImage(folder, file)
                        };
                        sliciceModel.Gallery.Add(gallery);
                    }
                }
                int id = await _sliciceRepository.Create(sliciceModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(Index), new { isSuccess = true, sliciceId = id });
                }
            }

            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}

