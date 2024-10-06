using System.Collections.Generic;
using System.Threading.Tasks;
using Sessions_app.Models;
using Sessions_app.Data;
using Sessions_app.DTOs;
using AutoMapper; // Usaremos o AutoMapper para mapeamento de objetos

namespace Sessions_app.Services
{
    public class PacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public PacienteService(IPacienteRepository pacienteRepository, IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PacienteDTO>> GetAllPacientesAsync()
        {
            var pacientes = await _pacienteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PacienteDTO>>(pacientes);
        }

        public async Task<PacienteDTO> GetPacienteByIdAsync(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            return _mapper.Map<PacienteDTO>(paciente);
        }

        public async Task AddPacienteAsync(PacienteDTO pacienteDto)
        {
            var paciente = _mapper.Map<Paciente>(pacienteDto);
            await _pacienteRepository.AddAsync(paciente);
        }

        public async Task UpdatePacienteAsync(PacienteDTO pacienteDto)
        {
            var paciente = _mapper.Map<Paciente>(pacienteDto);
            await _pacienteRepository.UpdateAsync(paciente);
        }

        public async Task DeletePacienteAsync(int id)
        {
            await _pacienteRepository.DeleteAsync(id);
        }
    }
}
