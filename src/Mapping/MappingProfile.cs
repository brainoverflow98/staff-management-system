using System;
using AutoMapper;
using PersonelTakip.Controllers.Resources;
using PersonelTakip.Core.Models;

namespace PersonelTakip.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Resource to Domain
            CreateMap<PersonelEkleResource, Personel>();
        
            CreateMap<PersonelDuzenleResource, Personel>();
            



            //Domain to Api
            CreateMap<Personel, PersonelDuzenleResource>();


        }
    }

}

