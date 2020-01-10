using System;
namespace GolFullStack.Entity.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            Ativo = true;
        }

        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }


    }
}
