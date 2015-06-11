using Locadora.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Locadora.Core.Entity
{
    class Locacao : IEntity
    {
        public int ID { get; set; }
        
        [NotMapped]
        public virtual Cliente Cliente { get; set; }
        public int ClienteID { get; set; }
                
        [NotMapped]
        public virtual Unidade Unidade { get; set; }
        public int UnidadeID { get; set; }

        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public decimal Valor { get; set; }
    }
}
