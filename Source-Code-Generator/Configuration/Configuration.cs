namespace SourceCodeGenerator.Configuration
{
    public class Configuration
    {

        public static TagsBase[] GetTagGroupsToGenerate()
        {
            return new TagsBase[]
            {
                new TagsFormatting(),
                new TagsSimple(),
                new TagsImages(),
                new TagsLinks(),
                new TagsFrames(), 
                // new TagsForms(),
                new TagsMedia(),
                new TagsTables(),
            };
        }



        // ReSharper restore StringLiteralTypo

        // todo: forms/input

        // todo: tables
        // todo: styles/semantics

        // todo: meta
        // todo: programming
    }
}
