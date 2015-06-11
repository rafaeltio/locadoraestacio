using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Locadora.Core.Entity
{
    class Categoria : IEntity
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
    }
}
