namespace Connect.Razor.Interfaces
{
    /// <summary>
    /// Shared Properties which both the page and the header have
    /// </summary>
    public interface IPageAndHeader
    {
        /// <summary>
        /// The current page title
        /// Will return null if not running in a page context.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Get/Set description of this page
        /// Will return null if not running in a page context.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Get/Set keywords of this page
        /// Will return null if not running in a page context.
        /// </summary>
        string Keywords { get; set; }

    }
}
