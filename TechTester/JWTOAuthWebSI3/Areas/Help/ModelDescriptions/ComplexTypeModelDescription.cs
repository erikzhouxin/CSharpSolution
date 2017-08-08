using System.Collections.ObjectModel;

namespace EZOper.TechTester.JWTOAuthWebSI3.Areas.Help
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