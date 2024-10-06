using AutoMapper;
using Sessions_app.Models;
using Sessions_app.DTOs;

namespace Sessions_app.Mapeamento
{
    public class PacienteProfile : Profile
    {
        public PacienteProfile()
        {
            CreateMap<Paciente, PacienteDTO>().ReverseMap();
        }
    }
}
