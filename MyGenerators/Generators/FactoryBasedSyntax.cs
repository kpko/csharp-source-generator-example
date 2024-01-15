using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace MyGenerators.Generators
{
    public static class FactoryBasedSyntax
    {
        public static string GenerateSyntax(INamedTypeSymbol type)
        {
            var unit = SyntaxFactory.CompilationUnit();
            unit = unit.AddUsings(
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")),
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Collections")),
                SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("MyGenerators"))
            );

            var ns = SyntaxFactory
                .NamespaceDeclaration(SyntaxFactory.ParseName(type.ContainingNamespace.ToDisplayString()))
                .NormalizeWhitespace();

            var cls = SyntaxFactory.ClassDeclaration(type.Name)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.PartialKeyword))
                .AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(nameof(ISupportDictionaryConversion))));

            var writeMethod = SyntaxFactory
                .MethodDeclaration(SyntaxFactory.ParseTypeName("void"), nameof(ISupportDictionaryConversion.WriteToDictionary))
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .WithBody(SyntaxFactory.Block(SyntaxFactory.ParseStatement("")));
            
            // ...Further implementation...

            cls = cls.AddMembers();
            ns = ns.AddMembers(cls);
            unit = unit.AddMembers(ns);

            var source = unit.NormalizeWhitespace().ToFullString();
            return source;
        }
    }
}