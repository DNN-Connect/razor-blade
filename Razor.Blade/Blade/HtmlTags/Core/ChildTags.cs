using System.Collections.Generic;
using System.Linq;

namespace Connect.Razor.Blade.HtmlTags
{
    public class ChildTags: List<Tag>
    {
        public void Add(object child)
        {
            if (child is ChildTags list)
                AddRange(list);
            else
                base.Add(Tag.EnsureTag(child));
        }

        public void Replace(object child)
        {
            Clear();
            Add(child);
        }

        internal string Build(TagOptions options)
        {
            if (!this.Any())
                return "";
            return string.Join("", this.Select(c => c.ToString(c.Options ?? options)));
        }

    }
}
