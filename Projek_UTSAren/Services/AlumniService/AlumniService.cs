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
        private readonly FileService _file;

        public AlumniService(IAlumniRepository alumni, FileService f)
        {
            _alumniRepository = alumni;
            _file = f;
        }

        public bool CreateAlumni(Alumni alumni, IFormFile foto)
        {
            alumni.Foto = _file.SimpanFile(foto).Result;

            return _alumniRepository.CreateAlumniAsync(alumni, foto).Result;
        }
    }
}
