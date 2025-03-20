using Microsoft.AspNetCore.Mvc;
using Sessions_app.Models;
using Sessions_app.Patterns;
using Sessions_app.Service;

namespace Sessions_app.Controllers
{
    public class MedicoController : Controller
    {
        private readonly MedicoService _service;
        private readonly LoggerManager _logger = LoggerManager.GetInstance();
        public MedicoController(MedicoService service)
        {
            _service = service;
        }
        // GET: Medico
        public async Task<IActionResult> Index()
        {
            _logger.LogInfo("Controller MVC: Listando todos os médicos");
            var medicos = await _service.GetAllMedicosAsync();
            return View(medicos);
        }
        // GET: Medico/Details/5
        public async Task<IActionResult> Details(int id)
        {
            _logger.LogInfo($"Controller MVC: Exibindo detalhes do médico ID: {id}");
            var medico = await _service.GetMedicoByIdAsync(id);
            if (medico == null)
            {
                _logger.LogWarning($"Médico com ID {id} não encontrado");
                return NotFound();
            }
            return View(medico);
        }
        // GET: Medico/Create
        public IActionResult Create()
        {
            _logger.LogInfo("Controller MVC: Exibindo formulário para criar médico");
            return View();
        }
        // POST: Medico/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInfo($"Controller MVC: Criando médico {medico.Nome}");
                await _service.CreateMedicoAsync(medico);
                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }
        // GET: Medico/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            _logger.LogInfo($"Controller MVC: Exibindo formulário para editar médico ID: {id}");
            var medico = await _service.GetMedicoByIdAsync(id);
            if (medico == null)
            {
                _logger.LogWarning($"Médico com ID {id} não encontrado");
                return NotFound();
            }
            return View(medico);
        }
        // POST: Medico/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Medico medico)
        {
            if (id != medico.IdMedico)
            {
                _logger.LogWarning($"ID {id} não corresponde ao ID do médico {medico.IdMedico}");
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _logger.LogInfo($"Controller MVC: Atualizando médico ID: {id}");
                await _service.UpdateMedicoAsync(medico);
                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }
        // GET: Medico/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInfo($"Controller MVC: Exibindo confirmação para excluir médico ID: {id}");
            var medico = await _service.GetMedicoByIdAsync(id);
            if (medico == null)
            {
                _logger.LogWarning($"Médico com ID {id} não encontrado");
                return NotFound();
            }
            return View(medico);
        }
        // POST: Medico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _logger.LogInfo($"Controller MVC: Excluindo médico ID: {id}");
            await _service.DeleteMedicoAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ErroMedicoNaoEncontrado(int id)
        {
            ViewData["MedicoId"] = id;
            return View();
        }
        [HttpGet]
        public IActionResult EspecialidadesMedicas()
        {
            return View();
        }
    }
}
