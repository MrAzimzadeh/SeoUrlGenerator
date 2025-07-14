using System.Text;

namespace SeoUrlGenerator.LanguageReplacers;

/// <summary>
/// Character replacement methods for Slavic languages
/// </summary>
internal static class SlavicLanguageReplacer
{
    /// <summary>
    /// Replaces Russian characters (Cyrillic to Latin)
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Russian characters replaced</returns>
    internal static string ReplaceRussianCharacters(string text)
    {
        var russianChars = new Dictionary<char, string>
        {
            {'а', "a"}, {'А', "a"}, {'б', "b"}, {'Б', "b"}, {'в', "v"}, {'В', "v"},
            {'г', "g"}, {'Г', "g"}, {'д', "d"}, {'Д', "d"}, {'е', "e"}, {'Е', "e"},
            {'ё', "e"}, {'Ё', "e"}, {'ж', "zh"}, {'Ж', "zh"}, {'з', "z"}, {'З', "z"},
            {'и', "i"}, {'И', "i"}, {'й', "y"}, {'Й', "y"}, {'к', "k"}, {'К', "k"},
            {'л', "l"}, {'Л', "l"}, {'м', "m"}, {'М', "m"}, {'н', "n"}, {'Н', "n"},
            {'о', "o"}, {'О', "o"}, {'п', "p"}, {'П', "p"}, {'р', "r"}, {'Р', "r"},
            {'с', "s"}, {'С', "s"}, {'т', "t"}, {'Т', "t"}, {'у', "u"}, {'У', "u"},
            {'ф', "f"}, {'Ф', "f"}, {'х', "h"}, {'Х', "h"}, {'ц', "ts"}, {'Ц', "ts"},
            {'ч', "ch"}, {'Ч', "ch"}, {'ш', "sh"}, {'Ш', "sh"}, {'щ', "sch"}, {'Щ', "sch"},
            {'ъ', ""}, {'Ъ', ""}, {'ы', "y"}, {'Ы', "y"}, {'ь', ""}, {'Ь', ""},
            {'э', "e"}, {'Э', "e"}, {'ю', "yu"}, {'Ю', "yu"}, {'я', "ya"}, {'Я', "ya"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in russianChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Replaces Ukrainian characters (Cyrillic to Latin)
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Ukrainian characters replaced</returns>
    internal static string ReplaceUkrainianCharacters(string text)
    {
        var ukrainianChars = new Dictionary<char, string>
        {
            {'а', "a"}, {'А', "a"}, {'б', "b"}, {'Б', "b"}, {'в', "v"}, {'В', "v"},
            {'г', "h"}, {'Г', "h"}, {'ґ', "g"}, {'Ґ', "g"}, {'д', "d"}, {'Д', "d"},
            {'е', "e"}, {'Е', "e"}, {'є', "ie"}, {'Є', "ie"}, {'ж', "zh"}, {'Ж', "zh"},
            {'з', "z"}, {'З', "z"}, {'и', "y"}, {'И', "y"}, {'і', "i"}, {'І', "i"},
            {'ї', "i"}, {'Ї', "i"}, {'й', "i"}, {'Й', "i"}, {'к', "k"}, {'К', "k"},
            {'л', "l"}, {'Л', "l"}, {'м', "m"}, {'М', "m"}, {'н', "n"}, {'Н', "n"},
            {'о', "o"}, {'О', "o"}, {'п', "p"}, {'П', "p"}, {'р', "r"}, {'Р', "r"},
            {'с', "s"}, {'С', "s"}, {'т', "t"}, {'Т', "t"}, {'у', "u"}, {'У', "u"},
            {'ф', "f"}, {'Ф', "f"}, {'х', "kh"}, {'Х', "kh"}, {'ц', "ts"}, {'Ц', "ts"},
            {'ч', "ch"}, {'Ч', "ch"}, {'ш', "sh"}, {'Ш', "sh"}, {'щ', "sch"}, {'Щ', "sch"},
            {'ь', ""}, {'Ь', ""}, {'ю', "iu"}, {'Ю', "iu"}, {'я', "ia"}, {'Я', "ia"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in ukrainianChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Replaces Belarusian characters (Cyrillic to Latin)
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Belarusian characters replaced</returns>
    internal static string ReplaceBelarusianCharacters(string text)
    {
        var belarusianChars = new Dictionary<char, string>
        {
            {'а', "a"}, {'А', "a"}, {'б', "b"}, {'Б', "b"}, {'в', "v"}, {'В', "v"},
            {'г', "h"}, {'Г', "h"}, {'д', "d"}, {'Д', "d"}, {'е', "e"}, {'Е', "e"},
            {'ё', "yo"}, {'Ё', "yo"}, {'ж', "zh"}, {'Ж', "zh"}, {'з', "z"}, {'З', "z"},
            {'і', "i"}, {'І', "i"}, {'й', "y"}, {'Й', "y"}, {'к', "k"}, {'К', "k"},
            {'л', "l"}, {'Л', "l"}, {'м', "m"}, {'М', "m"}, {'н', "n"}, {'Н', "n"},
            {'о', "o"}, {'О', "o"}, {'п', "p"}, {'П', "p"}, {'р', "r"}, {'Р', "r"},
            {'с', "s"}, {'С', "s"}, {'т', "t"}, {'Т', "t"}, {'у', "u"}, {'У', "u"},
            {'ў', "w"}, {'Ў', "w"}, {'ф', "f"}, {'Ф', "f"}, {'х', "kh"}, {'Х', "kh"},
            {'ц', "ts"}, {'Ц', "ts"}, {'ч', "ch"}, {'Ч', "ch"}, {'ш', "sh"}, {'Ш', "sh"},
            {'ы', "y"}, {'Ы', "y"}, {'ь', ""}, {'Ь', ""}, {'э', "e"}, {'Э', "e"},
            {'ю', "yu"}, {'Ю', "yu"}, {'я', "ya"}, {'Я', "ya"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in belarusianChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Replaces Bulgarian characters (Cyrillic to Latin)
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Bulgarian characters replaced</returns>
    internal static string ReplaceBulgarianCharacters(string text)
    {
        var bulgarianChars = new Dictionary<char, string>
        {
            {'а', "a"}, {'А', "a"}, {'б', "b"}, {'Б', "b"}, {'в', "v"}, {'В', "v"},
            {'г', "g"}, {'Г', "g"}, {'д', "d"}, {'Д', "d"}, {'е', "e"}, {'Е', "e"},
            {'ж', "zh"}, {'Ж', "zh"}, {'з', "z"}, {'З', "z"}, {'и', "i"}, {'И', "i"},
            {'й', "y"}, {'Й', "y"}, {'к', "k"}, {'К', "k"}, {'л', "l"}, {'Л', "l"},
            {'м', "m"}, {'М', "m"}, {'н', "n"}, {'Н', "n"}, {'о', "o"}, {'О', "o"},
            {'п', "p"}, {'П', "p"}, {'р', "r"}, {'Р', "r"}, {'с', "s"}, {'С', "s"},
            {'т', "t"}, {'Т', "t"}, {'у', "u"}, {'У', "u"}, {'ф', "f"}, {'Ф', "f"},
            {'х', "h"}, {'Х', "h"}, {'ц', "ts"}, {'Ц', "ts"}, {'ч', "ch"}, {'Ч', "ch"},
            {'ш', "sh"}, {'Ш', "sh"}, {'щ', "sht"}, {'Щ', "sht"}, {'ъ', "a"}, {'Ъ', "a"},
            {'ь', ""}, {'Ь', ""}, {'ю', "yu"}, {'Ю', "yu"}, {'я', "ya"}, {'Я', "ya"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in bulgarianChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Replaces Serbian characters (Cyrillic and Latin to Latin)
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Serbian characters replaced</returns>
    internal static string ReplaceSerbianCharacters(string text)
    {
        var serbianChars = new Dictionary<char, string>
        {
            // Cyrillic Serbian characters
            {'а', "a"}, {'А', "a"}, {'б', "b"}, {'Б', "b"}, {'в', "v"}, {'В', "v"},
            {'г', "g"}, {'Г', "g"}, {'д', "d"}, {'Д', "d"}, {'ђ', "dj"}, {'Ђ', "dj"},
            {'е', "e"}, {'Е', "e"}, {'ж', "zh"}, {'Ж', "zh"}, {'з', "z"}, {'З', "z"},
            {'и', "i"}, {'И', "i"}, {'ј', "j"}, {'Ј', "j"}, {'к', "k"}, {'К', "k"},
            {'л', "l"}, {'Л', "l"}, {'љ', "lj"}, {'Љ', "lj"}, {'м', "m"}, {'М', "m"},
            {'н', "n"}, {'Н', "n"}, {'њ', "nj"}, {'Њ', "nj"}, {'о', "o"}, {'О', "o"},
            {'п', "p"}, {'П', "p"}, {'р', "r"}, {'Р', "r"}, {'с', "s"}, {'С', "s"},
            {'т', "t"}, {'Т', "t"}, {'ћ', "c"}, {'Ћ', "c"}, {'у', "u"}, {'У', "u"},
            {'ф', "f"}, {'Ф', "f"}, {'х', "h"}, {'Х', "h"}, {'ц', "c"}, {'Ц', "c"},
            {'ч', "ch"}, {'Ч', "ch"}, {'џ', "dz"}, {'Џ', "dz"}, {'ш', "sh"}, {'Ш', "sh"},
            // Latin Serbian characters
            {'č', "c"}, {'Č', "c"}, {'ć', "c"}, {'Ć', "c"}, {'đ', "dj"}, {'Đ', "dj"},
            {'š', "s"}, {'Š', "s"}, {'ž', "z"}, {'Ž', "z"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in serbianChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Replaces Croatian characters
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Croatian characters replaced</returns>
    internal static string ReplaceCroatianCharacters(string text)
    {
        var croatianChars = new Dictionary<char, char>
        {
            {'č', 'c'}, {'Č', 'c'},
            {'ć', 'c'}, {'Ć', 'c'},
            {'đ', 'd'}, {'Đ', 'd'},
            {'š', 's'}, {'Š', 's'},
            {'ž', 'z'}, {'Ž', 'z'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in croatianChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Replaces Slovenian characters
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Slovenian characters replaced</returns>
    internal static string ReplaceSlovenianCharacters(string text)
    {
        var slovenianChars = new Dictionary<char, char>
        {
            {'č', 'c'}, {'Č', 'c'},
            {'š', 's'}, {'Š', 's'},
            {'ž', 'z'}, {'Ž', 'z'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in slovenianChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Replaces Polish characters
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Polish characters replaced</returns>
    internal static string ReplacePolishCharacters(string text)
    {
        var polishChars = new Dictionary<char, char>
        {
            {'ą', 'a'}, {'Ą', 'a'},
            {'ć', 'c'}, {'Ć', 'c'},
            {'ę', 'e'}, {'Ę', 'e'},
            {'ł', 'l'}, {'Ł', 'l'},
            {'ń', 'n'}, {'Ń', 'n'},
            {'ó', 'o'}, {'Ó', 'o'},
            {'ś', 's'}, {'Ś', 's'},
            {'ź', 'z'}, {'Ź', 'z'},
            {'ż', 'z'}, {'Ż', 'z'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in polishChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Replaces Czech characters
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Czech characters replaced</returns>
    internal static string ReplaceCzechCharacters(string text)
    {
        var czechChars = new Dictionary<char, char>
        {
            {'á', 'a'}, {'Á', 'a'},
            {'č', 'c'}, {'Č', 'c'},
            {'ď', 'd'}, {'Ď', 'd'},
            {'é', 'e'}, {'É', 'e'},
            {'ě', 'e'}, {'Ě', 'e'},
            {'í', 'i'}, {'Í', 'i'},
            {'ň', 'n'}, {'Ň', 'n'},
            {'ó', 'o'}, {'Ó', 'o'},
            {'ř', 'r'}, {'Ř', 'r'},
            {'š', 's'}, {'Š', 's'},
            {'ť', 't'}, {'Ť', 't'},
            {'ú', 'u'}, {'Ú', 'u'},
            {'ů', 'u'}, {'Ů', 'u'},
            {'ý', 'y'}, {'Ý', 'y'},
            {'ž', 'z'}, {'Ž', 'z'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in czechChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Replaces Slovak characters
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Slovak characters replaced</returns>
    internal static string ReplaceSlovakCharacters(string text)
    {
        var slovakChars = new Dictionary<char, char>
        {
            {'á', 'a'}, {'Á', 'a'},
            {'ä', 'a'}, {'Ä', 'a'},
            {'č', 'c'}, {'Č', 'c'},
            {'ď', 'd'}, {'Ď', 'd'},
            {'é', 'e'}, {'É', 'e'},
            {'í', 'i'}, {'Í', 'i'},
            {'ĺ', 'l'}, {'Ĺ', 'l'},
            {'ľ', 'l'}, {'Ľ', 'l'},
            {'ň', 'n'}, {'Ň', 'n'},
            {'ó', 'o'}, {'Ó', 'o'},
            {'ô', 'o'}, {'Ô', 'o'},
            {'ŕ', 'r'}, {'Ŕ', 'r'},
            {'š', 's'}, {'Š', 's'},
            {'ť', 't'}, {'Ť', 't'},
            {'ú', 'u'}, {'Ú', 'u'},
            {'ý', 'y'}, {'Ý', 'y'},
            {'ž', 'z'}, {'Ž', 'z'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in slovakChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }
}
