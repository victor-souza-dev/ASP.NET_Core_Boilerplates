using System.Text.RegularExpressions;

namespace Infrastructure.Helpers;
public class QueryManipulator {
    public string FormatQuery(string query) {
        if (string.IsNullOrWhiteSpace(query)) {
            return string.Empty;
        }

        query = RemoveSpecialCharacters(query.ToLower());

        return query;
    }

    private static string RemoveSpecialCharacters(string input) {
        return Regex.Replace(input, "[^a-zA-Z0-9]", "");
    }
}
