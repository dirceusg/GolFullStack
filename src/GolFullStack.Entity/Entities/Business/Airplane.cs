using System;
namespace GolFullStack.Entity.Entities.Business
{
    public class Airplane : Entity
    {
        public DateTime RegistradoEm { get; set; }
        public string Modelo { get; set; }
        public int QuantidadePassageiros { get; set; }

    }
}
