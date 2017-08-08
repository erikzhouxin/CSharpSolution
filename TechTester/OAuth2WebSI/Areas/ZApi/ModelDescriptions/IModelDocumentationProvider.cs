using System;
using System.Reflection;

namespace EZOper.TechTester.OAuth2WebSI.Areas.ZApi
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}