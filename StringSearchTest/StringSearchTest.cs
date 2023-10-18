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
    public void CommonStringFoundForIdenticalStrings()
    {
        Assert.That(Search.FindLongestCommonString("SameString", "SameString"), Has.Count.EqualTo(1));
    }

    [Test]
    public void CommonStringFoundOneChar()
    {
        Assert.That(Search.FindLongestCommonString("a", "aa"), Has.Count.EqualTo(1));
    }

    [Test]
    public void CommonStringFoundOneCharDifferent()
    {
        Assert.That(Search.FindLongestCommonString("a", "Banane"), Has.Count.EqualTo(1));
    }

    [Test]
    public void CommonStringFoundTwoCharLeft()
    {
        const string expectedCommonString = "ab";
        var commonStrings = Search.FindLongestCommonString(expectedCommonString, expectedCommonString + "ac" + expectedCommonString);
        
        Assert.That(commonStrings, Has.Count.EqualTo(1));

        Assert.That(commonStrings, Contains.Item(expectedCommonString));
    }

    [Test]
    public void CommonStringFoundTwoCharRight()
    {
        const string expectedCommonString = "ab";
        var commonStrings = Search.FindLongestCommonString(expectedCommonString + "ac" + expectedCommonString, expectedCommonString);

        Assert.That(commonStrings, Has.Count.EqualTo(1));

        Assert.That(commonStrings, Contains.Item(expectedCommonString));
    }


    #region CreateChunks
    [Test]
    public void NoChunksForLengthZero()
    {
        Assert.That(Search.CreateChunks("Hello", 0), Has.Count.EqualTo(0));
    }

    [Test]
    public void FoundChunksOfLenthOneWithDuplicatedChars()
    {
        const string input = "Hello";
        Assert.That(Search.CreateChunks(input, 1), Has.Count.EqualTo(4));
    }

    [Test]
    public void FoundChunksForLengthThree()
    {
        const string input = "Hello";
        Assert.That(Search.CreateChunks(input, 3), Has.Count.EqualTo(3));
    }
    #endregion
}