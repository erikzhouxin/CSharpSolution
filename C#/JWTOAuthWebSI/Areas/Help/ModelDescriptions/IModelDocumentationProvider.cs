using System;
using System.Reflection;

namespace EZOper.TechTester.JWTOAuthWebSI.Areas.Help
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}