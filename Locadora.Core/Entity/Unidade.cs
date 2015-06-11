using Locadora.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Locadora.Core.Entity
{
    public class Unidade : IEntity
    {
        public int ID { get; set; }
        
        
        [NotMapped]
        public virtual Filme Filme { get; set; }
        public int FilmeID { get; set; }

        [NotMapped]
        public virtual Tipo Tipo { get; set; }
        public int TipoID { get; set; }       
        public decimal Valor { get; set; }
    }
}
