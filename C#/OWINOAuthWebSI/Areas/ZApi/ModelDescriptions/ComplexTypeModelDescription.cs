using System.Collections.ObjectModel;

namespace EZOper.TechTester.OWINOAuthWebSI.Areas.ZApi
{
    public class ComplexTypeModelDescription : ModelDescription
    {
        public ComplexTypeModelDescription()
        {
            Properties = new Collection<ParameterDescription>();
        }

        public Collection<ParameterDescription> Properties { get; private set; }
    }
}