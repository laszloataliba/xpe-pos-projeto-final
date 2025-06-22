namespace XPE.Desafio.Final5.API.Model.Domains
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.Empty;
        }

        public Guid Id { get; set; }
    }
}
