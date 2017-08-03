using System;
using System.Reflection;

namespace EZOper.CSharpSolution.WebUI.Areas.Help
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}