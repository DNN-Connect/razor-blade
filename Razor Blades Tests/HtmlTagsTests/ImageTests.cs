using Connect.Razor.Blade;
using Connect.Razor.Blade.Html5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.HtmlTagsTests
{
    [TestClass]
    public class ImageTests: TagTestBase
    {
        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void Img()
        {
            Is("<img>", 
                new Img());
            Is("<img src='https://azing.org'>", 
                new Img("https://azing.org"));
            Is("<img src='https://azing.org'>", 
                new Img().Src("https://azing.org"));

        }


        [TestMethod]
        public void ImgSizes()
        {
            Is("<img src='xyz' height='8' width='7'>", 
                new Img("xyz", 7, 8));

            Is("<img src='xyz' height='8' width='7'>",
                new Img("xyz").Height(8).Width(7));
        }

        [TestMethod]
        public void ImgSrcSetX()
        {
            Is("<img src='xyz.jpg' srcset='xyz.jpg?w=400 2x'>", 
                new Img("xyz.jpg").Srcset(2, "xyz.jpg?w=400"));

            Is("<img src='xyz.jpg' srcset='xyz.jpg?w=400 2x,xyz.jpg?w=600 3x'>", 
                new Img("xyz.jpg")
                    .Srcset(2, "xyz.jpg?w=400")
                    .Srcset(3, "xyz.jpg?w=600"));

            Is("<img src='xyz.jpg' srcset='xyz.jpg?w=400 2x,xyz.jpg?w=600 3x,xyz-large.jpg 4x'>",
                new Img("xyz.jpg")
                    .Srcset(2, "xyz.jpg?w=400")
                    .Srcset(3, "xyz.jpg?w=600")
                    .Srcset(4, "xyz-large.jpg"));

            Is("<img src='xyz' height='8' width='7' srcset='xyz.jpg?w=400 2x'>", 
                new Img("xyz", 7, 8)
                    .Srcset(2, "xyz.jpg?w=400"));
        }

        [TestMethod]
        public void ImgSrcSetW()
        {
            Is("<img src='xyz.jpg' srcset='xyz.jpg?w=400 100w'>",
                new Img("xyz.jpg")
                    .Srcset(100, "xyz.jpg?w=400"));

            Is("<img src='xyz.jpg' srcset='xyz.jpg?w=400 100w,xyz.jpg?w=600 200w'>",
                new Img("xyz.jpg")
                    .Srcset(100, "xyz.jpg?w=400")
                    .Srcset(200, "xyz.jpg?w=600"));

            Is("<img src='xyz.jpg' srcset='xyz.jpg?w=400 100w,xyz.jpg?w=600 300w,xyz-large.jpg 1000w'>",
                new Img("xyz.jpg")
                    .Srcset(100, "xyz.jpg?w=400")
                    .Srcset(300, "xyz.jpg?w=600")
                    .Srcset(1000, "xyz-large.jpg"));

            Is("<img src='xyz' height='8' width='7' srcset='xyz.jpg?w=400 100w'>",
                new Img("xyz", 7, 8)
                    .Srcset(100, "xyz.jpg?w=400"));
        }


        [TestMethod]
        public void NoDuplicateAttributes()
        {
            Is("<img src='xyz' width='12'>", 
                new Img("xyz", 7).Width(12));

            Is("<img src='xyz' width='15'>",
                new Img("xyz").Width(14).Width("15"));
        }

        [TestMethod]
        public void PictureBasic()
        {
            Is("<picture></picture>", new Picture());
            Is("<picture><img src='https://azing.org'></picture>",
                new Picture(new Img("https://azing.org")));

        }

        [TestMethod]
        public void PictureWithSources()
        {
            Is("<picture>" +
               "<source srcset='something.jpg'>" +
               "<source srcset='other.webp' type='image/webp'>" +
               "<img src='https://azing.org'>" +
               "</picture>",
                new Picture(new Tag[]
                    {
                        new PictureSource("something.jpg"), 
                        new PictureSource("other.webp", type: "image/webp"), 
                        new Img("https://azing.org")
                    }
                ));

        }

    }
}
