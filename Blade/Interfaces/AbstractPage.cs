//namespace Connect.Razor.Interfaces
//{
//    public abstract class AbstractPage: IPage
//    {
//        public abstract string Title { get; set; }

//        public abstract string Description { get; set; }

//        public abstract string Keywords { get; set; }

//        public abstract void AddHeader(string tag);

//        public void AddMeta(string name, string content) 
//            => AddHeader($"<meta name=\'{name}\' content=\'{AttributeEncode(content)}\' /> ");

//        public void AddOpenGraph(string property, string content) 
//            => AddHeader($"<meta property=\'{property}\' content=\'{AttributeEncode(content)}\' /> ");

//        protected abstract string AttributeEncode(string original);
//    }
//}
