using System.Collections.Generic;

namespace MyGenerators
{
    public interface ISupportDictionaryConversion
    {
        void WriteToDictionary(IDictionary<string, object> dictionary);
        void ReadFromDictionary(IReadOnlyDictionary<string, object> dictionary);
    }
}