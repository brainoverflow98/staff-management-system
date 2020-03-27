using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelTakip.Controllers.Resources
{
    public class TableConstants
    {
        
        public static int MonthlyTallyTableNo = 1; 
        public static int MonthSummaryTableNo = 2;
        public static int AnnualTallyTableNo = 3;
        public static int EmployeeListTableNo = 4;
        public static int EmployeeListSummaryTableNo = 5;

        public static int DefaultOption = -1;

        public static CellConstant SicilNo = new CellConstant { Uid = "sicilno", Text = "Sicil No" };
        public static CellConstant Gorev = new CellConstant { Uid = "gorev", Text = "Görev" };
        public static CellConstant AdSoyad = new CellConstant { Uid = "adsoyad", Text = "Ad Soyad" };
        public static CellConstant TCKN = new CellConstant { Uid = "tckn", Text = "TCKN" };

        public static CellConstant Toplam = new CellConstant { Uid = "toplam", Text = "Toplam" };
        public static CellConstant DogumTarihi = new CellConstant { Uid = "dogumTarihi", Text = "Doğum Tarihi" };
        public static CellConstant TelefonNo = new CellConstant { Uid = "telefonNo", Text = "Telefon Numarası" };
        public static CellConstant KanGrubu = new CellConstant { Uid = "kanGrubu", Text = "KanGrubu" };
        public static CellConstant Adres = new CellConstant { Uid = "adres", Text = "Adres" };
        public static CellConstant IseBaslamaTarihi = new CellConstant { Uid = "iseBaslamaTarihi", Text = "İşe Başlama Tarihi" };
        public static CellConstant IstenAyrılmaTarihi = new CellConstant { Uid = "istenAyrilmaTarihi", Text = "İşten Ayrılma Tarihi" };


        public static List<CellConstant> HeaderList = new List<CellConstant>() {
        SicilNo, Gorev, AdSoyad, TCKN
        };

        public static List<CellConstant> PersonelListHeader = new List<CellConstant>(){
            SicilNo,Gorev,AdSoyad,TCKN,DogumTarihi,TelefonNo,KanGrubu,Adres,IseBaslamaTarihi,IstenAyrılmaTarihi
        };

        public static List<string> KanGruplari = new List<string>() { "0 Rh (+)", "A Rh (+)", "B Rh (+)", "AB Rh (+)", "0 Rh (-)", "A Rh (-)", "B Rh (-)", "AB Rh (-)" };

        public class CellConstant
        {
            public string Uid { get; set; }
            public string Text { get; set; }
        }
    }
}
