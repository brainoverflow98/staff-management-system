using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OfficeOpenXml;
using PersonelTakip.Controllers.Resources;
using PersonelTakip.Core;
using PersonelTakip.Core.Models;
using PersonelTakip.Extensions;
using Serilog;

namespace PersonelTakip.Controllers
{
    [Route("[controller]")]
    public class PuantajController : Controller
    {
        private readonly ISecenekListesiRepository secenekListesiRepository;
        private readonly IPersonelRepository personelRepository;
        private readonly IPuantajRepository puantajRepository;
        private readonly IUnvanRepository unvanRepository;
        private readonly IHesaplamaRepository hesaplamaRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PuantajController(ISecenekListesiRepository secenekListesiRepository,
        IPersonelRepository personelRepository,IPuantajRepository puantajRepository, IUnvanRepository unvanRepository, 
        IHesaplamaRepository hesaplamaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.secenekListesiRepository = secenekListesiRepository;
            this.personelRepository = personelRepository;
            this.puantajRepository = puantajRepository;
            this.unvanRepository = unvanRepository;
            this.hesaplamaRepository = hesaplamaRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpPost]
        [Route("AylikPuantajGecmisi")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili")]
        public async Task<IActionResult> AylikPuantajGecmisiEkle(int year, int month, IFormFile excel)
        {
            var pEkleResourceList = await aylikPuantajOku(excel.OpenReadStream(), year, month);            
            await puantajRepository.AddOrUpdateAsync(pEkleResourceList);                      

            var result = await unitOfWork.CompleteAsync();
            return Redirect("/Puantaj/Aylik");
        }


        [HttpPost]
        [Route("KisiselPuantajGecmisi")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili,Yetkili")]
        public async Task<IActionResult> KisiselPuantajGecmisiEkle(long Id, IFormFile excel)
        {

            
            
            var pEkleResource = await puantajOku(excel.OpenReadStream(), Id);
            var personelId = pEkleResource.uid;
            var puantajlar = pEkleResource.cells.Select(c => {                
                var date = DateTime.Parse(c.date, new CultureInfo("tr-TR", true));
                var puantajGirdisi = new PuantajGirdisi { PersonelId = personelId, Tarih = date, SecenekId = c.value };
                return puantajGirdisi;
            });
            
            await puantajRepository.AddOrUpdateAsync(puantajlar.ToList());                     
            
            var tarihler = string.Join(",",puantajlar.Select(p=>p.Tarih));

            var result = await unitOfWork.CompleteAsync();
            var logString = String.Format("{0} adlı kullanıcı {1} id li personelin puantaj geçmişini ekledi.",User.Identity.Name,personelId);
            return Redirect($"/Puantaj/Kisisel/{Id}");

        }


        [HttpGet]
        [Route("Aylik")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili,Yetkili,Kullanıcı")]
        public async Task<IActionResult> AylikPuantaj()
        {
            ViewBag.Hesaplamalar = await hesaplamaRepository.GetAllAsync();
            ViewBag.Unvanlar = await unvanRepository.GetAllAsync();
            ViewBag.Secenekler = await secenekListesiRepository.GetAllAsync();
            return View();
        }

        [HttpGet]
        [Route("Kisisel/{personelId}")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili,Yetkili,Kullanıcı")]
        public async Task<IActionResult> KisiselPuantaj(long personelId)
        {
            var personel = await personelRepository.FindOneAsync(personelId);
            if (personel == null)
                return NotFound();
            var personelResource = mapper.Map<Personel, PersonelDuzenleResource>(personel);            

            var unvanlar = await unvanRepository.GetAllAsync();
            ViewBag.UnvanSelectList = new SelectList(unvanlar, "Id", "UnvanAdi");
            ViewBag.KanGrubuSelectList = new SelectList(TableConstants.KanGruplari);

            ViewBag.Hesaplamalar = await hesaplamaRepository.GetAllAsync();
            ViewBag.Unvanlar = unvanlar;
            ViewBag.Secenekler = await secenekListesiRepository.GetAllAsync();

            return View(personelResource);
        }


        [HttpPost]
        [Route("Kaydet")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili,Yetkili")]
        public async Task<IActionResult> PuantajEkleAsync([FromBody] List<PuantajEkleResource> pEkleResourceList)
        {
            if (!ModelState.IsValid)
                return BadRequest(pEkleResourceList);

            var secenekler = await secenekListesiRepository.GetAllAsync();

            foreach (var pEkleResource in pEkleResourceList)
            {
                var personelId = pEkleResource.uid;
                var puantajlar = pEkleResource.cells.Select(c => {
                    var secenek = secenekler.FirstOrDefault(s => s.Id == c.value);
                    var date = DateTime.Parse(c.date, new CultureInfo("tr-TR", true));
                    var puantajGirdisi = new PuantajGirdisi { PersonelId = personelId, Tarih = date, SecenekId = secenek.Id };
                    return puantajGirdisi;
                });

                var today = DateTime.Today;
                if (!(puantajlar.Any(p =>  today.Year > p.Tarih.Year  
                || (today.Month > p.Tarih.Month && today.Day > 10)) ) 
                || User.IsInRole("ÜstDüzeyYetkili") 
                || User.IsInRole("SistemYöneticisi"))
                {
                    await puantajRepository.AddOrUpdateAsync(puantajlar.ToList());
                    var result = await unitOfWork.CompleteAsync();
                    var tarihler = string.Join(",",puantajlar.Select(p=>p.Tarih));
                     var logString = String.Format("{0} adlı kullanıcı {1} id li personel üzerinde şu {2} üzerinde  puantaj değişiklikliği yaptı",User.Identity.Name,personelId,tarihler);
                     Log.Information(logString);
                }
            }


            return Ok(Json("tamamlandı"));

        }

        [HttpPost]
        [Route("Monthly/{year}/{month}")]        
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili,Yetkili,Kullanıcı")]
        public async Task<IActionResult> MonthlyTally(int year, int month, [FromBody] IQueryObject queryObject)
        {
            var formuller = await hesaplamaRepository.GetAllAsync();
            var monthlyTallyResource = new MonthlyTallyResource(formuller.ToList());

            monthlyTallyResource.uid = month + "." + year;
            monthlyTallyResource.tableNo = 1;
            monthlyTallyResource.pageNo = 1;
            monthlyTallyResource.perPage = 10;

            //seçenekleri yükle
            var options = CreateOptions();
            monthlyTallyResource.optionGroups.Add(options);

            //Header oluştur
            AddDatesToHeaders(monthlyTallyResource.headers, month, year);

            
            var personelQueryResult = await personelRepository.GetsByQuery(queryObject, year, month);
            var baslangicTarih = new DateTime(year, month, 1);
            var bitisTarih = this.AySonuTarihHesapla(month, year);

            var aylikPuantaj = await puantajRepository.GetAllMonthlyAsync(baslangicTarih, bitisTarih);
            

            foreach (var personel in personelQueryResult.Items.OrderBy(p=>p.AdSoyad))
            {
                var row = new MonthlyTallyRow();
                row.uid = personel.Id;
                
                row.columns.Add(new MonthlyTallyColumn
                {
                    uid = TableConstants.SicilNo.Uid,
                    value = personel.SicilNo,
                    th = true,
                    type = "num",
                    classes = "table-secondary"
                });
                row.columns.Add(new MonthlyTallyColumn
                {
                    uid = TableConstants.Gorev.Uid,
                    value = personel.Gorev.UnvanAdi,
                    th = true,
                    type = "txt",
                    classes = "table-secondary"
                });
                row.columns.Add(new MonthlyTallyColumn
                {
                    uid = TableConstants.AdSoyad.Uid,
                    value = personel.AdSoyad,
                    th = true,
                    type = "txt",
                    classes = "table-secondary"
                });
                row.columns.Add(new MonthlyTallyColumn
                {
                    uid = TableConstants.TCKN.Uid,
                    value = personel.TcNo,
                    th = true,
                    type = "txt",
                    classes = "table-secondary"
                });
                

                bool isDisabled = false;
                var today = DateTime.Today;
                if ((today.Year > year || (today.Month > month && today.Day > 10)) && !(User.IsInRole("ÜstDüzeyYetkili") || User.IsInRole("SistemYöneticisi")))
                {
                    isDisabled = true;
                }
                foreach (var dateTime in AllDatesInMonth(year, month))
                {
                    long secenekId = TableConstants.DefaultOption;
                    var izin = aylikPuantaj.Where(p=> p.PersonelId == personel.Id && p.Tarih == dateTime).FirstOrDefault();
                    if (izin != null)
                        secenekId = izin.Secenek.Id;


                    row.columns.Add(new MonthlyTallyColumn
                    {
                        uid = dateTime.ToString("dd.MM.yyyy"),
                        type = "poll",                        
                        value = secenekId.ToString(),
                        disabled = isDisabled
                    });

                }
                

                var hesaplamalar = AylikCalismaVeIzinleriHesapla(personel, aylikPuantaj, formuller);

                foreach (var hesap in hesaplamalar)
                {
                    row.columns.Add(new MonthlyTallyColumn
                    {
                        uid = hesap.Item1,
                        value = hesap.Item2.ToString(),
                        type = "num",
                        th = true

                    });
                }
                monthlyTallyResource.rows.Add(row);
            }
            
            return Ok(monthlyTallyResource);
        }

        [HttpPost]
        [Route("Butun/{personelId}")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili,Yetkili,Kullanıcı")]

        public async Task<IActionResult> KisiButunPuantajGetirAsync(long personelId)
        {
            var personel  = await personelRepository.FindOneAsync(personelId);
            if(personel.IstenAyrilmaTarihi==new DateTime())
            {
             var yillikPuantaj = await  puantajRepository.GetAll(personelId, personel.IseBaslamaTarihi,DateTime.Now);
            return Ok(yillikPuantaj);

            }
            else  {

                 var yillikPuantaj = await   puantajRepository.GetAll(personelId, personel.IseBaslamaTarihi,personel.IstenAyrilmaTarihi);
                
                return Ok(yillikPuantaj);

            }

        }





        [HttpPost]
        [Route("Annual/{personelId}/{year}")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili,Yetkili,Kullanıcı")]
        public async Task<IActionResult> AnnualTallyAsync(long personelId, int year)
        {
            var formuller = await hesaplamaRepository.GetAllAsync();
            var annualTally = new AnnualTallyResource(personelId.ToString() +"-"+ year.ToString(), formuller.ToList());
 
            var baslangicTarih = new DateTime(year, 1, 1);
            var bitisTarih = this.AySonuTarihHesapla(12, year);
            var yillikPuantaj = await puantajRepository.GetAllAnnualAsync(personelId, baslangicTarih, bitisTarih);

            var personel = await personelRepository.FindOneAsync(personelId);            
            

            //seçenekleri yükle
            var options = CreateOptions();
            annualTally.optionGroups.Add(options);

            var trCulture = new CultureInfo("tr-TR", true).DateTimeFormat;

            for (int month = 1; month <= 12; month++)
            {
                var row = new AnnualTallyRow();
                row.uid = month;

                row.columns.Add(new AnnualTallyColumn
                {
                    type = "txt",
                    value = trCulture.GetMonthName(month),
                    th = true,
                    classes = "table-dark"

                });
                var allDays = AllDatesInMonth(year, month);
                foreach (var day in allDays)
                {
                    var puantaj = yillikPuantaj.Where(y=>y.Tarih==day).FirstOrDefault();

                    bool isDisabled = false;
                    var today = DateTime.Today;

                    if ((today.Year > year || (today.Month > month && today.Day > 10)) && !(User.IsInRole("ÜstDüzeyYetkili") || User.IsInRole("SistemYöneticisi")))
                    {
                        isDisabled = true;
                    }

                    if (puantaj != null)
                        row.columns.Add(new AnnualTallyColumn
                        {
                            uid = day.ToString("dd.MM.yyyy"),
                            type = "poll",
                            value = puantaj.Secenek.Id.ToString(),
                            disabled = isDisabled
                        });
                    else
                        row.columns.Add(new AnnualTallyColumn
                        {
                            uid = day.ToString("dd.MM.yyyy"),
                            type = "poll",
                            value = TableConstants.DefaultOption.ToString(),
                            disabled = isDisabled
                        });

                }
                for (var i=31 - allDays.Count(); i > 0; i--)
                {
                    row.columns.Add(new AnnualTallyColumn
                    {
                        uid = null,
                        type = "txt",                        
                        value = "",
                        disabled = true
                    });
                }
                
                var hesaplamalar = YillikCalismaVeIzinleriHesapla(year, month ,personel, yillikPuantaj, formuller);
                foreach (var item in hesaplamalar)
                {
                    row.columns.Add(new AnnualTallyColumn
                    {
                        uid = item.Item1,
                        type = "num",
                        value = item.Item2.ToString(),
                        th = true
                    });

                }



                annualTally.rows.Add(row);
            }



            return Ok(annualTally);
        }

        
        [HttpPost]
        [Route("MonthSummary/{year}/{month}")]
        [Authorize(Roles = "SistemYöneticisi,ÜstDüzeyYetkili,Yetkili,Kullanıcı")]
        public async Task<IActionResult> HesaplamaGoreveGore(int month, int year)
        {
            var formuller = await hesaplamaRepository.GetAllSummaryAsync();
            var hesaplamaResource = new HesaplamalarResource(month, year, 2, formuller);
            var baslangicTarih = new DateTime(year, month, 1);
            var bitisTarih = this.AySonuTarihHesapla(month, year);

            //Personelleri resources da list'e ekle
            var gorevList = await unvanRepository.GetAllAsync();            
            var summaryPuantaj = await puantajRepository.GetAllSummaryAsync(baslangicTarih, bitisTarih);
            var personeller = await personelRepository.GetsByQuery(null, year, month);
            

            var rowIndex = 0; // her satırı toplam satırından hemen önce yerleştir
            foreach (var gorev in gorevList)
            {
                var row = new HesaplamalarRow();
                row.uid = gorev.Id.ToString();

                var hesaplamalar = CalismaVeIzinleriGoreveGoreHesapla(gorev, summaryPuantaj, formuller, personeller.Items);
                row.columns.Add(new HesaplamalarRow.Column
                {
                    uid = TableConstants.Gorev.Uid,
                    header = true,
                    type = "txt",
                    value = gorev.UnvanAdi

                });
                var colIndex = 1; // toplam sütünlarına değerleri toplayarak koy
                foreach (var hesap in hesaplamalar)
                {
                    row.columns.Add(new HesaplamalarRow.Column
                    {
                        uid = hesap.Item1,
                        type = "num",
                        value = hesap.Item2.ToString()
                    });

                    var toplamRow = hesaplamaResource.rows[rowIndex];
                    var oldTotal = int.Parse(toplamRow.columns[colIndex].value);
                    toplamRow.columns[colIndex++].value = (oldTotal + hesap.Item2).ToString();
                }

                hesaplamaResource.rows.Insert(rowIndex++, row);
            }       
            



            return Ok(hesaplamaResource);
        }






        #region HelperMethods
        private async Task<List<PuantajGirdisi>> aylikPuantajOku(Stream file, int year, int month)
        {
            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
                int totalRows = worksheet.Dimension.Rows;

                var puantajEkleList = new List<PuantajGirdisi>();

                var baslangicTarih = new DateTime(year, month, 1);
                var bitisTarih = this.AySonuTarihHesapla(month, year);
                var personeller = await personelRepository.GetsByQuery(null, year, month, "all");

                var secenekListesi = await secenekListesiRepository.GetAllAsync();

                for (int i = 2; i <= totalRows; i++)
                {
                    var tckn = worksheet.Cells[i, 1].Value.ToString();
                    var personel = personeller.Items.Where(p => p.TcNo == tckn).FirstOrDefault();
                    if (personel != null)
                    {                        
                        foreach (var item in AllDatesInMonth(year, month))
                        {
                            var column = item.Day + 1;
                            var deger = (worksheet.Cells[i, column].Value ?? "").ToString();

                            var secenek = secenekListesi.FirstOrDefault(d => d.Deger == deger) ?? null;
                            if (secenek != null)
                                puantajEkleList.Add(new PuantajGirdisi { PersonelId = personel.Id, Tarih = item, SecenekId = secenek.Id });                                
                            else
                                puantajEkleList.Add(new PuantajGirdisi { PersonelId = personel.Id, Tarih = item, SecenekId = TableConstants.DefaultOption });                                
                        }                        
                    }                    
                }
                return puantajEkleList;
            }
        }


        private async Task<PuantajEkleResource> puantajOku(Stream file, long userId)
        {
            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.First();
                int totalRows = worksheet.Dimension.Rows;
                var puantajEkleResource = new PuantajEkleResource();
                puantajEkleResource.cells = new List<PuantajEkleResource.Cell>();
                puantajEkleResource.uid = userId;

                var secenekListesi = await secenekListesiRepository.GetAllAsync();

                for (int i = 2; i <= totalRows; i++)
                {
                    var tarih = DateTime.FromOADate(double.Parse(worksheet.Cells[i, 1].Value.ToString(), CultureInfo.InvariantCulture));
                    foreach (var item in AllDatesInMonth(tarih.Year, tarih.Month))
                    {
                        var column = item.Day + 1;
                        var deger = (worksheet.Cells[i, column].Value ?? "").ToString();

                        var secenek = secenekListesi.FirstOrDefault(d => d.Deger == deger) ?? null;
                        if (secenek != null)
                            puantajEkleResource.cells.Add(new PuantajEkleResource.Cell
                            {
                                date = item.ToString("dd.MM.yyyy"),
                                value = secenek.Id
                            });
                        else
                            puantajEkleResource.cells.Add(new PuantajEkleResource.Cell
                            {
                                date = item.ToString("dd.MM.yyyy"),
                                value = TableConstants.DefaultOption
                            });
                    }
                }
                return puantajEkleResource;
            }
        }


        private void AddDatesToHeaders(List<MonthlyTallyHeader> headers, int month, int year)
        {
            var index = TableConstants.HeaderList.Count; // Hesaplama başlıklarından hemen önce yerleştirmeye başla.
            foreach (DateTime date in AllDatesInMonth(year, month))
            {
                headers[0].columns.Insert(index++, new MonthlyTallyHeader.Column
                {
                    type = "date",
                    value = date.ToString("dd.MM.yyyy"),
                    vertical = true
                });
            }
        }


        private Dictionary<long, Option> CreateOptions()
        {
            var secenekler = secenekListesiRepository.GetAll();
            var options = new Dictionary<long, Option>();            
            foreach (var item in secenekler)
            {
                options.Add(item.Id, new Option { color = item.Renk, text = item.Deger });
            }



            return options;
        }
        private IEnumerable<DateTime> AllDatesInMonth(int year, int month)
        {
            int days = DateTime.DaysInMonth(year, month);
            for (int day = 1; day <= days; day++)
            {
                yield return new DateTime(year, month, day);
            }
        }
        private DateTime AySonuTarihHesapla(int ay, int yil)
        {
            var lastdayOfMonth = DateTime.DaysInMonth(yil, ay);
            var strDay = lastdayOfMonth + "." + ay + "." + yil;
            var sonuc = DateTime.Parse(strDay, new CultureInfo("tr-TR", true));

            return sonuc;

        }


        private List<Tuple<string, int>> AylikCalismaVeIzinleriHesapla(Personel personel, ICollection<PuantajGirdisi> puantaj, ICollection<Hesaplama> formuller)
        {
            var hesaplamalar = new List<Tuple<string, int>>();
            var puantajList = puantaj.Where(p => p.PersonelId == personel.Id)
                .GroupBy(x => x.SecenekId)
                .Select(group => new { group.Key, Count = group.Count() });

            foreach (var formul in formuller)
            {
                var toplam = 0;
                if ((formul.HesaplamaUnvanlari.Count == 0 || formul.HesaplamaUnvanlari.Where(h => h.UnvanId == personel.GorevId).Count() > 0) && puantajList != null)
                {
                    foreach (var secenek in formul.HesaplamaSecenekleri)
                    {
                        toplam += puantajList.Where(p => p.Key == secenek.SecenekId).Select(x => x.Count).FirstOrDefault() * secenek.Katsayi;
                    }
                }
                if (toplam > formul.SaymaLimiti && formul.SaymaLimiti > 0)
                    toplam = formul.SaymaLimiti;
                hesaplamalar.Add(new Tuple<string, int>(formul.Id.ToString(), toplam));
            }

            return hesaplamalar;
        }

        private List<Tuple<string, int>> YillikCalismaVeIzinleriHesapla(int year, int month, Personel personel, ICollection<PuantajGirdisi> puantaj, ICollection<Hesaplama> formuller)
        {
            var baslangicTarih = new DateTime(year, month, 1);
            var bitisTarih = this.AySonuTarihHesapla(month, year);

            var hesaplamalar = new List<Tuple<string, int>>();
            var puantajList = puantaj.Where(p => p.Tarih >= baslangicTarih && p.Tarih <= bitisTarih).GroupBy(x => x.SecenekId)
                .Select(group => new { group.Key, Count = group.Count() });

            foreach (var formul in formuller)
            {
                var toplam = 0;
                if ((formul.HesaplamaUnvanlari.Count == 0 || formul.HesaplamaUnvanlari.Where(h => h.UnvanId == personel.GorevId).Count() > 0) && puantajList != null)
                {
                    foreach (var secenek in formul.HesaplamaSecenekleri)
                    {
                        toplam += puantajList.Where(p => p.Key == secenek.SecenekId).Select(x => x.Count).FirstOrDefault() * secenek.Katsayi;
                    }
                }
                if (toplam > formul.SaymaLimiti && formul.SaymaLimiti > 0)
                    toplam = formul.SaymaLimiti;
                hesaplamalar.Add(new Tuple<string, int>(formul.Id.ToString(), toplam));
            }

            return hesaplamalar;
        }


        private List<Tuple<string, int>> CalismaVeIzinleriGoreveGoreHesapla(Unvan gorev, ICollection<PuantajGirdisi> puantaj, ICollection<Hesaplama> formuller, IEnumerable<Personel> personeller)
        {
            var hesaplamalar = new List<Tuple<string, int>>();

            var personelList = personeller.Where(p => p.GorevId == gorev.Id);

            var puantajList = puantaj.GroupBy(x => new { x.SecenekId, x.PersonelId })
                .Select(group => new { group.Key, Count = group.Count() });

            

            foreach (var formul in formuller)
            {
                var toplam = 0;
                foreach (var personel in personelList)
                {
                    var araToplam = 0;
                    var puanlar = puantajList.Where(p=>p.Key.PersonelId == personel.Id);
                    if ((formul.HesaplamaUnvanlari.Count == 0 || formul.HesaplamaUnvanlari.Where(h => h.UnvanId == gorev.Id).Count() > 0) && puantajList != null)
                    {
                        foreach (var secenek in formul.HesaplamaSecenekleri)
                        {
                            araToplam += puanlar.Where(p => p.Key.SecenekId == secenek.SecenekId).Select(x => x.Count).FirstOrDefault() * secenek.Katsayi;
                        }
                    }
                    if (araToplam > formul.SaymaLimiti && formul.SaymaLimiti > 0)
                        araToplam = formul.SaymaLimiti;
                    toplam += araToplam;
                }
                hesaplamalar.Add(new Tuple<string, int>(formul.Id.ToString(), toplam));
            }

            return hesaplamalar;
        }
        #endregion

    }
}