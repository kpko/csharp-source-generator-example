using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace MyGenerators.Generators
{
    [Generator(LanguageNames.CSharp)]
    public class MyIncrementalGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var provider = context.SyntaxProvider.ForAttributeWithMetadataName(
                $"{nameof(MyGenerators)}.{nameof(GenerateDictionaryConverterMethodsAttribute)}",
                (n, _) => n.IsKind(SyntaxKind.ClassDeclaration),
                (ctx, _) => (INamedTypeSymbol)ctx.TargetSymbol);

            var compilation = context.CompilationProvider.Combine(provider.Collect());
            context.RegisterSourceOutput(compilation, (ctx, source) => Execute(ctx, source.Right));
        }

        private void Execute(SourceProductionContext ctx, ImmutableArray<INamedTypeSymbol> types)
        {
            try
            {
                foreach (var type in types)
                {
                    var source = StubbleBasedGenerator.GenerateSyntax(type);
                    ctx.AddSource($"DictionaryHelpers.{type.Name}.g.cs", source);
                }
            }
            catch (Exception ex)
            {
                var desc = new DiagnosticDescriptor("GEN001",
                    "Error in syntax generation",
                    $"{ex}",
                    "MyIncrementalGenerator",
                    DiagnosticSeverity.Error, true);
                var diag = Diagnostic.Create(desc, Location.None);
                ctx.ReportDiagnostic(diag);
            }
        }
    }
}