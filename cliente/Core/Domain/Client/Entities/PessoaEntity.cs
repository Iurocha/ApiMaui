namespace cliente.Core.Domain.Client.Entities
{
    public class PessoaEntity
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? CEP { get; set; }
    }
}
