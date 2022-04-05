using Microsoft.AspNetCore.Http;
using Projek_UTSAren.Models;
using Projek_UTSAren.Repositories.AlumniRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Services.AlumniService
{
    public class AlumniService : IAlumniService
    {
        private readonly IAlumniRepository _alumniRepository;
        public AlumniService(IAlumniRepository alumni)
        {
            _alumniRepository = alumni;
        }

        public Alumni AmbilAlumniBerdasarkanId(string id)
        {
            return _alumniRepository.AmbilAlumniBerdasarkanIdAsync(id).Result;
        }

        public bool CreateAlumni(Alumni alumni)
        { 
            return _alumniRepository.CreateAlumniAsync(alumni).Result;
        }

        public bool HapusAlumni(string id)
        {
            var cari = _alumniRepository.CariAlumniAsync(id).Result;
            return _alumniRepository.HapusAlumniAsync(cari).Result;
        }

        public bool UpdateAlumni(Alumni alumni)
        { 
            return _alumniRepository.UpdateAlumniAsync(alumni).Result;
        }
    }
}
