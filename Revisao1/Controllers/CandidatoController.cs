using Revisao1.Models;
using Revisao1.Repositories;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;


namespace Revisao1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidatoRepository _candidatoRepository;

        public CandidatoController(ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        [HttpPost]
        public IActionResult Cadastrar(Candidato candidato)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = _candidatoRepository.ObterPorNumero(candidato.Numero);
            
            if(resultado is null)
            {
                _candidatoRepository.Cadastrar(candidato);
                return Ok("Cadastrado com sucesso!");
            }
            return BadRequest("Número de candidato já cadastrado.");
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var candidatos = _candidatoRepository.ObterTodos();
            return Ok(candidatos);
        }

        [HttpPost("Votar")]
        public IActionResult Votar(Voto voto)
        {
            var candidato = _candidatoRepository.ObterPorNumero(voto.NumeroCandidato);

            if (candidato == null)
                return NotFound("Candidato não encontrado.");

            voto.DataVoto = DateTime.Now;

            _candidatoRepository.RegistrarVoto(voto);
            return Ok("Voto registrado!");
        }

        [HttpGet("Votos/{numero}")]
        public IActionResult ConsultarVotos(int numero)
        {
            var candidato = _candidatoRepository.ObterPorNumero(numero);

            if (candidato == null)
                return NotFound("Candidato não encontrado.");

            var votos = _candidatoRepository.ObterVotosPorCandidato(numero);

            return Ok(votos);
        }
    }
}