using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Projek_UTSAren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Repositories.AlumniRepository
{
    public interface IAlumniRepository
    {   
        Task<bool> CreateAlumniAsync(Alumni alumni, IFormFile foto);
    }
}
