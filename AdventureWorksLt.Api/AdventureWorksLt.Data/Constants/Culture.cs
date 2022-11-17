using System.Globalization;

namespace AdventureWorksLt.Data.Constants;

public class Culture
{
    public static readonly string Current = GetCulture(CultureInfo.CurrentCulture);
    
    private static string GetCulture(CultureInfo culture)
    {
        return string.IsNullOrEmpty(culture.Parent.Name)
            ? culture.Name
            : GetCulture(culture.Parent);
    }
}