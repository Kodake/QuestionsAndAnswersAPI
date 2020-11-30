using BackEnd.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface IRespuestaCuestionarioService
    {
        Task SaveRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario);
        Task<List<RespuestaCuestionario>> ListRespuestaCuestionario(int idCuestionario, int idUsuario);
        Task<RespuestaCuestionario> BuscarRespuestaCuestionario(int idCuestionario, int idUsuario);
        Task EliminarRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario);
        Task<int> GetIdCuestionarioByIdRespuesta(int idRespuesta);
        Task <List<RespuestaCuestionarioDetalle>> GetListRespuestas(int idRespuestaCuestionario);
    }
}
