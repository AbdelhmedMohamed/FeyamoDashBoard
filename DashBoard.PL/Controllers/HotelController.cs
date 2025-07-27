using AutoMapper;
using DashBoard.PL.Helpers;
using DashBoard.PL.ViewModels;
using Feyamo.BLL.Interfacies;
using Feyamo.BLL.Repositories;
using Feyamo.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using Microsoft.AspNetCore.Authorization;


namespace DashBoard.PL.Controllers
{
    [Authorize]
    public class HotelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        public IActionResult Index()
        {
            
            var hotels = _unitOfWork.HotelRepository.GetAll();

            var mappedHotle = _mapper.Map<IEnumerable<Hotel>,IEnumerable<HotelViewModel>>(hotels);

            return View(mappedHotle);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HotelViewModel hotelVM, List<IFormFile> ImagesName)
        {
            if (ModelState.IsValid)
            {


                var mappedHotle = _mapper.Map<HotelViewModel, Hotel>(hotelVM);
                _unitOfWork.HotelRepository.Add(mappedHotle);
                  var count =  _unitOfWork.Complete();               

                if (ImagesName.Count > 0)
                {
                    foreach (var item in ImagesName)
                    {
                       var fileName = DocumentSettings.UploadFile(item, "HotelImages");

                        var hotelImage = new HotelImages
                        {
                            HotelId = mappedHotle.Id,
                            ImageName = fileName,
                        };

                        _unitOfWork.hotelImages.Add(hotelImage);

                         count = _unitOfWork.Complete();
                    }
                }
                
                if (count > 0)
                {
                    TempData["Message"] = "Hotel Create Succeflly";

                    return RedirectToAction(nameof(Index));
                }

            }
            return View(hotelVM);         
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
           var hotel = _unitOfWork.HotelRepository.GetById(id);
            var mappedHotle = _mapper.Map<Hotel,HotelViewModel>(hotel);

            if (hotel == null)
            {
                return NotFound();
            }
            return View(mappedHotle);
        }


        [HttpPost]
        public IActionResult Edit(HotelViewModel hotelVM , List<IFormFile> ImagesName)
        {
            if (ModelState.IsValid)
            {
                var mappedHotle = _mapper.Map<HotelViewModel, Hotel>(hotelVM);
                _unitOfWork.HotelRepository.Update(mappedHotle);
                

                var count = _unitOfWork.Complete();

                if (ImagesName.Count > 0)
                {
                    foreach (var item in ImagesName)
                    {
                        var fileName = DocumentSettings.UploadFile(item, "HotelImages");

                        var hotelImage = new HotelImages
                        {
                            HotelId = mappedHotle.Id,
                            ImageName = fileName,
                        };
                       
                        _unitOfWork.hotelImages.Update(hotelImage);
                       
                        count += _unitOfWork.Complete();
                    }
                }


                if (count > 0)
                {
                    TempData["Message"] = "Hotel Updete Succeflly";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(hotelVM);

        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var hotel = _unitOfWork.HotelRepository.GetByIdWithImages(id);  

            if (hotel == null)
            {
                return NotFound();
            }

           
            if (hotel.Images != null && hotel.Images.Any())
            {
                foreach (var image in hotel.Images)
                {
                    DocumentSettings.DeleteFile(image.ImageName, "HotelImages"); 
                }
            }

            
            _unitOfWork.HotelRepository.Delete(hotel);

            var count = _unitOfWork.Complete();

            if (count > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }






    }
}
