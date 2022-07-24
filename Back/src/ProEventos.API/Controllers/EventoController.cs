using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

    public IEnumerable<Evento> _evento = new Evento[] {
        new Evento() {
            EventoId = 1,
            Tema = "Angular",
            Local = "Belo Horizonte",
            Lote = "1a. Lote",
            QtdPessoas = 100,
            DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
            ImagemURL = "foto.png"
        },
        new Evento() {
            EventoId = 2,
            Tema = "Angular e Suas novidades",
            Local = "Fortaleza",
            Lote = "2a. Lote",
            QtdPessoas = 300,
            DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
            ImagemURL = "foto2.png"
        }
    };

    public EventoController(ILogger<EventoController> logger)
    {
        
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
       return _evento;
    }
    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
       return _evento.Where(evento => evento.EventoId == id);
    }


}
