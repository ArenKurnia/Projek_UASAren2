using Microsoft.AspNetCore.Http;
using Projek_UTSAren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Services.AlumniService
{
    public interface IAlumniService
    {
        bool CreateAlumni(Alumni alumni, IFormFile foto);
    }
}
