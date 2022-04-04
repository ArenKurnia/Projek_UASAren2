using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projek_UTSAren.Data;
using Projek_UTSAren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projek_UTSAren.Repositories.AlumniRepository
{
    public class AlumniRepository : IAlumniRepository
    {
        private readonly AppDbContext _context;
        public AlumniRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAlumniAsync(Alumni alumni, IFormFile foto)
        {
            _context.Add(alumni);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
