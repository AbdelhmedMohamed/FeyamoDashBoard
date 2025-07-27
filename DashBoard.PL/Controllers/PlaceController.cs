using AutoMapper;
using DashBoard.PL.Helpers;
using DashBoard.PL.ViewModels;
using Feyamo.BLL.Interfacies;
using Feyamo.BLL.Repositories;
using Feyamo.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace DashBoard.PL.Controllers
{
    [Authorize]
    public class PlaceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlaceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            var Places = _unitOfWork.placeReopsitory.GetAll();

            var mappedHotle = _mapper.Map<IEnumerable<Place>, IEnumerable<PlaceViewModel>>(Places);

            return View(mappedHotle);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PlaceViewModel PlaceVM, List<IFormFile> ImagesName)
        {
            if (ModelState.IsValid)
            {


                var mappedPlace = _mapper.Map<PlaceViewModel, Place>(PlaceVM);
                _unitOfWork.placeReopsitory.Add(mappedPlace);
                var count = _unitOfWork.Complete();

                if (ImagesName.Count > 0)
                {
                    foreach (var item in ImagesName)
                    {
                        var fileName = DocumentSettings.UploadFile(item, "PlaceImages");

                        var placeImage = new PlaceImages
                        {
                           PlaceId = mappedPlace.Id ,
                            ImageName = fileName,
                        };


                        _unitOfWork.PlaceImages.Add(placeImage);

                        count = _unitOfWork.Complete();
                    }
                }

                if (count > 0)
                {
                    TempData["Message"] = "Place Create Succeflly";

                    return RedirectToAction(nameof(Index));
                }

            }
            return View(PlaceVM);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Place = _unitOfWork.placeReopsitory.GetById(id);
            var mappedPlace = _mapper.Map<Place, PlaceViewModel>(Place);

            if (Place == null)
            {
                return NotFound();
            }
            return View(mappedPlace);
        }


        [HttpPost]
        public IActionResult Edit(PlaceViewModel PlaceVM, List<IFormFile> ImagesName)
        {
            if (ModelState.IsValid)
            {
                var mappedPlace = _mapper.Map<PlaceViewModel, Place>(PlaceVM);
                _unitOfWork.placeReopsitory.Update(mappedPlace);


                var count = _unitOfWork.Complete();

                if (ImagesName.Count > 0)
                {
                    foreach (var item in ImagesName)
                    {
                        var fileName = DocumentSettings.UploadFile(item, "PlaceImages");

                        var PlaceImage = new PlaceImages
                        {
                            PlaceId = mappedPlace.Id,
                            ImageName = fileName,
                        };

                        _unitOfWork.PlaceImages.Update(PlaceImage);

                        count += _unitOfWork.Complete();
                    }
                }


                if (count > 0)
                {
                    TempData["Message"] = "Place Updete Succeflly";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(PlaceVM);

        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Place = _unitOfWork.placeReopsitory.GetByIdWithImages(id);

            if (Place == null)
            {
                return NotFound();
            }


            if (Place.Images != null && Place.Images.Any())
            {
                foreach (var image in Place.Images)
                {
                    DocumentSettings.DeleteFile(image.ImageName, "PlaceImages");
                }
            }

            _unitOfWork.placeReopsitory.Delete(Place);

            var count = _unitOfWork.Complete();

            if (count > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }






    }
}
