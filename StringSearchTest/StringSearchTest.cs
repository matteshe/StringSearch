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
        Assert.That(Search.findLongestSubstring("", "right"), Has.Count.EqualTo(0));
    }

    [Test]
    public void NoCommonStringFoundForEmptyInputRight()
    {
        Assert.That(Search.findLongestSubstring("left", ""), Has.Count.EqualTo(0));
    }

    [Test]
    public void NoCommonStringFound()
    {
        Assert.That(Search.findLongestSubstring("a", "b"), Has.Count.EqualTo(0));
    }

    [Test]
    public void CommonStringFoundForIdenticalStrings()
    {
        Assert.That(Search.findLongestSubstring("SameString", "SameString"), Has.Count.EqualTo(1));
    }

    [Test]
    public void CommonStringFoundOneChar()
    {
        Assert.That(Search.findLongestSubstring("a", "aa"), Has.Count.EqualTo(1));
    }

    [Test]
    public void CommonStringFoundOneCharDifferent()
    {
        Assert.That(Search.findLongestSubstring("a", "Banane"), Has.Count.EqualTo(1));
    }

    [Test]
    public void CommonStringFoundTwoCharLeft()
    {
        const string expectedCommonString = "ab";
        var commonStrings = Search.findLongestSubstring(expectedCommonString, expectedCommonString + "ac" + expectedCommonString);
        
        Assert.That(commonStrings, Has.Count.EqualTo(1));

        Assert.That(commonStrings, Contains.Item(expectedCommonString));
    }

    [Test]
    public void CommonStringFoundTwoCharRight()
    {
        const string expectedCommonString = "ab";
        var commonStrings = Search.findLongestSubstring(expectedCommonString + "ac" + expectedCommonString, expectedCommonString);

        Assert.That(commonStrings, Has.Count.EqualTo(1));

        Assert.That(commonStrings, Contains.Item(expectedCommonString));
    }

    [Test]
    public void CommonStringFoundInTheMiddle()
    {
        const string expectedCommonString = " eat ";
        const string leftSentence = "An ape eat banana";
        const string rightSentence = "I eat food";

        var commonStrings = Search.findLongestSubstring(leftSentence, rightSentence);

        Assert.That(commonStrings, Has.Count.EqualTo(1));

        Assert.That(commonStrings, Contains.Item(expectedCommonString));
    }

    [Test]
    public void MultipleCommonStringButOnlyOneLongestFound()
    {
        const string expectedCommonString = " banana";
        const string leftSentence = "An ape eat banana";
        const string rightSentence = "I eat also banana";

        var commonStrings = Search.findLongestSubstring(leftSentence, rightSentence);

        Assert.That(commonStrings, Has.Count.EqualTo(1));
        Assert.That(commonStrings, Contains.Item(expectedCommonString));
    }

    [Test]
    public void MultipleCommonStringSameLengthFound()
    {
        const string leftSentence = "monday tuesday wednesday thursday friday satureday sunday";
        const string rightSentence = "wednesday sunday monday friday thursday tuesday satureday";

        var commonStrings = Search.findLongestSubstring(leftSentence, rightSentence);

        Assert.That(commonStrings, Has.Count.EqualTo(2));
        Assert.That(commonStrings, Contains.Item("day thursday "));
        Assert.That(commonStrings, Contains.Item("day satureday"));
    }

    [Test]
    public void EntwicklerheldTestDataOne()
    {
        const string leftSentence = "CHECKITWHEREISTHELONGESTSUBSTRING24";
        const string rightSentence = "SUBSTINGWHERECHECKITANTCHECK24ISCHECKWHERE";

        var commonStrings = Search.findLongestSubstring(leftSentence, rightSentence);

        Assert.That(commonStrings, Contains.Item("CHECKIT"));
        Assert.That(commonStrings, Has.Count.EqualTo(1));
    }

    [Test]
    public void EntwicklerheldTestDataTwo()
    {
        const string leftSentence = "247WECODEONLINEONENTWICKLERHELDDECHECKITOUT";
        const string rightSentence = "CHECKITOUTWECODEONLINEON24ENTWICKLERHELDOUT";

        var commonStrings = Search.findLongestSubstring(leftSentence, rightSentence);

        Assert.That(commonStrings, Contains.Item("WECODEONLINEON"));
        Assert.That(commonStrings, Contains.Item("ENTWICKLERHELD"));
        Assert.That(commonStrings, Has.Count.EqualTo(2));
    }

    [Test]
    public void EntwicklerheldTestDataThree()
    {
        const string leftSentence = "DONUTSAREDELICIOUSBUTIALSOLOVECHECK24PIZZA";
        const string rightSentence = "PIZZASAREYUMMYBUTIDOALSOLOVEDONUTSFROMCHECK24";

        var commonStrings = Search.findLongestSubstring(leftSentence, rightSentence);

        Assert.That(commonStrings, Contains.Item("ALSOLOVE"));
        Assert.That(commonStrings, Has.Count.EqualTo(1));
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

    [Test]
    public void IntersectTwoListsWithOneCommonItem()
    {
        var a = new List<string> { "1", "2" };
        var b = new List<string> { "3", "2" };

        var c = a.Intersect(b);

        Assert.That(c, Contains.Item("2"));

    }
}