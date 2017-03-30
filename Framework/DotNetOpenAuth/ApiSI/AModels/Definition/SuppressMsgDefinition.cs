using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EZOper.TechTester.OAuth2ApiSI
{
    public class SuppressMsgDefinition
    {
        public const string CA1054 = "CA1054:UriParametersShouldNotBeStrings";
        public const string JCA10541 = "Needs to take same parameter type as Controller.Redirect()";
    }
}