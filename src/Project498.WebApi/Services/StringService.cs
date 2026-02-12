namespace Project498.WebApi.Services;

public class StringService : IStringService
{
    public string Reverse(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        return ReverseCharacters(input);
    }
    
    // Followed the same general logic/rules as Reverse.
    // Used the Day 4 slides as a base for the code
    public string ReverseWords(string input) {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;
        
        var words = SplitInputBySpaces(input);
        
        if (words.Length == 1) {
            
            var word = words[0];

            if (ShouldReverseCharacters(word)) {
                return ReverseCharacters(word);
            }

            return word;
        }
        
        return ReverseArrayAndJoinWithSpaces(words);
    }

    private static bool ShouldReverseCharacters(string word) {
        // Word is multi-character and includes non-ASCII characters
        // Multi-character check is for optimization; unnecessary to allocate a new array if the operation is inherently idempotent
        return word.Length > 1 && word.Any(c => c > 127);
    }

    private static string ReverseArrayAndJoinWithSpaces(string[] words) {
        Array.Reverse(words);
        return string.Join(" ", words);
    }

    private static string ReverseCharacters(string word) {
        var chars = word.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    private static string[] SplitInputBySpaces(string input) {
        return input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }
}
