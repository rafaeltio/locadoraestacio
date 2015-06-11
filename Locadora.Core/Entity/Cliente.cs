using Locadora.Core.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locadora.Core.Entity
{
    public class Cliente : IEntity
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public Nullable<DateTime> Nascimento { get; set; }
    }
}
