using System.Collections.Generic;
using System.Linq;
using SourceCodeGenerator.Parts;

namespace SourceCodeGenerator.Configuration
{
    public abstract class TagsBase
    {
        internal abstract string GroupName { get; }

        internal static List<TagCodeGenerator> MakeList(string[] stringList, bool standalone = false)
        {
            var list = stringList
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => new TagCodeGenerator(s) { Standalone = standalone })
                .ToList();
            return list;
        }

        public abstract List<TagCodeGenerator> List { get; }

        public List<TagCodeGenerator> SortedList => List.OrderBy(c => c.ClassName).ToList();

        public string GenerateCode() => string.Join("\n", SortedList.Select(c => c.Code()));

    }
}
