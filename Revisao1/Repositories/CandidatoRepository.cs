using Revisao1.Models;

namespace Revisao1.Repositories
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private static List<Candidato> ListaCandidatos = new();
        private static List<Voto> ListaVotos = new();

        public void Cadastrar(Candidato candidato)
        {
            ListaCandidatos.Add(candidato);
        }

        public Candidato ObterPorNumero(int numero)
        {
            return ListaCandidatos.Where(c => c.Numero == numero).FirstOrDefault();
        }

        public List<Candidato> ObterTodos()
        {
            return ListaCandidatos;
        }

        public void RegistrarVoto(Voto voto)
        {
            ListaVotos.Add(voto);
        }
        public List<Voto> ObterVotosPorCandidato(int numero)
        {
            return ListaVotos.Where(v => v.NumeroCandidato == numero)
                .ToList();
        }
    }
}