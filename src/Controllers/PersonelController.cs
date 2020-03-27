using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonelTakip.Controllers.Resources;
using PersonelTakip.Core;
using PersonelTakip.Core.Models;
using PersonelTakip.Services;
using OfficeOpenXml;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace PersonelTakip.Controllers
{
    [Route("[controller]")]    
    public class PersonelController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPersonelRepository personelRepository;
        private readonly IUnvanRepository unvanRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHostingEnvironment environment;

        public PersonelController(IMapper mapper, 
        IPersonelRepository personelRepository, 
        IUnvanRepository unvanRepository, 
        IUnitOfWork unitOfWork, 
        IHostingEnvironment environment)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.personelRepository = personelRepository;
            this.unvanRepository = unvanRepository;
            this.environment = environment;
        }


        [HttpPost]
        [Route("Sil/{id}")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili")]
        public async Task<IActionResult> PersonelDuzenle(long id)
        {
            var personel = await personelRepository.FindOneAsync(id);
            if (personel == null)
                return BadRequest();

            personelRepository.Delete(personel);            
            await unitOfWork.CompleteAsync();

            try
            {
                string root = environment.WebRootPath;
                string path = Path.Combine(root, "images");
                path = Path.Combine(path, "personel");
                path = Path.Combine(path, personel.Id.ToString());
                Directory.Delete(path, true);
            }
            catch (DirectoryNotFoundException) { }

            return Redirect("/Personel/Liste");
        }

        [HttpPost]
        [Route("TopluEkle")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili,Yetkili")]
        public async Task<IActionResult> TopluPersonelEkle(IFormFile excel)
        {
            var unvanlar = await unvanRepository.GetAllAsync();
            var personeller = personellerExcelOku(excel.OpenReadStream(), unvanlar);

            foreach (var personel in personeller)
            {
                var p= personelRepository.FindOneByTcNoAsync(personel.TcNo);
                if(p==null)
                await personelRepository.AddAsync(personel);
            }            
            await unitOfWork.CompleteAsync();

            return Redirect("/Personel/Liste");
        }

        [HttpGet]
        [Route("Ekle")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili,Yetkili")]
        public async Task<IActionResult> PersonelEkle()
        {           
            var unvanlar = await unvanRepository.GetAllAsync();
            ViewBag.UnvanSelectList = new SelectList(unvanlar,"Id", "UnvanAdi");
            ViewBag.KanGrubuSelectList = new SelectList(TableConstants.KanGruplari);

            return View();
        }



        [HttpPost]        
        [Route("Ekle")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili,Yetkili")]
        public async Task<IActionResult> PersonelEkle(PersonelEkleResource personelResource)
        {
            if (!ModelState.IsValid)
                return View(personelResource);

            var personel = mapper.Map<PersonelEkleResource, Personel>(personelResource);
            await personelRepository.AddAsync(personel);
            await unitOfWork.CompleteAsync();

            var photo = personelResource.PersonelFotgrafi;            
            string[] format = { "image/jpeg", "image/png" };
            if (photo != null && photo.Length <= 1000000 && format.Contains(photo.ContentType))
            {
                string root = environment.WebRootPath;
                string path = Path.Combine(root,"images");
                path = Path.Combine(path,"personel");
                Directory.CreateDirectory(path);
                path = Path.Combine(path,personel.Id.ToString());
                Directory.CreateDirectory(path);

                using (var stream = new FileStream(Path.Combine(path,"vesikalik.png"), FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }
            }           

            return Redirect("/Personel/Liste");

        }
        

        [HttpPost]
        [Route("Duzenle/{id}")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili,Yetkili")]
        public async Task<IActionResult> PersonelDuzenle(long id,[FromForm] PersonelDuzenleResource personelResource)
        {
            if (!ModelState.IsValid)
                return View(personelResource); 
           
            var personel = await personelRepository.FindOneAsync(id);
            if (personel == null)
                return BadRequest();

            mapper.Map<PersonelDuzenleResource, Personel>(personelResource,personel);
            personelRepository.Update(personel);
            await unitOfWork.CompleteAsync();

            var photo = personelResource.PersonelFotgrafi;
            string[] format = { "image/jpeg", "image/png" };
            if (photo != null && photo.Length <= 1000000 && format.Contains(photo.ContentType))
            {
                string root = environment.WebRootPath;
                string path = Path.Combine(root,"images");
                path = Path.Combine(path,"personel");
                Directory.CreateDirectory(path);
                path = Path.Combine(path,personel.Id.ToString());
                Directory.CreateDirectory(path);

                using (var stream = new FileStream(Path.Combine(path,"vesikalik.png"), FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }
                return Ok(new {  sonuc="Başarıyla kaydedildi" });

            }
            return Ok(new {sonuc ="Güncelleme yapıldı ama fotoğraf kaydedilemedi lütfen fotoğraf türünü ve boyutlarını kontrol ediniz"});
        }


        [HttpGet]
        [Route("Liste")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili,Yetkili,Kullanıcı")]
        public IActionResult PersonelListele()
        {
            return View();
        }


        [HttpPost]
        [Route("EmployeeList/{filter}")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili,Yetkili,Kullanıcı")]
        public async Task<IActionResult> PersonelListeleAsync(string filter, [FromBody]IQueryObject queryObject)
        {
            var today = DateTime.Today;
            var personelList = await personelRepository.GetsByQuery(queryObject, today.Year, today.Month, filter);
            
            
            
            var personelsJson = ConvertToJsonFormat(personelList.Items.ToList());
            personelsJson.uid = "Employee-List";
            personelsJson.perPage = 15;
            personelsJson.pageNo = 1;
            personelsJson.tableNo = TableConstants.EmployeeListTableNo;
           return Ok(personelsJson);
        }


        [HttpPost]        
        [Route("EmployeeListSummary/{filter}")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili,Yetkili,Kullanıcı")]
        public async Task<IActionResult> GorevOzeti(string filter)
        {
            var unvanlar = await unvanRepository.GetAllAsync();
            var employeeSummary = new EmployeeListSummaryResource("Employee-List-Summary", 5, unvanlar);

            var today = DateTime.Today;
            var gorevOzeti = await personelRepository.GorevOzetleriGetir(today.Year, today.Month, filter);
            var row = new EmployeeListSummaryResource.Row("Toplam");
            var toplam = new EmployeeListSummaryResource.Row.Column();
            toplam.uid = "Toplam";
            toplam.type = "num";
            toplam.value = 0;
            //görev özeti key value pairi json için modele aktar
            foreach (var item in gorevOzeti)
            {
                row.columns.Add(new EmployeeListSummaryResource.Row.Column
                {
                    uid = item.Item1,
                    type = "num",
                    value = item.Item2
                });
                toplam.value += item.Item2;
            }
            row.columns.Add(toplam);
            employeeSummary.rows.Add(row);
            return Ok(employeeSummary);
        }



        //Helper function begin
        private List<Personel> personellerExcelOku(Stream file, ICollection<Unvan> unvanlar)
        {
            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
                int totalRows = worksheet.Dimension.Rows;
                List<Personel> personelList = new List<Personel>();

                for (int i = 2; i <= totalRows; i++)
                {
                    var sicilNo = worksheet.Cells[i, 1].Value.ToString();
                    var adsoyad = worksheet.Cells[i, 2].Value.ToString();
                    var gorevi = worksheet.Cells[i, 3].Value.ToString();
                    var kangrubu = (worksheet.Cells[i, 4].Value ?? "").ToString();
                    var iseBaslamaString = worksheet.Cells[i, 5].Value.ToString();
                    var iseBaslamaStringDoub = double.Parse(iseBaslamaString, CultureInfo.InvariantCulture);
                    DateTime iseBaslamaTarihi = DateTime.FromOADate(iseBaslamaStringDoub);
                    var tcNo = worksheet.Cells[i, 6].Value.ToString();
                    var telefon = worksheet.Cells[i, 7].Value.ToString();
                    var adres = worksheet.Cells[i, 8].Value.ToString();
                    var dogumTarihi = DateTime.FromOADate((double)worksheet.Cells[i, 9].Value);
                    personelList.Add(new Personel
                    {
                        SicilNo = sicilNo,
                        AdSoyad = adsoyad,
                        GorevId =  unvanlar.Where(u=>u.UnvanAdi== gorevi).FirstOrDefault().Id,
                        KanGrubu = kangrubu,
                        IseBaslamaTarihi = iseBaslamaTarihi,
                        TcNo = tcNo,
                        Telefon = telefon,
                        Adres = adres,
                        DogumTarihi = dogumTarihi
                    });
                }
                return personelList;
            }
        }
    


        private PersonelListResource ConvertToJsonFormat(ICollection<Personel> personels)
        {

            var personelListResource = new PersonelListResource();

            var list = personels.Select(p =>
            {
                var personelListResourceRow = new PersonelListResourceRow();
                personelListResourceRow.uid = p.Id;
                personelListResourceRow.href = "/Puantaj/Kisisel/" + p.Id;
                personelListResourceRow.columns.Add(new Column { type = "num", value = p.SicilNo, uid = "sicilno" });
                personelListResourceRow.columns.Add(new Column { type = "txt", value = p.Gorev.UnvanAdi, uid = "gorev" });
                personelListResourceRow.columns.Add(new Column { type = "txt", value = p.AdSoyad, uid = "adsoyad" });
                personelListResourceRow.columns.Add(new Column { type = "num", value = p.TcNo, uid = "tckn" });
                personelListResourceRow.columns.Add(new Column { type = "txt", value = p.DogumTarihi.ToString("dd.MM.yyyy"), uid = "dogumTarihi" });
                personelListResourceRow.columns.Add(new Column { type = "num", value = p.Telefon, uid = "telefonNo" });
                personelListResourceRow.columns.Add(new Column { type = "txt", value = p.KanGrubu, uid = "kanGrubu" });
                personelListResourceRow.columns.Add(new Column { type = "txt", value = p.Adres, uid = "kanGrubu" });
                personelListResourceRow.columns.Add(new Column { type = "txt", value = p.IseBaslamaTarihi.ToString("dd.MM.yyyy"), uid = "iseBaslamaTarihi" });
                if(p.IstenAyrilmaTarihi== new DateTime())
                personelListResourceRow.columns.Add(new Column { type = "txt", value = "", uid = "istenAyrilmaTarihi" });
                else personelListResourceRow.columns.Add(new Column { type = "txt", value = p.IstenAyrilmaTarihi.ToString("dd.MM.yyyy"), uid = "istenAyrilmaTarihi" });

                return personelListResourceRow;
            });

            personelListResource.rows = list.ToList();
            return personelListResource;
        }
        //Helper function end

    }
}
