using StringSearch;

namespace StringSearchTest;
public class StringSearchTest
{
    [SetUp]
    public void Setup()
    {
        // not setup so far
    }

    [Test]
    public void NoCommonStringFound()
    {
        Assert.That(Search.FindLongestCommonString("a", "b"), Has.Count.EqualTo(0));
    }

    [Test]
    public void CommonStringFoundForStringLengthOne()
    {
        Assert.That(Search.FindLongestCommonString("a", "a"), Has.Count.EqualTo(1));
    }
}