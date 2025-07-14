using System.Text;

namespace SeoUrlGenerator.LanguageReplacers;

/// <summary>
/// Character replacement methods for Turkic languages
/// </summary>
internal static class TurkicLanguageReplacer
{
    /// <summary>
    /// Replaces Turkish characters with their English equivalents
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Turkish characters replaced</returns>
    internal static string ReplaceTurkishCharacters(string text)
    {
        var turkishChars = new Dictionary<char, char>
        {
            {'ç', 'c'}, {'Ç', 'c'},
            {'ğ', 'g'}, {'Ğ', 'g'},
            {'ı', 'i'}, {'I', 'i'},
            {'İ', 'i'}, {'ö', 'o'},
            {'Ö', 'o'}, {'ş', 's'},
            {'Ş', 's'}, {'ü', 'u'},
            {'Ü', 'u'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in turkishChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }

        return sb.ToString();
    }

    /// <summary>
    /// Replaces Azerbaijani characters with their English equivalents
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Azerbaijani characters replaced</returns>
    internal static string ReplaceAzerbaijaniCharacters(string text)
    {
        var azerbaijaniChars = new Dictionary<char, char>
        {
            {'ə', 'e'}, {'Ə', 'e'}, // schwa
            {'ç', 'c'}, {'Ç', 'c'},
            {'ğ', 'g'}, {'Ğ', 'g'},
            {'ı', 'i'}, {'I', 'i'},
            {'İ', 'i'}, {'ö', 'o'},
            {'Ö', 'o'}, {'ş', 's'},
            {'Ş', 's'}, {'ü', 'u'},
            {'Ü', 'u'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in azerbaijaniChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }

        return sb.ToString();
    }

    /// <summary>
    /// Replaces Kazakh characters with their English equivalents
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Kazakh characters replaced</returns>
    internal static string ReplaceKazakhCharacters(string text)
    {
        var kazakhChars = new Dictionary<char, string>
        {
            {'а', "a"}, {'А', "a"}, {'ә', "a"}, {'Ә', "a"},
            {'б', "b"}, {'Б', "b"}, {'в', "v"}, {'В', "v"},
            {'г', "g"}, {'Г', "g"}, {'ғ', "gh"}, {'Ғ', "gh"},
            {'д', "d"}, {'Д', "d"}, {'е', "e"}, {'Е', "e"},
            {'ё', "yo"}, {'Ё', "yo"}, {'ж', "zh"}, {'Ж', "zh"},
            {'з', "z"}, {'З', "z"}, {'и', "i"}, {'И', "i"},
            {'й', "y"}, {'Й', "y"}, {'к', "k"}, {'К', "k"},
            {'қ', "q"}, {'Қ', "q"}, {'л', "l"}, {'Л', "l"},
            {'м', "m"}, {'М', "m"}, {'н', "n"}, {'Н', "n"},
            {'ң', "ng"}, {'Ң', "ng"}, {'о', "o"}, {'О', "o"},
            {'ө', "o"}, {'Ө', "o"}, {'п', "p"}, {'П', "p"},
            {'р', "r"}, {'Р', "r"}, {'с', "s"}, {'С', "s"},
            {'т', "t"}, {'Т', "t"}, {'у', "u"}, {'У', "u"},
            {'ұ', "u"}, {'Ұ', "u"}, {'ү', "u"}, {'Ү', "u"},
            {'ф', "f"}, {'Ф', "f"}, {'х', "kh"}, {'Х', "kh"},
            {'һ', "h"}, {'Һ', "h"}, {'ц', "ts"}, {'Ц', "ts"},
            {'ч', "ch"}, {'Ч', "ch"}, {'ш', "sh"}, {'Ш', "sh"},
            {'щ', "shch"}, {'Щ', "shch"}, {'ъ', ""}, {'Ъ', ""},
            {'ы', "y"}, {'Ы', "y"}, {'і', "i"}, {'І', "i"},
            {'ь', ""}, {'Ь', ""}, {'э', "e"}, {'Э', "e"},
            {'ю', "yu"}, {'Ю', "yu"}, {'я', "ya"}, {'Я', "ya"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in kazakhChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Replaces Kyrgyz characters with their English equivalents
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Kyrgyz characters replaced</returns>
    internal static string ReplaceKyrgyzCharacters(string text)
    {
        var kyrgyzChars = new Dictionary<char, string>
        {
            {'а', "a"}, {'А', "a"}, {'б', "b"}, {'Б', "b"},
            {'в', "v"}, {'В', "v"}, {'г', "g"}, {'Г', "g"},
            {'д', "d"}, {'Д', "d"}, {'е', "e"}, {'Е', "e"},
            {'ё', "yo"}, {'Ё', "yo"}, {'ж', "zh"}, {'Ж', "zh"},
            {'з', "z"}, {'З', "z"}, {'и', "i"}, {'И', "i"},
            {'й', "y"}, {'Й', "y"}, {'к', "k"}, {'К', "k"},
            {'л', "l"}, {'Л', "l"}, {'м', "m"}, {'М', "m"},
            {'н', "n"}, {'Н', "n"}, {'ң', "ng"}, {'Ң', "ng"},
            {'о', "o"}, {'О', "o"}, {'ө', "o"}, {'Ө', "o"},
            {'п', "p"}, {'П', "p"}, {'р', "r"}, {'Р', "r"},
            {'с', "s"}, {'С', "s"}, {'т', "t"}, {'Т', "t"},
            {'у', "u"}, {'У', "u"}, {'ү', "u"}, {'Ү', "u"},
            {'ф', "f"}, {'Ф', "f"}, {'х', "kh"}, {'Х', "kh"},
            {'ц', "ts"}, {'Ц', "ts"}, {'ч', "ch"}, {'Ч', "ch"},
            {'ш', "sh"}, {'Ш', "sh"}, {'щ', "shch"}, {'Щ', "shch"},
            {'ъ', ""}, {'Ъ', ""}, {'ы', "y"}, {'Ы', "y"},
            {'ь', ""}, {'Ь', ""}, {'э', "e"}, {'Э', "e"},
            {'ю', "yu"}, {'Ю', "yu"}, {'я', "ya"}, {'Я', "ya"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in kyrgyzChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Replaces Uzbek characters with their English equivalents
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Uzbek characters replaced</returns>
    internal static string ReplaceUzbekCharacters(string text)
    {
        var uzbekChars = new Dictionary<char, char>
        {
            {'ā', 'a'}, {'Ā', 'a'},
            {'č', 'c'}, {'Č', 'c'},
            {'ḡ', 'g'}, {'Ḡ', 'g'},
            {'ḫ', 'h'}, {'Ḫ', 'h'},
            {'ī', 'i'}, {'Ī', 'i'},
            {'ñ', 'n'}, {'Ñ', 'n'},
            {'ō', 'o'}, {'Ō', 'o'},
            {'ö', 'o'}, {'Ö', 'o'},
            {'š', 's'}, {'Š', 's'},
            {'ū', 'u'}, {'Ū', 'u'},
            {'ü', 'u'}, {'Ü', 'u'},
            {'ž', 'z'}, {'Ž', 'z'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in uzbekChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Replaces Turkmen characters with their English equivalents
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Turkmen characters replaced</returns>
    internal static string ReplaceTurkmenCharacters(string text)
    {
        var turkmenChars = new Dictionary<char, char>
        {
            {'ä', 'a'}, {'Ä', 'a'},
            {'ç', 'c'}, {'Ç', 'c'},
            {'ž', 'z'}, {'Ž', 'z'},
            {'ň', 'n'}, {'Ň', 'n'},
            {'ö', 'o'}, {'Ö', 'o'},
            {'ş', 's'}, {'Ş', 's'},
            {'ü', 'u'}, {'Ü', 'u'},
            {'ý', 'y'}, {'Ý', 'y'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in turkmenChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Replaces Tajik characters with their English equivalents
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Tajik characters replaced</returns>
    internal static string ReplaceTajikCharacters(string text)
    {
        var tajikChars = new Dictionary<char, string>
        {
            {'а', "a"}, {'А', "a"}, {'б', "b"}, {'Б', "b"},
            {'в', "v"}, {'В', "v"}, {'г', "g"}, {'Г', "g"},
            {'ғ', "gh"}, {'Ғ', "gh"}, {'д', "d"}, {'Д', "d"},
            {'е', "e"}, {'Е', "e"}, {'ё', "yo"}, {'Ё', "yo"},
            {'ж', "zh"}, {'Ж', "zh"}, {'з', "z"}, {'З', "z"},
            {'и', "i"}, {'И', "i"}, {'ӣ', "i"}, {'Ӣ', "i"},
            {'й', "y"}, {'Й', "y"}, {'к', "k"}, {'К', "k"},
            {'қ', "q"}, {'Қ', "q"}, {'л', "l"}, {'Л', "l"},
            {'м', "m"}, {'М', "m"}, {'н', "n"}, {'Н', "n"},
            {'о', "o"}, {'О', "o"}, {'п', "p"}, {'П', "p"},
            {'р', "r"}, {'Р', "r"}, {'с', "s"}, {'С', "s"},
            {'т', "t"}, {'Т', "t"}, {'у', "u"}, {'У', "u"},
            {'ӯ', "u"}, {'Ӯ', "u"}, {'ф', "f"}, {'Ф', "f"},
            {'х', "kh"}, {'Х', "kh"}, {'ҳ', "h"}, {'Ҳ', "h"},
            {'ч', "ch"}, {'Ч', "ch"}, {'ҷ', "j"}, {'Ҷ', "j"},
            {'ш', "sh"}, {'Ш', "sh"}, {'ъ', ""}, {'Ъ', ""},
            {'э', "e"}, {'Э', "e"}, {'ю', "yu"}, {'Ю', "yu"},
            {'я', "ya"}, {'Я', "ya"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in tajikChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }
}
