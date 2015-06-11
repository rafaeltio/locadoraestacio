using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Locadora.Core.Entity
{
    class Unidade : IEntity
    {
        public int ID { get; set; }
        public virtual Filme Filme { get; set; }
        //public enum MyProperty { get; set; }
        public decimal Valor { get; set; }
    }
}
