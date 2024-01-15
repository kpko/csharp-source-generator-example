using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGenerators;
using TestApp;

var firstObject = new Test() { Name = "John Doe", Age = 42 };
var tempDictionary = new Dictionary<string, object?>();
firstObject.WriteToDictionary(tempDictionary);

var secondObject = new Test2();
secondObject.ReadFromDictionary(tempDictionary);

Assert.AreEqual("John Doe", secondObject.Name);
Assert.AreEqual(42, secondObject.Age);

namespace TestApp
{
    [GenerateDictionaryConverterMethods]
    public partial class Test
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    [GenerateDictionaryConverterMethods]
    public partial class Test2
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}