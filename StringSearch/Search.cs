﻿namespace StringSearch;
public static class Search
{
    public static List<string> FindLongestSubstring(string left, string right)
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
                var max = left.Length >= right.Length ? left.Length : right.Length;

                commonStrings.AddRange(FindCommonString(max, 0, max / 2, left, right));
        }

        return commonStrings;
    }

    private static List<string> FindCommonString(int high, int low, int middle, string left, string right)
    {
        var commonStrings = new List<string>();

        if (high == middle || low == middle)
        {
            return commonStrings;
        }

        var leftChunks = CreateChunks(left, middle);
        var rightChunks = CreateChunks(right, middle);

        commonStrings = leftChunks.Intersect(rightChunks).ToList();
        if (commonStrings.Any())
        {

            var cs = FindCommonString(high, middle, middle + (high - middle) / 2, left, right);
            if (cs.Any())
            {
                commonStrings = cs;
            }
        }
        else
        {
            var cs = FindCommonString(middle, low, middle - (middle - low) / 2, left, right);
            if (cs.Any())
            {
                commonStrings = cs;
            }

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
            var chunk = input.Substring(i, length);
            if (!chunks.Contains(chunk))
            {
                chunks.Add(input.Substring(i, length));
            }
        }
        return chunks;
    }
}
