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
    public void NoCommonStringFoundForEmptyInputLeft()
    {
        Assert.That(Search.FindLongestCommonString("", "right"), Has.Count.EqualTo(0));
    }

    [Test]
    public void NoCommonStringFoundForEmptyInputRight()
    {
        Assert.That(Search.FindLongestCommonString("left", ""), Has.Count.EqualTo(0));
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

    [Test]
    public void CommonStringFoundOneChar()
    {
        Assert.That(Search.FindLongestCommonString("a", "aa"), Has.Count.EqualTo(2));
    }

    [Test]
    public void CommonStringFoundOneCharDifferent()
    {
        Assert.That(Search.FindLongestCommonString("a", "Banane"), Has.Count.EqualTo(2));
    }
}