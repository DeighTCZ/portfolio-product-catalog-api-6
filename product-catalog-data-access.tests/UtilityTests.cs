using FluentAssertions;
using Xunit;

namespace product_catalog_data_access.tests;

public class UtilityTests
{
    [Fact]
    public void SkipForPage_FirstPage()
    {
        const int Page = 1;
        const int Itemscount = 10;

        var skip = Utility.SkipForPage(Page, Itemscount);

        skip.Should().Be(0);
    }

    [Theory]
    [InlineData(2,10,10)]
    [InlineData(2,20,20)]
    [InlineData(6,10,50)]
    [InlineData(10,20,180)]
    [InlineData(10,10,90)]
    public void SkipForPage_OtherPages(int page, int itemsCount, int skip)
    {
        var skipForPage = Utility.SkipForPage(page, itemsCount);

        skipForPage.Should().Be(skip);
    }
}
