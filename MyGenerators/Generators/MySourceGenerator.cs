namespace MyGenerators.Generators
{
    // [Generator]
    // public class MySourceGenerator : ISourceGenerator
    // {
    //     public void Initialize(GeneratorInitializationContext context)
    //     {
    //     }
    //
    //     public void Execute(GeneratorExecutionContext context)
    //     {
    //         var s = context.Compilation
    //             .GetSymbolsWithName(x => true, SymbolFilter.Type)
    //             .ToList();
    //
    //         var types = s.OfType<INamedTypeSymbol>()
    //             .Where(a => a.GetAttributes().Any(b => b.AttributeClass?.Name == nameof(GenerateDictionaryConverterMethodsAttribute)))
    //             .ToList();
    //
    //         foreach (var type in types)
    //         {
    //             var source = StringBasedSyntax.GenerateSyntax(type);
    //             context.AddSource($"DictionaryHelpers.{type.Name}.g.cs", source);
    //         }
    //     }
    // }
}