namespace StringSearch;
public static class Search
{
    public static List<string> FindLongestCommonString(string left, string right)
    {
        var commonStrings = new List<string>();
        
        if (string.IsNullOrEmpty(left) || string.IsNullOrEmpty(right))
        {
            return commonStrings;
        }

        if (left.Equals(right))
        {
            commonStrings.Add(left);
        }
        else
        {
            var rightChunks = CreateChunks(right, left.Length);

            commonStrings.AddRange(from chunk in rightChunks
                                   where left.Equals(chunk)
                                   select left);
        }

        return commonStrings;
    }

    public static List<string> CreateChunks(string input, int length)
    {
        var chunks = new List<string>();

        if (length == 0)
        {
            return chunks;
        }

        for (var i = 0; i <= input.Length - length; i++)
        {
            chunks.Add(input.Substring(i, length));
        }
        return chunks;
    }
}
