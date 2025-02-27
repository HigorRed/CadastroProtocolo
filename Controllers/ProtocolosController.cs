
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CadastroProtocolo.Controllers
{
    public class ProtocolosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProtocolosController(ApplicationDbContext context)
        {
            _context = context;
        }



    
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Protocolos.Include(p => p.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocolo = await _context.Protocolos
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (protocolo == null)
            {
                return NotFound();
            }

            return View(protocolo);
        }

         public IActionResult Create()
    {
       
        ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Nome");
        ViewData["Status"] = new SelectList(Enum.GetValues(typeof(StatusProtocolo))
            .Cast<StatusProtocolo>()
            .Select(e => new { Value = e, Text = e.ToString() })
            .ToList(), "Value", "Text");

        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,DataAbertura,DataFechamento,ClienteId,Status")] Protocolo protocolo)
    {
        if (ModelState.IsValid)
        {
            _context.Add(protocolo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        

        ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Nome", protocolo.ClienteId);
        ViewData["Status"] = new SelectList(Enum.GetValues(typeof(StatusProtocolo))
            .Cast<StatusProtocolo>()
            .Select(e => new { Value = e, Text = e.ToString() })
            .ToList(), "Value", "Text", protocolo.Status);

        return View(protocolo);
    }


         
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var protocolo = await _context.Protocolos.FindAsync(id);
        if (protocolo == null)
        {
            return NotFound();
        }

        ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Nome", protocolo.ClienteId);
        ViewData["Status"] = new SelectList(Enum.GetValues(typeof(StatusProtocolo))
            .Cast<StatusProtocolo>()
            .Select(s => new { Value = s, Text = s.ToString() }), "Value", "Text", protocolo.Status);

        return View(protocolo);
    }

  
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,DataAbertura,DataFechamento,ClienteId,Status")] Protocolo protocolo)
    {
        if (id != protocolo.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(protocolo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProtocoloExists(protocolo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }


        ViewData["ClienteId"] = new SelectList(_context.Clientes, "IdCliente", "Nome", protocolo.ClienteId);
        ViewData["Status"] = new SelectList(Enum.GetValues(typeof(StatusProtocolo))
            .Cast<StatusProtocolo>()
            .Select(s => new { Value = s, Text = s.ToString() }), "Value", "Text", protocolo.Status);

        return View(protocolo);
    }
       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocolo = await _context.Protocolos
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (protocolo == null)
            {
                return NotFound();
            }

            return View(protocolo);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var protocolo = await _context.Protocolos.FindAsync(id);
            if (protocolo != null)
            {
                _context.Protocolos.Remove(protocolo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProtocoloExists(int id)
        {
            return _context.Protocolos.Any(e => e.Id == id);
        }
    }
}
