using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Locadora.Core.CustomAttributes
{
    [System.AttributeUsage(System.AttributeTargets.Property,
                       AllowMultiple = true)  // Multiuse attribute.
    ]
    public class NotMapped : Attribute { }
}
