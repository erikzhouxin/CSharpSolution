using System;
using System.Reflection;

namespace EZOper.TechTester.EZWebTemplate.Areas.Help
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}