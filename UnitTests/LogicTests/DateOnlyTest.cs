using FluentAssertions;

namespace UnitTests.LogicTests;

public class DateOnlyTest
{
    public record Test(DateOnly? date = null);

    private DateOnly now = DateOnly.FromDateTime(DateTime.Now);


    public DateOnlyTest()
    {
    }

    [Fact]
    public void TestNullComparer()
    {
        var newTest = new Test();

        var result = CompareDate(newTest, now);
        result.Should().BeFalse();
    }

    public bool CompareDate(Test date1, DateOnly date2)
    {
        return date1.date <= date2;
    }
}