using System.Collections.ObjectModel;

namespace EZOper.TechTester.EZWebTemplate.Areas.Help
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