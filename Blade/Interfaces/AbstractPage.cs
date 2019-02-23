namespace Connect.Razor.Interfaces
{
    public abstract class AbstractPage: IPage
    {
        public string Title
        {
            get => Header.Title;
            set => Header.Title = value;
        }

        public IPageHeader Header => _header ?? (_header = CreateHeader());

        protected abstract IPageHeader CreateHeader();

        private IPageHeader _header;

    }
}
