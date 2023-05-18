using BusinessLayer.Abstract.AbstractUoW;
using EntityLayer.Concrete;
using MDS_Tour.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


// SENARYOMUZ; bir banka havale(EFT) işlemi yapacağız. Örneğin Mucize Doğan Sarıkürkcü'nün hesabında 25.000 lira var ve İrem Salcı'ya (hesabında 10.000 lira var) 5.000 yollayacak. bu işemi gerçekleştireceğiz. Yani bir gönderici bir alıcı bir tutar ve bir göndericiYeniBakiye bir alıcıYeniBakiye propları olacak.


namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    [Authorize(Roles = "Admin")]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountModel model )
        {
            var dataSender=_accountService.TGetById(model.SenderId); //dataSender göndericinin id sine verileri getiricek.
            var dataReceiver = _accountService.TGetById(model.ReceiverId);

            List<Account> modifiedAccounts = new List<Account>()    // MultiUpdate yapabilmek için List şeklinde dönmem gerekir çünkü direkt model i yollayamam.
            {
                dataSender,     //Bu dataları bu aralıkta yazdığım zaman bunların değerleri bir liste değeri aolarak gelcek ve modifiedAccounts un içinde tutağım
                dataReceiver
            };

            dataSender.Balance -= model.Amount;     //DataSender ın bakiyesini model deki amount kadar azalt
            dataReceiver.Balance += model.Amount;   //Datareceiver ın bakiyesini model deki amount kadar arttır.

            _accountService.TMultiUpdate(modifiedAccounts);
             
            return View();
           
        }
    }
}
