using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace MyGenerators.Generators.Model
{
    public class TypeModel
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public List<PropertyModel> Properties { get; set; }

        public TypeModel(INamedTypeSymbol symbol)
        {
            Name = symbol.Name;
            Namespace = symbol.ContainingNamespace.ToDisplayString();
            Properties = symbol
                .GetMembers()
                .Where(m => m.Kind == SymbolKind.Property)
                .Cast<IPropertySymbol>()
                .Select(s => new PropertyModel(s))
                .ToList();
        }
    }
}