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
            commonStrings.AddRange(from rightChar in right.ToCharArray()
                                   where left[0] == rightChar
                                   select left);
        }



        return commonStrings;
    }
}
