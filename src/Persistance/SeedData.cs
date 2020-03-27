using Microsoft.EntityFrameworkCore;
using PersonelTakip.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelTakip.Persistance
{
    public class SeedData
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<SecenekListesi>().HasData(new SecenekListesi[]
            {

                new SecenekListesi{Deger="",Renk="white",Aciklama="Boş Değer",Id=-1, Disabled=false},
                new SecenekListesi{Deger="X",Renk="indianred",Aciklama="Normal Çalışma",Id=1, Disabled=false},
                new SecenekListesi{Deger="X1",Renk="lightsalmon",Aciklama="Bir Saatlik Mesai",Id=2, Disabled=false},
                new SecenekListesi{Deger="X2", Renk="darkorange",Aciklama="İki Saatlik Mesai",Id=3, Disabled=false},
                new SecenekListesi{Deger="X3",Renk="papayawhip",Aciklama="Üç Saatlik Mesai",Id=4, Disabled=false},
                new SecenekListesi{Deger="Gx", Renk="palegoldenrod",Aciklama="Gece Çalışması",Id=5, Disabled=false},
                new SecenekListesi{Deger="Ht", Renk="limegreen",Aciklama="Hafta Tatili",Id=6, Disabled=false},
                new SecenekListesi{Deger="D", Renk="lightcyan",Aciklama="Devamsızlık",Id=7, Disabled=false},
                new SecenekListesi{Deger="Yi", Renk="aquamarine",Aciklama="Yıllık İzin",Id=8, Disabled=false},
                new SecenekListesi{Deger="İi", Renk="white",Aciklama="İdari İzin",Id=9, Disabled=false},
                new SecenekListesi{Deger="Üi", Renk="white",Aciklama="Ücretsiz İzin",Id=10, Disabled=false},
                new SecenekListesi{Deger="R+", Renk="blue",Aciklama="Ödenecek Rapor",Id=11, Disabled=false},
                new SecenekListesi{Deger="R-", Renk="skyblue",Aciklama="Ödenmeyecek Rapor",Id=12, Disabled=false},
                new SecenekListesi{Deger="V", Renk="slateblue",Aciklama="Vizite",Id=13, Disabled=false},
                new SecenekListesi{Deger="Rt", Renk="thistle",Aciklama="Resmi Tatil",Id=14, Disabled=false},
                new SecenekListesi{Deger="Di", Renk="lavender",Aciklama="Doğum İzni",Id=15, Disabled=false},
                new SecenekListesi{Deger="Ei", Renk="hotpink",Aciklama="Evlilik İzni",Id=16, Disabled=false},
                new SecenekListesi{Deger="Öi",Renk="floralwhite",Aciklama="Ölüm İzni",Id=17, Disabled=false},
                new SecenekListesi{Deger="Vi",Renk="lavenderblush",Aciklama="Vardiya İzni",Id=18, Disabled=false},
                new SecenekListesi{Deger="Rc",Renk="tan",Aciklama="Resmi Tatil Çalışma",Id=19, Disabled=false},
            });

            builder.Entity<Unvan>().HasData(new Unvan[]
            {

                new Unvan{Id=1, UnvanAdi="Yönetici Amir", Disabled=false},
                new Unvan{Id=2, UnvanAdi="İlaçlama Yetkilisi", Disabled=false},
                new Unvan{Id=3, UnvanAdi="Bölge Şefi", Disabled=false},
                new Unvan{Id=4, UnvanAdi="Puantör", Disabled=false},
                new Unvan{Id=5, UnvanAdi="Araç Bakım Sorumlusu", Disabled=false},
                new Unvan{Id=6, UnvanAdi="Halkla İlişkiler Görevlisi", Disabled=false},
                new Unvan{Id=7, UnvanAdi="Operatör", Disabled=false},
                new Unvan{Id=8, UnvanAdi="İlaçlama Görevlisi", Disabled=false},
                new Unvan{Id=9, UnvanAdi="Vasıflı", Disabled=false},
                new Unvan{Id=10, UnvanAdi="Şoför", Disabled=false},
                new Unvan{Id=11, UnvanAdi="Otobüs Şoförü", Disabled=false},
                new Unvan{Id=12, UnvanAdi="Ağaç Dalı Ekibi", Disabled=false},
                new Unvan{Id=13, UnvanAdi="Yükleyici İşçi", Disabled=false},
                new Unvan{Id=14, UnvanAdi="Genel Amaçlı İşçi", Disabled=false}
            });

            builder.Entity<Hesaplama>().HasData(new Hesaplama[]
            {

                new Hesaplama{Id=1, Baslik="Çalışma Günü", OzetGoster=false, Disabled=false},
                new Hesaplama{Id=2, Baslik="Hafta Tatili", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=3, Baslik="Resmi Tatil", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=4, Baslik="Yıllık İzin", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=5, Baslik="Ödenecek Rapor", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=6, Baslik="Doğum İzni", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=7, Baslik="Ölüm İzni", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=8, Baslik="Evlilik İzni", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=9, Baslik="Vardiya İzni", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=10, Baslik="Ödenmeyecek Rapor", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=11, Baslik="Ücretsiz İzin", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=12, Baslik="Devamsızlık", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=13, Baslik="Sigorta Gün", OzetGoster=true, Disabled=false, SaymaLimiti=30},
                new Hesaplama{Id=14, Baslik="Yemek Gün", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=15, Baslik="Yol Gün", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=16, Baslik="Sorumluluk Gün", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=17, Baslik="Gece Çalışma", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=18, Baslik="Saat Mesai", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=19, Baslik="Vizite", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=20, Baslik="İdari İzin", OzetGoster=true, Disabled=false},
                new Hesaplama{Id=21, Baslik="Resmi Tatil Mesai", OzetGoster=true, Disabled=false}

           });

            builder.Entity<HesaplamaSecenegi>().HasData(new HesaplamaSecenegi[]
            {
                new HesaplamaSecenegi{HesaplamaId=1, SecenekId=1},
                new HesaplamaSecenegi{HesaplamaId=1, SecenekId=2},
                new HesaplamaSecenegi{HesaplamaId=1, SecenekId=3},
                new HesaplamaSecenegi{HesaplamaId=1, SecenekId=4},
                new HesaplamaSecenegi{HesaplamaId=1, SecenekId=5},
                new HesaplamaSecenegi{HesaplamaId=1,SecenekId=19},

                new HesaplamaSecenegi{HesaplamaId=2, SecenekId=6},
                new HesaplamaSecenegi{HesaplamaId=3, SecenekId=14},
                new HesaplamaSecenegi{HesaplamaId=4, SecenekId=8},
                new HesaplamaSecenegi{HesaplamaId=5, SecenekId=11},
                new HesaplamaSecenegi{HesaplamaId=6, SecenekId=15},
                new HesaplamaSecenegi{HesaplamaId=7, SecenekId=17},
                new HesaplamaSecenegi{HesaplamaId=8, SecenekId=16},
                new HesaplamaSecenegi{HesaplamaId=9, SecenekId=18},
                new HesaplamaSecenegi{HesaplamaId=10, SecenekId=12},
                new HesaplamaSecenegi{HesaplamaId=11, SecenekId=10},
                new HesaplamaSecenegi{HesaplamaId=12, SecenekId=7},
                new HesaplamaSecenegi{HesaplamaId=13, SecenekId=1},
                new HesaplamaSecenegi{HesaplamaId=13, SecenekId=2},
                new HesaplamaSecenegi{HesaplamaId=13, SecenekId=3},
                new HesaplamaSecenegi{HesaplamaId=13, SecenekId=4},
                new HesaplamaSecenegi{HesaplamaId=13, SecenekId=5},
                new HesaplamaSecenegi{HesaplamaId=13, SecenekId=6},
                new HesaplamaSecenegi{HesaplamaId=13, SecenekId=8},
                new HesaplamaSecenegi{HesaplamaId=13, SecenekId=9},
                new HesaplamaSecenegi{HesaplamaId=13, SecenekId=11},
                new HesaplamaSecenegi{HesaplamaId=13, SecenekId=13},
                new HesaplamaSecenegi{HesaplamaId=13, SecenekId=14},
                new HesaplamaSecenegi{HesaplamaId=13, SecenekId=15},
                new HesaplamaSecenegi{HesaplamaId=13, SecenekId=16},
                new HesaplamaSecenegi{HesaplamaId=13, SecenekId=17},
                new HesaplamaSecenegi{HesaplamaId=13, SecenekId=18},
                new HesaplamaSecenegi{HesaplamaId=13,SecenekId=19},

                new HesaplamaSecenegi{HesaplamaId=14, SecenekId=1},
                new HesaplamaSecenegi{HesaplamaId=14, SecenekId=2},
                new HesaplamaSecenegi{HesaplamaId=14, SecenekId=3},
                new HesaplamaSecenegi{HesaplamaId=14, SecenekId=4},
                new HesaplamaSecenegi{HesaplamaId=14, SecenekId=5},
                new HesaplamaSecenegi{HesaplamaId=14,SecenekId=19},

                new HesaplamaSecenegi{HesaplamaId=15, SecenekId=1},
                new HesaplamaSecenegi{HesaplamaId=15, SecenekId=2},
                new HesaplamaSecenegi{HesaplamaId=15, SecenekId=3},
                new HesaplamaSecenegi{HesaplamaId=15, SecenekId=4},
                new HesaplamaSecenegi{HesaplamaId=15, SecenekId=5},
                new HesaplamaSecenegi{HesaplamaId=15,SecenekId=19},

                new HesaplamaSecenegi{HesaplamaId=16, SecenekId=1},
                new HesaplamaSecenegi{HesaplamaId=16, SecenekId=2},
                new HesaplamaSecenegi{HesaplamaId=16, SecenekId=3},
                new HesaplamaSecenegi{HesaplamaId=16, SecenekId=4},
                new HesaplamaSecenegi{HesaplamaId=16, SecenekId=5},
                new HesaplamaSecenegi{HesaplamaId=16,SecenekId=19},

                new HesaplamaSecenegi{HesaplamaId=17, SecenekId=5,Katsayi=7},
                new HesaplamaSecenegi{HesaplamaId=17,SecenekId=19},

                new HesaplamaSecenegi{HesaplamaId=18, SecenekId=2, Katsayi=1},
                new HesaplamaSecenegi{HesaplamaId=18, SecenekId=3, Katsayi=2},
                new HesaplamaSecenegi{HesaplamaId=18, SecenekId=4, Katsayi=3},

                //Vizite
                new HesaplamaSecenegi{HesaplamaId=19, SecenekId=13, Katsayi=1},

                //İdari İzin
                new HesaplamaSecenegi{HesaplamaId=20, SecenekId=9, Katsayi=1},
                //Resmi Tatil
                new HesaplamaSecenegi{HesaplamaId=21, SecenekId=19, Katsayi=1},

            });

            builder.Entity<HesaplamaUnvani>().HasData(new HesaplamaUnvani[]
            {
                new HesaplamaUnvani{HesaplamaId=16, UnvanId=7},
                new HesaplamaUnvani{HesaplamaId=16, UnvanId=10},
                new HesaplamaUnvani{HesaplamaId=16, UnvanId=11}
            });
        }
    }
}
