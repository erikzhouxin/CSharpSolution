using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EZOper.TechTester.OWINOAuthWebSI.Areas.ZApi
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