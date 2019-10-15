using Connect.Razor.Blade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Razor_Blades_Tests.Html5QuickAccess
{
    [TestClass]
    public class TableTestsQa: TagTestBase
    {
        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void TableBasic()
        {
            Is("<table></table>", 
                Tags.Table());
        }

        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void TableWithRowAnd2Cells()
        {
            Is("<table><tr><td></td><td></td></tr></table>",
                Tags.Table(
                    Tags.Tr(Tags.Td(), Tags.Td())
                )
            );

            Is("<table><tr><td></td><td></td></tr></table>",
                Tags.Table(
                    Tags.Tr(
                        Tags.Td(),
                        Tags.Td()
                    )
                )
            );

            Is("<table><tr><td></td><td></td></tr></table>",
                Tags.Table()
                    .Add(Tags.Tr(Tags.Td(), Tags.Td())));
            Is("<table><tr><td></td><td></td></tr></table>",
                Tags.Table()
                    .Add(Tags.Tr()
                        .Add(Tags.Td(), Tags.Td())));
            Is("<table><tr><td></td><td></td></tr></table>",
                Tags.Table()
                    .Add(Tags.Tr()
                        .Add(Tags.Td())
                        .Add(Tags.Td())
                    )
            );

            // the same thing using wrap
            Is("<table><tr><td></td><td></td></tr></table>",
                Tags.Table()
                    .Wrap(Tags.Tr(Tags.Td(), Tags.Td())));
            Is("<table><tr><td></td><td></td></tr></table>",
                Tags.Table()
                    .Wrap(Tags.Tr()
                        .Wrap(Tags.Td(), Tags.Td())));
            Is("<table><tr><td></td></tr></table>",
                Tags.Table()
                    .Wrap(Tags.Tr()
                        .Wrap(Tags.Td())
                        .Wrap(Tags.Td())
                    )
            );

        }

        [TestMethod]
        public void TrChaining()
        {
            Is("<table><tr></tr></table>",
                Tags.Table(Tags.Tr()));
            Is("<table><tr></tr><tr></tr></table>",
                Tags.Table(Tags.Tr(), Tags.Tr()));
            Is("<table><tr><td></td></tr></table>",
                Tags.Table(
                    Tags.Tr(
                        Tags.Td()
                    )
                )
            );

            Is("<table><tr><td></td></tr><tr><td></td></tr></table>",
                Tags.Table(
                    Tags.Tr(
                        Tags.Td()
                    ),
                    Tags.Tr(
                        Tags.Td()
                    )
                )

            );

        }


    }
}
