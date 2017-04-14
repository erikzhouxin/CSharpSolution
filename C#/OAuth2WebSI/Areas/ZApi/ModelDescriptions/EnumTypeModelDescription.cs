using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EZOper.TechTester.OAuth2WebSI.Areas.ZApi
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