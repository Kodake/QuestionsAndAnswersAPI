﻿using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
    public class CuestionarioRepository : ICuestionarioRepository
    {
        private readonly AplicationDbContext _context;
        public CuestionarioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateCuestionario(Cuestionario cuestionario)
        {
            _context.Add(cuestionario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cuestionario>> GetListCuestionarioByUser(int idUsuario)
        {
            return await _context.Cuestionario.Where(x => x.Activo == 1 && x.UsuarioId == idUsuario).ToListAsync();
        }

        public async Task<Cuestionario> GetCuestionario(int idCuestionario)
        {
             var cuestionario = await _context.Cuestionario.Where(x => x.Id == idCuestionario
                                                    && x.Activo == 1)
                                                    .Include(x => x.ListPreguntas)
                                                    .ThenInclude(x => x.ListRespuestas)
                                                    .FirstOrDefaultAsync();
            return cuestionario;
        }

        public async Task<Cuestionario> BuscarCuestionario(int idCuestionario, int idUsuario)
        {
            return await _context.Cuestionario.Where(x => x.Id == idCuestionario && x.Activo == 1 && x.UsuarioId == idUsuario).FirstOrDefaultAsync();
        }

        public async Task EliminarCuestionario(Cuestionario cuestionario)
        {
            cuestionario.Activo = 0;
            _context.Entry(cuestionario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cuestionario>> GetListCuestionarios()
        {
            return await _context.Cuestionario.Where(x => x.Activo == 1)
                                                .Select(o => new Cuestionario
                                                {
                                                    Id = o.Id,
                                                    Nombre = o.Nombre,
                                                    Descripcion = o.Descripcion,
                                                    FechaCreacion = o.FechaCreacion,
                                                    Usuario = new Usuario { NombreUsuario = o.Usuario.NombreUsuario }

                                                })
                                                .ToListAsync();
        }
    }
}
