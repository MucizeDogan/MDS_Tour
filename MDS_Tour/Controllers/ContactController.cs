﻿using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DataTrabsferObjects.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;
        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;   
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessageDto model)
        {
            if(ModelState.IsValid)
            {
                _contactUsService.Tadd(new ContactUs()
                {
                    MessageBody = model.MessageBody,
                    Mail=model.Mail,
                    Name=model.Name,
                    Status=true,
                    Subject=model.Subject,
                    MessageDate=Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index", "Default"); 
            }
            return View();
        }
    }
}
