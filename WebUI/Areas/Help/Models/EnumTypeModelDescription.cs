using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EZOper.CSharpSolution.WebUI.Areas.Help
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}