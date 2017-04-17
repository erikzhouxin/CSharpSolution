using System;
using System.Reflection;

namespace EZOper.TechTester.CSharpWebSI.Areas.ZApi
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}