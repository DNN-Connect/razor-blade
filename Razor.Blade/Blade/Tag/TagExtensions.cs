// ReSharper disable RedundantArgumentDefaultValue

using System;

namespace Connect.Razor.Blade
{
    public static class TagExtensions
    {
        /// <summary>
        /// Quickly add an attribute
        /// it always returns the tag itself again, allowing chaining of multiple add-calls
        /// </summary>
        /// <param name="tag">the parent tag</param>
        /// <param name="name">the attribute name, or a complete value like "name='value'"</param>
        /// <param name="value">optional value - if the attribute already exists, it will be appended</param>
        /// <param name="appendSeparator">attribute appendSeparator in case the value is appended</param>
        /// <returns></returns>
        public static T Attr<T>(this T tag, string name, object value = null, string appendSeparator = null)
            where T: Tag
        {
            tag.TagAttributes.Add(name, value, appendSeparator);
            return tag;
        }


        /// <summary>
        /// ID - set multiple times always overwrites previous ID
        /// </summary>
        public static T Id<T>(this T tag, string id) where T: Tag
            => tag.Attr("id", id, null);

        /// <summary>
        /// class attribute
        /// </summary>
        public static T Class<T>(this T tag, string value) where T: Tag
            => tag.Attr("class", value, " ");

        /// <summary>
        /// style attribute. If called multiple times, will append styles.
        /// </summary>
        /// <param name="tag">the parent tag</param>
        /// <param name="value">Style to add</param>
        /// <returns></returns>
        public static T Style<T>(this T tag, string value) where T: Tag
            => tag.Attr("style", value, appendSeparator: ";");

        /// <summary>
        /// title attribute
        /// </summary>
        /// <param name="tag">the parent tag</param>
        /// <param name="value">new title to set</param>
        /// <returns></returns>
        public static T Title<T>(this T tag, string value) where T: Tag
            => tag.Attr("title", value, null);

        /// <summary>
        /// Add a data-... attribute
        /// </summary>
        /// <param name="tag">the parent tag</param>
        /// <param name="name">the term behind data-, so "name" becomes "data-name"</param>
        /// <param name="value">string or object, objects will be json serialized</param>
        /// <returns></returns>
        public static T Data<T>(this T tag, string name, object value = null) where T: Tag
            => tag.Attr("data-" + name, value, null);

        /// <summary>
        /// Add a data-... attribute
        /// </summary>
        /// <param name="tag">the parent tag</param>
        /// <param name="name">the term behind data-, so "name" becomes "data-name"</param>
        /// <param name="value">string or object, objects will be json serialized</param>
        /// <returns></returns>
        public static T On<T>(this T tag, string name, object value = null) where T : Tag
            => tag.Attr("on" + name, value, null);


        /// <summary>
        /// Add contents to this tag - at the end of the already added contents.
        /// If you want to replace the contents, use Wrap() instead
        /// </summary>
        /// <param name="tag">the parent tag</param>
        /// <param name="child"></param>
        /// <returns></returns>
        public static T Add<T>(this T tag, object child) where T : Tag
        {
            tag.TagChildren.Add(child);
            return tag;
        }

        /// <summary>
        /// Add contents to this tag - at the end of the already added contents.
        /// If you want to replace the contents, use Wrap() instead
        /// </summary>
        /// <param name="tag">the parent tag</param>
        /// <param name="child"></param>
        /// <param name="innerAction">code which runs below the child</param>
        /// <returns></returns>
        internal static T Add<T, TC>(this T tag, TC child, Action<TC> innerAction = null) where T : Tag where TC : Tag
        {
            tag.TagChildren.Add(child);
            innerAction?.Invoke(child);
            return tag;
        }


        ///// <summary>
        ///// Add contents to this tag - at the end of the already added contents.
        ///// If you want to replace the contents, use Wrap() instead
        ///// </summary>
        ///// <param name="tag">the parent tag</param>
        ///// <param name="child"></param>
        ///// <returns></returns>
        //internal static TC AddAndReturnChild<T, TC>(this T tag, TC child) where T : Tag where TC : Tag
        //{
        //    tag.TagChildren.Add(child);
        //    return child;
        //}

        /// <summary>
        /// Wrap the tag around the new content, so this replaces all the content with what you give it
        /// </summary>
        /// <param name="tag">the parent tag</param>
        /// <param name="content">New content - can be a string, Tag or list of tags</param>
        /// <returns></returns>
        public static T Wrap<T>(this T tag, object content) where T : Tag
        {
            tag.TagChildren.Replace(content);
            return tag;
        }
    }
}
