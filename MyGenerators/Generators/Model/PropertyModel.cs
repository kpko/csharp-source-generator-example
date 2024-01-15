using Microsoft.CodeAnalysis;

namespace MyGenerators.Generators.Model
{
    public class PropertyModel
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public PropertyModel(IPropertySymbol symbol)
        {
            Name = symbol.Name;
            Type = symbol.Type.ToDisplayString();
        }
    }
}