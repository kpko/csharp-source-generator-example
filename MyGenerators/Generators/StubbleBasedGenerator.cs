using System;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;
using MyGenerators.Generators.Model;
using Stubble.Core.Builders;

namespace MyGenerators.Generators
{
    public static class StubbleBasedGenerator
    {
        public static string GenerateSyntax(INamedTypeSymbol type)
        {
            using var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("MyGenerators.Generators.Template.mustache")
                                 ?? throw new Exception("Generator template not found");

            using var reader = new StreamReader(resource);
            var content = reader.ReadToEnd();

            var stubble = new StubbleBuilder().Build();

            var result = stubble.Render(content, new
            {
                Type = new TypeModel(type)
            });
            return result;
        }
    }
}