using Revisao1.Models;

namespace Revisao1.Repositories
{
    public interface ICandidatoRepository
    {
        void Cadastrar(Candidato candidato);
        public List<Candidato> ObterTodos();
        Candidato ObterPorNumero(int numero);
        void RegistrarVoto(Voto voto);
        List<Voto> ObterVotosPorCandidato(int numero);
    }
}
