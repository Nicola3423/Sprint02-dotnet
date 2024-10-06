using Microsoft.AspNetCore.Mvc;
using Sessions_app.Models;
using Sessions_app.Services;
using Sessions_app.DTOs;

namespace Sessions_app.Controllers
{
    public class PacienteController : Controller
    {
        private readonly PacienteService _pacienteService;

        public PacienteController(PacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        public async Task<IActionResult> Index()
        {
            var pacientes = await _pacienteService.GetAllPacientesAsync();
            return View(pacientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PacienteDTO pacienteDto)
        {
            if (ModelState.IsValid)
            {
                await _pacienteService.AddPacienteAsync(pacienteDto);
                return RedirectToAction("Index");
            }
            return View(pacienteDto);
        }

        // Método para editar um paciente
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var paciente = await _pacienteService.GetPacienteByIdAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PacienteDTO pacienteDto)
        {
            if (ModelState.IsValid)
            {
                await _pacienteService.UpdatePacienteAsync(pacienteDto);
                return RedirectToAction("Index");
            }
            return View(pacienteDto);
        }

        // Método para deletar um paciente
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var paciente = await _pacienteService.GetPacienteByIdAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _pacienteService.DeletePacienteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
