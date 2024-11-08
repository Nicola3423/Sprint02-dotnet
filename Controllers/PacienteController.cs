using Microsoft.AspNetCore.Mvc;
using Sessions_app.Services;
using Sessions_app.DTOs;

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
            return RedirectToAction(nameof(Index));
        }
        return View(pacienteDto);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var paciente = await _pacienteService.GetPacienteByIdAsync(id);
        return View(paciente);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(PacienteDTO pacienteDto)
    {
        if (ModelState.IsValid)
        {
            await _pacienteService.UpdatePacienteAsync(pacienteDto);
            return RedirectToAction(nameof(Index));
        }
        return View(pacienteDto);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _pacienteService.DeletePacienteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> SearchById(int id)
    {
        var paciente = await _pacienteService.GetPacienteByIdAsync(id);
        if (paciente == null)
        {
            return RedirectToAction(nameof(ErroPacienteNaoEncontrado), new { id });
        }
        return View(paciente);
    }

    public IActionResult ErroPacienteNaoEncontrado(int id)
    {
        ViewData["PacienteId"] = id;
        return View();
    }

    [HttpGet]
    public IActionResult CuidadosDentais()
    {
        return View();
    }
}
