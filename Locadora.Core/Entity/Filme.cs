using Locadora.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Locadora.Core.Entity
{
    class Filme : IEntity
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Ano { get; set; }
        public string Observacao { get; set; }
        
        [NotMapped]
        public virtual Categoria Categoria { get; set; }
        public int CategoriaID { get; set; }
    }
}
