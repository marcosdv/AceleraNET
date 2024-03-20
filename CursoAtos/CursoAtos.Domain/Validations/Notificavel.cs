namespace CursoAtos.Domain.Validations;

public abstract class Notificavel
{
    private readonly List<string> _notificacoes;

    protected Notificavel()
    {
        _notificacoes = new List<string>();
    }

    public void AddNotificacao(string mensagem)
    {
        _notificacoes.Add(mensagem);
    }

    public IReadOnlyCollection<string> Notificacoes => _notificacoes;

    public bool DeuErro => _notificacoes.Any(); //verdadeiro se existir um ou mais itens e false se for vazio

    public bool DeuCerto => !DeuErro;
}