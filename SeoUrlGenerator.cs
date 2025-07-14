using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using SeoUrlGenerator.LanguageReplacers;

namespace SeoUrlGenerator;

/// <summary>
/// Supported language codes for character replacement
/// </summary>
public enum LanguageCode
{
    /// <summary>
    /// Turkish
    /// </summary>
    TR,
    /// <summary>
    /// Azerbaijani
    /// </summary>
    AZ,
    /// <summary>
    /// German
    /// </summary>
    DE,
    /// <summary>
    /// French
    /// </summary>
    FR,
    /// <summary>
    /// Spanish
    /// </summary>
    ES,
    /// <summary>
    /// Portuguese
    /// </summary>
    PT,
    /// <summary>
    /// Italian
    /// </summary>
    IT,
    /// <summary>
    /// Swedish
    /// </summary>
    SV,
    /// <summary>
    /// Norwegian
    /// </summary>
    NO,
    /// <summary>
    /// Danish
    /// </summary>
    DA,
    /// <summary>
    /// Finnish
    /// </summary>
    FI,
    /// <summary>
    /// Polish
    /// </summary>
    PL,
    /// <summary>
    /// Czech
    /// </summary>
    CS,
    /// <summary>
    /// Slovak
    /// </summary>
    SK,
    /// <summary>
    /// Hungarian
    /// </summary>
    HU,
    /// <summary>
    /// Romanian
    /// </summary>
    RO,
    /// <summary>
    /// Bulgarian
    /// </summary>
    BG,
    /// <summary>
    /// Croatian
    /// </summary>
    HR,
    /// <summary>
    /// Serbian
    /// </summary>
    SR,
    /// <summary>
    /// Slovenian
    /// </summary>
    SL,
    /// <summary>
    /// Lithuanian
    /// </summary>
    LT,
    /// <summary>
    /// Latvian
    /// </summary>
    LV,
    /// <summary>
    /// Estonian
    /// </summary>
    ET,
    /// <summary>
    /// Russian
    /// </summary>
    RU,
    /// <summary>
    /// Ukrainian
    /// </summary>
    UK,
    /// <summary>
    /// Belarusian
    /// </summary>
    BY,
    /// <summary>
    /// Greek
    /// </summary>
    EL,
    /// <summary>
    /// Arabic
    /// </summary>
    AR,
    /// <summary>
    /// Hebrew
    /// </summary>
    HE,
    /// <summary>
    /// Persian
    /// </summary>
    FA,
    /// <summary>
    /// Urdu
    /// </summary>
    UR,
    /// <summary>
    /// Chinese Simplified
    /// </summary>
    ZH_CN,
    /// <summary>
    /// Chinese Traditional
    /// </summary>
    ZH_TW,
    /// <summary>
    /// Japanese
    /// </summary>
    JA,
    /// <summary>
    /// Korean
    /// </summary>
    KO,
    /// <summary>
    /// Vietnamese
    /// </summary>
    VI,
    /// <summary>
    /// Thai
    /// </summary>
    TH,
    /// <summary>
    /// Hindi
    /// </summary>
    HI,
    /// <summary>
    /// Bengali
    /// </summary>
    BN,
    /// <summary>
    /// Tamil
    /// </summary>
    TA,
    /// <summary>
    /// Telugu
    /// </summary>
    TE,
    /// <summary>
    /// Marathi
    /// </summary>
    MR,
    /// <summary>
    /// Gujarati
    /// </summary>
    GU,
    /// <summary>
    /// Kannada
    /// </summary>
    KN,
    /// <summary>
    /// Malayalam
    /// </summary>
    ML,
    /// <summary>
    /// Punjabi
    /// </summary>
    PA,
    /// <summary>
    /// Oriya
    /// </summary>
    OR,
    /// <summary>
    /// Assamese
    /// </summary>
    AS,
    /// <summary>
    /// Nepali
    /// </summary>
    NE,
    /// <summary>
    /// Sinhala
    /// </summary>
    SI,
    /// <summary>
    /// Burmese
    /// </summary>
    MY,
    /// <summary>
    /// Khmer
    /// </summary>
    KM,
    /// <summary>
    /// Lao
    /// </summary>
    LO,
    /// <summary>
    /// Georgian
    /// </summary>
    KA,

    /// <summary>
    /// Mongolian
    /// </summary>
    MN,
    /// <summary>
    /// Kazakh
    /// </summary>
    KK,
    /// <summary>
    /// Kyrgyz
    /// </summary>
    KY,
    /// <summary>
    /// Uzbek
    /// </summary>
    UZ,
    /// <summary>
    /// Tajik
    /// </summary>
    TG,
    /// <summary>
    /// Turkmen
    /// </summary>
    TK,
    /// <summary>
    /// Auto-detect language based on characters
    /// </summary>
    AUTO
}

/// <summary>
/// SEO-friendly URL generator class with multi-language support
/// </summary>
public static class SeoUrlGenerator
{
    /// <summary>
    /// Converts the given text to SEO-friendly URL
    /// </summary>
    /// <param name="text">Text to be converted</param>
    /// <param name="languageCode">Language code for character replacement (default: AUTO)</param>
    /// <param name="maxLength">Maximum character length (default: 100)</param>
    /// <returns>SEO-friendly URL string</returns>
    public static string GenerateUrl(string text, LanguageCode languageCode = LanguageCode.AUTO, int maxLength = 100)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;

        // Convert to lowercase
        text = text.ToLowerInvariant();

        // Replace language-specific characters with their English equivalents
        text = ReplaceLanguageSpecificCharacters(text, languageCode);

        // Decode HTML entities
        text = System.Net.WebUtility.HtmlDecode(text);

        // Replace special characters and spaces with hyphens
        text = Regex.Replace(text, @"[^a-z0-9\s-]", "");
        text = Regex.Replace(text, @"\s+", "-");
        text = Regex.Replace(text, @"-+", "-");

        // Remove leading and trailing hyphens
        text = text.Trim('-');

        // Limit to maximum length
        if (text.Length > maxLength)
        {
            text = text.Substring(0, maxLength);
            // Cut to the last hyphen to avoid breaking words
            int lastDash = text.LastIndexOf('-');
            if (lastDash > 0)
                text = text.Substring(0, lastDash);
        }

        return text;
    }

    /// <summary>
    /// Replaces language-specific characters with their English equivalents
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <param name="languageCode">Language code for character replacement</param>
    /// <returns>Text with replaced characters</returns>
    private static string ReplaceLanguageSpecificCharacters(string text, LanguageCode languageCode)
    {
        if (languageCode == LanguageCode.AUTO)
        {
            languageCode = DetectLanguage(text);
        }

        return languageCode switch
        {
            LanguageCode.TR => TurkicLanguageReplacer.ReplaceTurkishCharacters(text),
            LanguageCode.AZ => TurkicLanguageReplacer.ReplaceAzerbaijaniCharacters(text),
            LanguageCode.KK => TurkicLanguageReplacer.ReplaceKazakhCharacters(text),
            LanguageCode.KY => TurkicLanguageReplacer.ReplaceKyrgyzCharacters(text),
            LanguageCode.UZ => TurkicLanguageReplacer.ReplaceUzbekCharacters(text),
            LanguageCode.TK => TurkicLanguageReplacer.ReplaceTurkmenCharacters(text),
            LanguageCode.TG => TurkicLanguageReplacer.ReplaceTajikCharacters(text),
            LanguageCode.RU => SlavicLanguageReplacer.ReplaceRussianCharacters(text),
            LanguageCode.UK => SlavicLanguageReplacer.ReplaceUkrainianCharacters(text),
            LanguageCode.BY => SlavicLanguageReplacer.ReplaceBelarusianCharacters(text),
            LanguageCode.BG => SlavicLanguageReplacer.ReplaceBulgarianCharacters(text),
            LanguageCode.HR => SlavicLanguageReplacer.ReplaceCroatianCharacters(text),
            LanguageCode.SR => SlavicLanguageReplacer.ReplaceSerbianCharacters(text),
            LanguageCode.SL => SlavicLanguageReplacer.ReplaceSlovenianCharacters(text),
            LanguageCode.PL => SlavicLanguageReplacer.ReplacePolishCharacters(text),
            LanguageCode.CS => SlavicLanguageReplacer.ReplaceCzechCharacters(text),
            LanguageCode.SK => SlavicLanguageReplacer.ReplaceSlovakCharacters(text),
            LanguageCode.DE => ReplaceGermanCharacters(text),
            LanguageCode.FR => ReplaceFrenchCharacters(text),
            LanguageCode.ES => ReplaceSpanishCharacters(text),
            LanguageCode.PT => ReplacePortugueseCharacters(text),
            LanguageCode.IT => ReplaceItalianCharacters(text),
            LanguageCode.SV => ReplaceSwedishCharacters(text),
            LanguageCode.NO => ReplaceNorwegianCharacters(text),
            LanguageCode.DA => ReplaceDanishCharacters(text),
            LanguageCode.FI => ReplaceFinnishCharacters(text),
            LanguageCode.HU => ReplaceHungarianCharacters(text),
            LanguageCode.RO => ReplaceRomanianCharacters(text),
            LanguageCode.LT => ReplaceLithuanianCharacters(text),
            LanguageCode.LV => ReplaceLatvianCharacters(text),
            LanguageCode.ET => ReplaceEstonianCharacters(text),
            LanguageCode.EL => ReplaceGreekCharacters(text),
            LanguageCode.AR => ReplaceArabicCharacters(text),
            LanguageCode.HE => ReplaceHebrewCharacters(text),
            LanguageCode.FA => ReplacePersianCharacters(text),
            LanguageCode.UR => ReplaceUrduCharacters(text),
            LanguageCode.ZH_CN or LanguageCode.ZH_TW => ReplaceChineseCharacters(text),
            LanguageCode.JA => ReplaceJapaneseCharacters(text),
            LanguageCode.KO => ReplaceKoreanCharacters(text),
            LanguageCode.VI => ReplaceVietnameseCharacters(text),
            LanguageCode.TH => ReplaceThaiCharacters(text),
            LanguageCode.HI => ReplaceHindiCharacters(text),
            LanguageCode.BN => ReplaceBengaliCharacters(text),
            LanguageCode.TA => ReplaceTamilCharacters(text),
            LanguageCode.TE => ReplaceTeluguCharacters(text),
            LanguageCode.MR => ReplaceMarathiCharacters(text),
            LanguageCode.GU => ReplaceGujaratiCharacters(text),
            LanguageCode.KN => ReplaceKannadaCharacters(text),
            LanguageCode.ML => ReplaceMalayalamCharacters(text),
            LanguageCode.PA => ReplacePunjabiCharacters(text),
            LanguageCode.OR => ReplaceOriyaCharacters(text),
            LanguageCode.AS => ReplaceAssameseCharacters(text),
            LanguageCode.NE => ReplaceNepaliCharacters(text),
            LanguageCode.SI => ReplaceSinhalaCharacters(text),
            LanguageCode.MY => ReplaceBurmeseCharacters(text),
            LanguageCode.KM => ReplaceKhmerCharacters(text),
            LanguageCode.LO => ReplaceLaoCharacters(text),
            LanguageCode.KA => ReplaceGeorgianCharacters(text),
            LanguageCode.MN => ReplaceMongolianCharacters(text),
            _ => text
        };
    }

    /// <summary>
    /// Auto-detects the language based on character patterns
    /// </summary>
    /// <param name="text">Text to analyze</param>
    /// <returns>Detected language code</returns>
    private static LanguageCode DetectLanguage(string text)
    {
        // Turkish characters
        if (text.Any(c => "çğıöşüÇĞIÖŞÜ".Contains(c)))
            return LanguageCode.TR;

        // Azerbaijani characters (similar to Turkish but has additional characters)
        if (text.Any(c => "əəÄäÖöÜüÇçĞğışŞş".Contains(c)))
            return LanguageCode.AZ;

        // German characters
        if (text.Any(c => "äöüßÄÖÜ".Contains(c)))
            return LanguageCode.DE;

        // French characters
        if (text.Any(c => "àâäéèêëïîôöùûüÿæœçÀÂÄÉÈÊËÏÎÔÖÙÛÜŸÆŒÇ".Contains(c)))
            return LanguageCode.FR;

        // Spanish characters
        if (text.Any(c => "áéíñóúüÁÉÍÑÓÚÜ".Contains(c)))
            return LanguageCode.ES;

        // Russian/Cyrillic characters
        if (text.Any(c => c >= 'а' && c <= 'я' || c >= 'А' && c <= 'Я'))
            return LanguageCode.RU;

        // Greek characters
        if (text.Any(c => c >= 'α' && c <= 'ω' || c >= 'Α' && c <= 'Ω'))
            return LanguageCode.EL;

        // Arabic characters
        if (text.Any(c => c >= 'ا' && c <= 'ي'))
            return LanguageCode.AR;

        // Chinese characters
        if (text.Any(c => c >= 0x4E00 && c <= 0x9FFF))
            return LanguageCode.ZH_CN;

        // Georgian characters
        if (text.Any(c => c >= 'ა' && c <= 'ჰ'))
            return LanguageCode.KA;


        // Default to Turkish for undetected
        return LanguageCode.TR;
    }

    /// <summary>
    /// Replaces Turkish characters with their English equivalents
    /// </summary>
    /// <param name="text">Text to be processed</param>
    /// <returns>Text with Turkish characters replaced</returns>
    private static string ReplaceTurkishCharacters(string text)
    {
        return TurkicLanguageReplacer.ReplaceTurkishCharacters(text);
    }

    /// <summary>
    /// Converts the given text to slug format (short URL)
    /// </summary>
    /// <param name="text">Text to be converted</param>
    /// <param name="maxWords">Maximum number of words (default: 5)</param>
    /// <returns>Slug format string</returns>
    public static string GenerateSlug(string text, int maxWords = 5)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;

        var url = GenerateUrl(text);
        var words = url.Split('-', StringSplitOptions.RemoveEmptyEntries);
        
        if (words.Length <= maxWords)
            return url;

        return string.Join("-", words.Take(maxWords));
    }

    /// <summary>
    /// Checks if the URL is valid SEO format
    /// </summary>
    /// <param name="url">URL to check</param>
    /// <returns>True if valid, false otherwise</returns>
    public static bool IsValidSeoUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return false;

        // Should only contain lowercase letters, numbers and hyphens
        return Regex.IsMatch(url, @"^[a-z0-9-]+$") && 
               !url.StartsWith('-') && 
               !url.EndsWith('-') && 
               !url.Contains("--");
    }

    // German characters
    private static string ReplaceGermanCharacters(string text)
    {
        var germanChars = new Dictionary<char, char>
        {
            {'ä', 'a'}, {'Ä', 'a'},
            {'ö', 'o'}, {'Ö', 'o'},
            {'ü', 'u'}, {'Ü', 'u'},
            {'ß', 's'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in germanChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // French characters
    private static string ReplaceFrenchCharacters(string text)
    {
        var frenchChars = new Dictionary<char, char>
        {
            {'à', 'a'}, {'â', 'a'}, {'ä', 'a'}, {'À', 'a'}, {'Â', 'a'}, {'Ä', 'a'},
            {'é', 'e'}, {'è', 'e'}, {'ê', 'e'}, {'ë', 'e'}, {'É', 'e'}, {'È', 'e'}, {'Ê', 'e'}, {'Ë', 'e'},
            {'ï', 'i'}, {'î', 'i'}, {'Ï', 'i'}, {'Î', 'i'},
            {'ô', 'o'}, {'ö', 'o'}, {'Ô', 'o'}, {'Ö', 'o'},
            {'ù', 'u'}, {'û', 'u'}, {'ü', 'u'}, {'Ù', 'u'}, {'Û', 'u'}, {'Ü', 'u'},
            {'ÿ', 'y'}, {'Ÿ', 'y'},
            {'æ', 'a'}, {'œ', 'o'}, {'Æ', 'a'}, {'Œ', 'o'},
            {'ç', 'c'}, {'Ç', 'c'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in frenchChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Spanish characters
    private static string ReplaceSpanishCharacters(string text)
    {
        var spanishChars = new Dictionary<char, char>
        {
            {'á', 'a'}, {'Á', 'a'},
            {'é', 'e'}, {'É', 'e'},
            {'í', 'i'}, {'Í', 'i'},
            {'ñ', 'n'}, {'Ñ', 'n'},
            {'ó', 'o'}, {'Ó', 'o'},
            {'ú', 'u'}, {'Ú', 'u'},
            {'ü', 'u'}, {'Ü', 'u'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in spanishChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Portuguese characters
    private static string ReplacePortugueseCharacters(string text)
    {
        var portugueseChars = new Dictionary<char, char>
        {
            {'á', 'a'}, {'à', 'a'}, {'â', 'a'}, {'ã', 'a'}, {'ä', 'a'}, {'Á', 'a'}, {'À', 'a'}, {'Â', 'a'}, {'Ã', 'a'}, {'Ä', 'a'},
            {'é', 'e'}, {'è', 'e'}, {'ê', 'e'}, {'É', 'e'}, {'È', 'e'}, {'Ê', 'e'},
            {'í', 'i'}, {'ì', 'i'}, {'î', 'i'}, {'Í', 'i'}, {'Ì', 'i'}, {'Î', 'i'},
            {'ó', 'o'}, {'ò', 'o'}, {'ô', 'o'}, {'õ', 'o'}, {'ö', 'o'}, {'Ó', 'o'}, {'Ò', 'o'}, {'Ô', 'o'}, {'Õ', 'o'}, {'Ö', 'o'},
            {'ú', 'u'}, {'ù', 'u'}, {'û', 'u'}, {'ü', 'u'}, {'Ú', 'u'}, {'Ù', 'u'}, {'Û', 'u'}, {'Ü', 'u'},
            {'ç', 'c'}, {'Ç', 'c'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in portugueseChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Italian characters
    private static string ReplaceItalianCharacters(string text)
    {
        var italianChars = new Dictionary<char, char>
        {
            {'à', 'a'}, {'À', 'a'},
            {'è', 'e'}, {'é', 'e'}, {'È', 'e'}, {'É', 'e'},
            {'ì', 'i'}, {'í', 'i'}, {'Ì', 'i'}, {'Í', 'i'},
            {'ò', 'o'}, {'ó', 'o'}, {'Ò', 'o'}, {'Ó', 'o'},
            {'ù', 'u'}, {'ú', 'u'}, {'Ù', 'u'}, {'Ú', 'u'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in italianChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Swedish characters
    private static string ReplaceSwedishCharacters(string text)
    {
        var swedishChars = new Dictionary<char, char>
        {
            {'å', 'a'}, {'Å', 'a'},
            {'ä', 'a'}, {'Ä', 'a'},
            {'ö', 'o'}, {'Ö', 'o'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in swedishChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Norwegian characters
    private static string ReplaceNorwegianCharacters(string text)
    {
        var norwegianChars = new Dictionary<char, char>
        {
            {'å', 'a'}, {'Å', 'a'},
            {'æ', 'a'}, {'Æ', 'a'},
            {'ø', 'o'}, {'Ø', 'o'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in norwegianChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Danish characters
    private static string ReplaceDanishCharacters(string text)
    {
        var danishChars = new Dictionary<char, char>
        {
            {'å', 'a'}, {'Å', 'a'},
            {'æ', 'a'}, {'Æ', 'a'},
            {'ø', 'o'}, {'Ø', 'o'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in danishChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Finnish characters
    private static string ReplaceFinnishCharacters(string text)
    {
        var finnishChars = new Dictionary<char, char>
        {
            {'ä', 'a'}, {'Ä', 'a'},
            {'ö', 'o'}, {'Ö', 'o'},
            {'å', 'a'}, {'Å', 'a'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in finnishChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Polish characters
    private static string ReplacePolishCharacters(string text)
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

    // Czech characters
    private static string ReplaceCzechCharacters(string text)
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

    // Slovak characters
    private static string ReplaceSlovakCharacters(string text)
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

    // Hungarian characters
    private static string ReplaceHungarianCharacters(string text)
    {
        var hungarianChars = new Dictionary<char, char>
        {
            {'á', 'a'}, {'Á', 'a'},
            {'é', 'e'}, {'É', 'e'},
            {'í', 'i'}, {'Í', 'i'},
            {'ó', 'o'}, {'Ó', 'o'},
            {'ö', 'o'}, {'Ö', 'o'},
            {'ő', 'o'}, {'Ő', 'o'},
            {'ú', 'u'}, {'Ú', 'u'},
            {'ü', 'u'}, {'Ü', 'u'},
            {'ű', 'u'}, {'Ű', 'u'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in hungarianChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Romanian characters
    private static string ReplaceRomanianCharacters(string text)
    {
        var romanianChars = new Dictionary<char, char>
        {
            {'ă', 'a'}, {'Ă', 'a'},
            {'â', 'a'}, {'Â', 'a'},
            {'î', 'i'}, {'Î', 'i'},
            {'ș', 's'}, {'Ș', 's'},
            {'ş', 's'}, {'Ş', 's'},
            {'ț', 't'}, {'Ț', 't'},
            {'ţ', 't'}, {'Ţ', 't'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in romanianChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Bulgarian characters (Cyrillic to Latin)
    private static string ReplaceBulgarianCharacters(string text)
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

    // Croatian characters
    private static string ReplaceCroatianCharacters(string text)
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

    // Serbian characters (Cyrillic to Latin)
    private static string ReplaceSerbianCharacters(string text)
    {
        var serbianChars = new Dictionary<char, string>
        {
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

    // Slovenian characters
    private static string ReplaceSlovenianCharacters(string text)
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

    // Lithuanian characters
    private static string ReplaceLithuanianCharacters(string text)
    {
        var lithuanianChars = new Dictionary<char, char>
        {
            {'ą', 'a'}, {'Ą', 'a'},
            {'č', 'c'}, {'Č', 'c'},
            {'ę', 'e'}, {'Ę', 'e'},
            {'ė', 'e'}, {'Ė', 'e'},
            {'į', 'i'}, {'Į', 'i'},
            {'š', 's'}, {'Š', 's'},
            {'ų', 'u'}, {'Ų', 'u'},
            {'ū', 'u'}, {'Ū', 'u'},
            {'ž', 'z'}, {'Ž', 'z'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in lithuanianChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Latvian characters
    private static string ReplaceLatvianCharacters(string text)
    {
        var latvianChars = new Dictionary<char, char>
        {
            {'ā', 'a'}, {'Ā', 'a'},
            {'č', 'c'}, {'Č', 'c'},
            {'ē', 'e'}, {'Ē', 'e'},
            {'ģ', 'g'}, {'Ģ', 'g'},
            {'ī', 'i'}, {'Ī', 'i'},
            {'ķ', 'k'}, {'Ķ', 'k'},
            {'ļ', 'l'}, {'Ļ', 'l'},
            {'ņ', 'n'}, {'Ņ', 'n'},
            {'š', 's'}, {'Š', 's'},
            {'ū', 'u'}, {'Ū', 'u'},
            {'ž', 'z'}, {'Ž', 'z'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in latvianChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Estonian characters
    private static string ReplaceEstonianCharacters(string text)
    {
        var estonianChars = new Dictionary<char, char>
        {
            {'ä', 'a'}, {'Ä', 'a'},
            {'ö', 'o'}, {'Ö', 'o'},
            {'ü', 'u'}, {'Ü', 'u'},
            {'õ', 'o'}, {'Õ', 'o'},
            {'š', 's'}, {'Š', 's'},
            {'ž', 'z'}, {'Ž', 'z'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in estonianChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Russian characters (Cyrillic to Latin)
    private static string ReplaceRussianCharacters(string text)
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

    // Ukrainian characters (Cyrillic to Latin)
    private static string ReplaceUkrainianCharacters(string text)
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

    // Greek characters
    private static string ReplaceGreekCharacters(string text)
    {
        var greekChars = new Dictionary<char, string>
        {
            {'α', "a"}, {'Α', "a"}, {'β', "b"}, {'Β', "b"}, {'γ', "g"}, {'Γ', "g"},
            {'δ', "d"}, {'Δ', "d"}, {'ε', "e"}, {'Ε', "e"}, {'ζ', "z"}, {'Ζ', "z"},
            {'η', "i"}, {'Η', "i"}, {'θ', "th"}, {'Θ', "th"}, {'ι', "i"}, {'Ι', "i"},
            {'κ', "k"}, {'Κ', "k"}, {'λ', "l"}, {'Λ', "l"}, {'μ', "m"}, {'Μ', "m"},
            {'ν', "n"}, {'Ν', "n"}, {'ξ', "ks"}, {'Ξ', "ks"}, {'ο', "o"}, {'Ο', "o"},
            {'π', "p"}, {'Π', "p"}, {'ρ', "r"}, {'Ρ', "r"}, {'σ', "s"}, {'Σ', "s"},
            {'ς', "s"}, {'τ', "t"}, {'Τ', "t"}, {'υ', "y"}, {'Υ', "y"}, {'φ', "f"},
            {'Φ', "f"}, {'χ', "ch"}, {'Χ', "ch"}, {'ψ', "ps"}, {'Ψ', "ps"}, {'ω', "o"}, {'Ω', "o"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in greekChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    // Arabic characters (transliteration)
    private static string ReplaceArabicCharacters(string text)
    {
        var arabicChars = new Dictionary<char, string>
        {
            {'ا', "a"}, {'ب', "b"}, {'ت', "t"}, {'ث', "th"}, {'ج', "j"}, {'ح', "h"},
            {'خ', "kh"}, {'د', "d"}, {'ذ', "dh"}, {'ر', "r"}, {'ز', "z"}, {'س', "s"},
            {'ش', "sh"}, {'ص', "s"}, {'ض', "d"}, {'ط', "t"}, {'ظ', "z"}, {'ع', "a"},
            {'غ', "gh"}, {'ف', "f"}, {'ق', "q"}, {'ك', "k"}, {'ل', "l"}, {'م', "m"},
            {'ن', "n"}, {'ه', "h"}, {'و', "w"}, {'ي', "y"}, {'ة', "h"}, {'ى', "a"},
            {'ء', ""}, {'آ', "a"}, {'أ', "a"}, {'إ', "i"}, {'ئ', "e"}, {'ؤ', "o"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in arabicChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    // Hebrew characters (transliteration)
    private static string ReplaceHebrewCharacters(string text)
    {
        var hebrewChars = new Dictionary<char, string>
        {
            {'א', "a"}, {'ב', "b"}, {'ג', "g"}, {'ד', "d"}, {'ה', "h"}, {'ו', "v"},
            {'ז', "z"}, {'ח', "ch"}, {'ט', "t"}, {'י', "y"}, {'כ', "k"}, {'ל', "l"},
            {'מ', "m"}, {'נ', "n"}, {'ס', "s"}, {'ע', "a"}, {'פ', "p"}, {'צ', "ts"},
            {'ק', "q"}, {'ר', "r"}, {'ש', "sh"}, {'ת', "t"}, {'ך', "k"}, {'ם', "m"},
            {'ן', "n"}, {'ף', "f"}, {'ץ', "ts"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in hebrewChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    // Persian/Farsi characters (transliteration)
    private static string ReplacePersianCharacters(string text)
    {
        var persianChars = new Dictionary<char, string>
        {
            {'ا', "a"}, {'ب', "b"}, {'پ', "p"}, {'ت', "t"}, {'ث', "s"}, {'ج', "j"},
            {'چ', "ch"}, {'ح', "h"}, {'خ', "kh"}, {'د', "d"}, {'ذ', "z"}, {'ر', "r"},
            {'ز', "z"}, {'ژ', "zh"}, {'س', "s"}, {'ش', "sh"}, {'ص', "s"}, {'ض', "z"},
            {'ط', "t"}, {'ظ', "z"}, {'ع', "a"}, {'غ', "gh"}, {'ف', "f"}, {'ق', "gh"},
            {'ک', "k"}, {'گ', "g"}, {'ل', "l"}, {'م', "m"}, {'ن', "n"}, {'و', "v"},
            {'ه', "h"}, {'ی', "y"}, {'آ', "a"}, {'أ', "a"}, {'إ', "e"}, {'ء', ""}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in persianChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    // Chinese characters (using Pinyin - simplified approach)
    private static string ReplaceChineseCharacters(string text)
    {
        // For Chinese characters, we'll use a simple approach
        // In a real implementation, you might want to use a library for Pinyin conversion
        var result = new StringBuilder();
        foreach (char c in text)
        {
            if (c >= 0x4E00 && c <= 0x9FFF) // Chinese character range
            {
                // Convert to empty or use a transliteration library
                // For now, we'll skip Chinese characters
                continue;
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }

    // Japanese characters (Hiragana/Katakana to Romaji - simplified)
    private static string ReplaceJapaneseCharacters(string text)
    {
        // Basic Hiragana to Romaji conversion
        var japaneseChars = new Dictionary<char, string>
        {
            {'あ', "a"}, {'い', "i"}, {'う', "u"}, {'え', "e"}, {'お', "o"},
            {'か', "ka"}, {'き', "ki"}, {'く', "ku"}, {'け', "ke"}, {'こ', "ko"},
            {'さ', "sa"}, {'し', "shi"}, {'す', "su"}, {'せ', "se"}, {'そ', "so"},
            {'た', "ta"}, {'ち', "chi"}, {'つ', "tsu"}, {'て', "te"}, {'と', "to"},
            {'な', "na"}, {'に', "ni"}, {'ぬ', "nu"}, {'ね', "ne"}, {'の', "no"},
            {'は', "ha"}, {'ひ', "hi"}, {'ふ', "fu"}, {'へ', "he"}, {'ほ', "ho"},
            {'ま', "ma"}, {'み', "mi"}, {'む', "mu"}, {'め', "me"}, {'も', "mo"},
            {'や', "ya"}, {'ゆ', "yu"}, {'よ', "yo"},
            {'ら', "ra"}, {'り', "ri"}, {'る', "ru"}, {'れ', "re"}, {'ろ', "ro"},
            {'わ', "wa"}, {'を', "wo"}, {'ん', "n"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in japaneseChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }

        // Remove Kanji characters (simplified approach)
        var result = new StringBuilder();
        foreach (char c in sb.ToString())
        {
            if (c >= 0x4E00 && c <= 0x9FFF) // Kanji range
            {
                continue;
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }

    // Korean characters (Hangul to Romanization - simplified)
    private static string ReplaceKoreanCharacters(string text)
    {
        // Basic Korean Hangul to Latin conversion (very simplified)
        var result = new StringBuilder();
        foreach (char c in text)
        {
            if (c >= 0xAC00 && c <= 0xD7AF) // Hangul syllables range
            {
                // For a full implementation, you'd need proper Hangul decomposition
                // For now, we'll skip Korean characters
                continue;
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }

    // Vietnamese characters
    private static string ReplaceVietnameseCharacters(string text)
    {
        var vietnameseChars = new Dictionary<char, char>
        {
            {'à', 'a'}, {'á', 'a'}, {'ả', 'a'}, {'ã', 'a'}, {'ạ', 'a'},
            {'ă', 'a'}, {'ằ', 'a'}, {'ắ', 'a'}, {'ẳ', 'a'}, {'ẵ', 'a'}, {'ặ', 'a'},
            {'â', 'a'}, {'ầ', 'a'}, {'ấ', 'a'}, {'ẩ', 'a'}, {'ẫ', 'a'}, {'ậ', 'a'},
            {'đ', 'd'},
            {'è', 'e'}, {'é', 'e'}, {'ẻ', 'e'}, {'ẽ', 'e'}, {'ẹ', 'e'},
            {'ê', 'e'}, {'ề', 'e'}, {'ế', 'e'}, {'ể', 'e'}, {'ễ', 'e'}, {'ệ', 'e'},
            {'ì', 'i'}, {'í', 'i'}, {'ỉ', 'i'}, {'ĩ', 'i'}, {'ị', 'i'},
            {'ò', 'o'}, {'ó', 'o'}, {'ỏ', 'o'}, {'õ', 'o'}, {'ọ', 'o'},
            {'ô', 'o'}, {'ồ', 'o'}, {'ố', 'o'}, {'ổ', 'o'}, {'ỗ', 'o'}, {'ộ', 'o'},
            {'ơ', 'o'}, {'ờ', 'o'}, {'ớ', 'o'}, {'ở', 'o'}, {'ỡ', 'o'}, {'ợ', 'o'},
            {'ù', 'u'}, {'ú', 'u'}, {'ủ', 'u'}, {'ũ', 'u'}, {'ụ', 'u'},
            {'ư', 'u'}, {'ừ', 'u'}, {'ứ', 'u'}, {'ử', 'u'}, {'ữ', 'u'}, {'ự', 'u'},
            {'ỳ', 'y'}, {'ý', 'y'}, {'ỷ', 'y'}, {'ỹ', 'y'}, {'ỵ', 'y'},
            // Uppercase
            {'À', 'a'}, {'Á', 'a'}, {'Ả', 'a'}, {'Ã', 'a'}, {'Ạ', 'a'},
            {'Ă', 'a'}, {'Ằ', 'a'}, {'Ắ', 'a'}, {'Ẳ', 'a'}, {'Ẵ', 'a'}, {'Ặ', 'a'},
            {'Â', 'a'}, {'Ầ', 'a'}, {'Ấ', 'a'}, {'Ẩ', 'a'}, {'Ẫ', 'a'}, {'Ậ', 'a'},
            {'Đ', 'd'},
            {'È', 'e'}, {'É', 'e'}, {'Ẻ', 'e'}, {'Ẽ', 'e'}, {'Ẹ', 'e'},
            {'Ê', 'e'}, {'Ề', 'e'}, {'Ế', 'e'}, {'Ể', 'e'}, {'Ễ', 'e'}, {'Ệ', 'e'},
            {'Ì', 'i'}, {'Í', 'i'}, {'Ỉ', 'i'}, {'Ĩ', 'i'}, {'Ị', 'i'},
            {'Ò', 'o'}, {'Ó', 'o'}, {'Ỏ', 'o'}, {'Õ', 'o'}, {'Ọ', 'o'},
            {'Ô', 'o'}, {'Ồ', 'o'}, {'Ố', 'o'}, {'Ổ', 'o'}, {'Ỗ', 'o'}, {'Ộ', 'o'},
            {'Ơ', 'o'}, {'Ờ', 'o'}, {'Ớ', 'o'}, {'Ở', 'o'}, {'Ỡ', 'o'}, {'Ợ', 'o'},
            {'Ù', 'u'}, {'Ú', 'u'}, {'Ủ', 'u'}, {'Ũ', 'u'}, {'Ụ', 'u'},
            {'Ư', 'u'}, {'Ừ', 'u'}, {'Ứ', 'u'}, {'Ử', 'u'}, {'Ữ', 'u'}, {'Ự', 'u'},
            {'Ỳ', 'y'}, {'Ý', 'y'}, {'Ỷ', 'y'}, {'Ỹ', 'y'}, {'Ỵ', 'y'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in vietnameseChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Thai characters (simplified transliteration)
    private static string ReplaceThaiCharacters(string text)
    {
        // Basic Thai to Latin conversion (very simplified)
        var result = new StringBuilder();
        foreach (char c in text)
        {
            if (c >= 0x0E00 && c <= 0x0E7F) // Thai character range
            {
                // For a full implementation, you'd need proper Thai transliteration
                // For now, we'll skip Thai characters
                continue;
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }

    // Hindi characters (Devanagari to Latin - simplified)
    private static string ReplaceHindiCharacters(string text)
    {
        // Basic Devanagari to Latin conversion (very simplified)
        var result = new StringBuilder();
        foreach (char c in text)
        {
            if (c >= 0x0900 && c <= 0x097F) // Devanagari range
            {
                // For a full implementation, you'd need proper Devanagari transliteration
                // For now, we'll skip Hindi characters
                continue;
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }

    // Urdu characters (using Arabic script)
    private static string ReplaceUrduCharacters(string text)
    {
        var urduChars = new Dictionary<char, string>
        {
            // Basic Arabic characters used in Urdu
            {'ا', "a"}, {'ب', "b"}, {'پ', "p"}, {'ت', "t"}, {'ٹ', "t"}, {'ث', "s"},
            {'ج', "j"}, {'چ', "ch"}, {'ح', "h"}, {'خ', "kh"}, {'د', "d"}, {'ڈ', "d"},
            {'ذ', "z"}, {'ر', "r"}, {'ڑ', "r"}, {'ز', "z"}, {'ژ', "zh"}, {'س', "s"},
            {'ش', "sh"}, {'ص', "s"}, {'ض', "z"}, {'ط', "t"}, {'ظ', "z"}, {'ع', "a"},
            {'غ', "gh"}, {'ف', "f"}, {'ق', "q"}, {'ک', "k"}, {'گ', "g"}, {'ل', "l"},
            {'م', "m"}, {'ن', "n"}, {'ں', "n"}, {'و', "w"}, {'ہ', "h"}, {'ھ', "h"},
            {'ء', ""}, {'ی', "y"}, {'ے', "e"}, {'آ', "a"}, {'أ', "a"}, {'إ', "i"},
            {'ئ', "e"}, {'ؤ', "o"}, {'ة', "h"}, {'ى', "a"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in urduChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    // Bengali characters (Devanagari script)
    private static string ReplaceBengaliCharacters(string text)
    {
        var bengaliChars = new Dictionary<char, char>
        {
            // Bengali consonants
            {'ক', 'k'}, {'খ', 'k'}, {'গ', 'g'}, {'ঘ', 'g'}, {'ঙ', 'n'},
            {'চ', 'c'}, {'ছ', 'c'}, {'জ', 'j'}, {'ঝ', 'j'}, {'ঞ', 'n'},
            {'ট', 't'}, {'ঠ', 't'}, {'ড', 'd'}, {'ঢ', 'd'}, {'ণ', 'n'},
            {'ত', 't'}, {'থ', 't'}, {'দ', 'd'}, {'ধ', 'd'}, {'ন', 'n'},
            {'প', 'p'}, {'ফ', 'p'}, {'ব', 'b'}, {'ভ', 'b'}, {'ম', 'm'},
            {'য', 'j'}, {'র', 'r'}, {'ল', 'l'}, {'শ', 's'}, {'ষ', 's'},
            {'স', 's'}, {'হ', 'h'},
            // Bengali vowels
            {'অ', 'a'}, {'আ', 'a'}, {'ই', 'i'}, {'ঈ', 'i'}, {'উ', 'u'},
            {'ঊ', 'u'}, {'ঋ', 'r'}, {'এ', 'e'}, {'ঐ', 'a'}, {'ও', 'o'}, {'ঔ', 'a'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in bengaliChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Tamil characters
    private static string ReplaceTamilCharacters(string text)
    {
        var tamilChars = new Dictionary<char, char>
        {
            // Tamil consonants
            {'க', 'k'}, {'ங', 'n'}, {'ச', 'c'}, {'ஞ', 'n'}, {'ட', 't'},
            {'ண', 'n'}, {'த', 't'}, {'ந', 'n'}, {'ப', 'p'}, {'ம', 'm'},
            {'ய', 'y'}, {'ர', 'r'}, {'ல', 'l'}, {'வ', 'v'}, {'ழ', 'z'},
            {'ள', 'l'}, {'ற', 'r'}, {'ன', 'n'}, {'ஜ', 'j'}, {'ஶ', 's'},
            {'ஷ', 's'}, {'ஸ', 's'}, {'ஹ', 'h'},
            // Tamil vowels
            {'அ', 'a'}, {'ஆ', 'a'}, {'இ', 'i'}, {'ஈ', 'i'}, {'உ', 'u'},
            {'ஊ', 'u'}, {'எ', 'e'}, {'ஏ', 'e'}, {'ஐ', 'a'}, {'ஒ', 'o'},
            {'ஓ', 'o'}, {'ஔ', 'a'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in tamilChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Telugu characters (simplified)
    private static string ReplaceTeluguCharacters(string text)
    {
        var teluguChars = new Dictionary<char, char>
        {
            // Telugu consonants (simplified)
            {'క', 'k'}, {'ఖ', 'k'}, {'గ', 'g'}, {'ఘ', 'g'}, {'ఙ', 'n'},
            {'చ', 'c'}, {'ఛ', 'c'}, {'జ', 'j'}, {'ఝ', 'j'}, {'ఞ', 'n'},
            {'ట', 't'}, {'ఠ', 't'}, {'డ', 'd'}, {'ఢ', 'd'}, {'ణ', 'n'},
            {'త', 't'}, {'థ', 't'}, {'ద', 'd'}, {'ధ', 'd'}, {'న', 'n'},
            {'ప', 'p'}, {'ఫ', 'p'}, {'బ', 'b'}, {'భ', 'b'}, {'మ', 'm'},
            {'య', 'y'}, {'ర', 'r'}, {'ల', 'l'}, {'వ', 'v'}, {'శ', 's'},
            {'ష', 's'}, {'స', 's'}, {'హ', 'h'}, {'ళ', 'l'},
            // Telugu vowels
            {'అ', 'a'}, {'ఆ', 'a'}, {'ఇ', 'i'}, {'ఈ', 'i'}, {'උ', 'u'},
            {'ఊ', 'u'}, {'ఎ', 'e'}, {'ఏ', 'e'}, {'ఐ', 'a'}, {'ఒ', 'o'},
            {'ఓ', 'o'}, {'ఔ', 'a'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in teluguChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Marathi characters (simplified)
    private static string ReplaceMarathiCharacters(string text)
    {
        var marathiChars = new Dictionary<char, char>
        {
            // Marathi consonants (simplified)
            {'क', 'k'}, {'ख', 'k'}, {'ग', 'g'}, {'घ', 'g'}, {'ङ', 'n'},
            {'च', 'c'}, {'छ', 'c'}, {'ज', 'j'}, {'झ', 'j'}, {'ञ', 'n'},
            {'ट', 't'}, {'ठ', 't'}, {'ड', 'd'}, {'ढ', 'd'}, {'ण', 'n'},
            {'त', 't'}, {'थ', 't'}, {'द', 'd'}, {'ध', 'd'}, {'न', 'n'},
            {'प', 'p'}, {'फ', 'p'}, {'ब', 'b'}, {'भ', 'b'}, {'म', 'm'},
            {'य', 'y'}, {'र', 'r'}, {'ल', 'l'}, {'व', 'v'}, {'श', 's'},
            {'ष', 's'}, {'स', 's'}, {'ह', 'h'}, {'ळ', 'l'},
            // Marathi vowels
            {'अ', 'a'}, {'आ', 'a'}, {'इ', 'i'}, {'ई', 'i'}, {'उ', 'u'},
            {'ऊ', 'u'}, {'ऋ', 'r'}, {'ए', 'e'}, {'ऐ', 'a'}, {'ओ', 'o'},
            {'औ', 'a'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in marathiChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Gujarati characters (simplified)
    private static string ReplaceGujaratiCharacters(string text)
    {
        var gujaratiChars = new Dictionary<char, char>
        {
            // Gujarati consonants (simplified)
            {'ક', 'k'}, {'ખ', 'k'}, {'ગ', 'g'}, {'ઘ', 'g'}, {'ઙ', 'n'},
            {'ચ', 'c'}, {'છ', 'c'}, {'જ', 'j'}, {'ઝ', 'j'}, {'ઞ', 'n'},
            {'ટ', 't'}, {'ઠ', 't'}, {'ડ', 'd'}, {'ઢ', 'd'}, {'ણ', 'n'},
            {'ત', 't'}, {'થ', 't'}, {'દ', 'd'}, {'ધ', 'd'}, {'ન', 'n'},
            {'પ', 'p'}, {'ફ', 'p'}, {'બ', 'b'}, {'ભ', 'b'}, {'મ', 'm'},
            {'ય', 'y'}, {'ર', 'r'}, {'લ', 'l'}, {'વ', 'v'}, {'શ', 's'},
            {'ષ', 's'}, {'સ', 's'}, {'હ', 'h'}, {'ળ', 'l'},
            // Gujarati vowels
            {'અ', 'a'}, {'આ', 'a'}, {'ઇ', 'i'}, {'ઈ', 'i'}, {'ઉ', 'u'},
            {'ઊ', 'u'}, {'ઋ', 'r'}, {'એ', 'e'}, {'ઐ', 'a'}, {'ઓ', 'o'}, {'ઔ', 'a'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in gujaratiChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Kannada characters (simplified)
    private static string ReplaceKannadaCharacters(string text)
    {
        var kannadaChars = new Dictionary<char, char>
        {
            // Kannada consonants (simplified)
            {'ಕ', 'k'}, {'ಖ', 'k'}, {'ಗ', 'g'}, {'ಘ', 'g'}, {'ಙ', 'n'},
            {'ಚ', 'c'}, {'ಛ', 'c'}, {'ಜ', 'j'}, {'ಝ', 'j'}, {'ಞ', 'n'},
            {'ಟ', 't'}, {'ಠ', 't'}, {'ಡ', 'd'}, {'ಢ', 'd'}, {'ಣ', 'n'},
            {'ತ', 't'}, {'ಥ', 't'}, {'ದ', 'd'}, {'ಧ', 'd'}, {'ನ', 'n'},
            {'ಪ', 'p'}, {'ಫ', 'p'}, {'ಬ', 'b'}, {'ಭ', 'b'}, {'ಮ', 'm'},
            {'ಯ', 'y'}, {'ರ', 'r'}, {'ಲ', 'l'}, {'ವ', 'v'}, {'ಶ', 's'},
            {'ಷ', 's'}, {'ಸ', 's'}, {'ಹ', 'h'}, {'ಳ', 'l'},
            // Kannada vowels
            {'ಅ', 'a'}, {'ಆ', 'a'}, {'ಇ', 'i'}, {'ಈ', 'i'}, {'ಉ', 'u'},
            {'ಊ', 'u'}, {'ಋ', 'r'}, {'ಎ', 'e'}, {'ಏ', 'e'}, {'ಐ', 'a'},
            {'ಒ', 'o'}, {'ಓ', 'o'}, {'ಔ', 'a'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in kannadaChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Malayalam characters (simplified)
    private static string ReplaceMalayalamCharacters(string text)
    {
        var malayalamChars = new Dictionary<char, char>
        {
            // Malayalam consonants (simplified)
            {'ക', 'k'}, {'ഖ', 'k'}, {'ഗ', 'g'}, {'ഘ', 'g'}, {'ങ', 'n'},
            {'ച', 'c'}, {'ഛ', 'c'}, {'ജ', 'j'}, {'ഝ', 'j'}, {'ഞ', 'n'},
            {'ട', 't'}, {'ഠ', 't'}, {'ഡ', 'd'}, {'ഢ', 'd'}, {'ണ', 'n'},
            {'ത', 't'}, {'ഥ', 't'}, {'ദ', 'd'}, {'ധ', 'd'}, {'ന', 'n'},
            {'പ', 'p'}, {'ഫ', 'p'}, {'ബ', 'b'}, {'ഭ', 'b'}, {'മ', 'm'},
            {'യ', 'y'}, {'ര', 'r'}, {'ല', 'l'}, {'വ', 'v'}, {'ശ', 's'},
            {'ഷ', 's'}, {'സ', 's'}, {'ഹ', 'h'}, {'ള', 'l'}, {'ഴ', 'z'},
            {'റ', 'r'},
            // Malayalam vowels
            {'അ', 'a'}, {'ആ', 'a'}, {'ഇ', 'i'}, {'ഈ', 'i'}, {'ഉ', 'u'},
            {'ഊ', 'u'}, {'ഋ', 'r'}, {'എ', 'e'}, {'ഏ', 'e'}, {'ഐ', 'a'},
            {'ഒ', 'o'}, {'ഓ', 'o'}, {'ഔ', 'a'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in malayalamChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Punjabi characters (simplified)
    private static string ReplacePunjabiCharacters(string text)
    {
        var punjabiChars = new Dictionary<char, char>
        {
            // Punjabi consonants (simplified)
            {'ਕ', 'k'}, {'ਖ', 'k'}, {'ਗ', 'g'}, {'ਘ', 'g'}, {'ਙ', 'n'},
            {'ਚ', 'c'}, {'ਛ', 'c'}, {'ਜ', 'j'}, {'ਝ', 'j'}, {'ਞ', 'n'},
            {'ਟ', 't'}, {'ਠ', 't'}, {'ਡ', 'd'}, {'ਢ', 'd'}, {'ਣ', 'n'},
            {'ਤ', 't'}, {'ਥ', 't'}, {'ਦ', 'd'}, {'ਧ', 'd'}, {'ਨ', 'n'},
            {'ਪ', 'p'}, {'ਫ', 'p'}, {'ਬ', 'b'}, {'ਭ', 'b'}, {'ਮ', 'm'},
            {'ਯ', 'y'}, {'ਰ', 'r'}, {'ਲ', 'l'}, {'ਵ', 'v'},
            {'ਸ', 's'}, {'ਹ', 'h'},
            // Punjabi vowels
            {'ਅ', 'a'}, {'ਆ', 'a'}, {'ਇ', 'i'}, {'ਈ', 'i'}, {'ਉ', 'u'},
            {'ਊ', 'u'}, {'ਏ', 'e'}, {'ਐ', 'a'}, {'ਓ', 'o'}, {'ਔ', 'a'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in punjabiChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Oriya characters (simplified)
    private static string ReplaceOriyaCharacters(string text)
    {
        var oriyaChars = new Dictionary<char, char>
        {
            // Oriya consonants (simplified)
            {'କ', 'k'}, {'ଖ', 'k'}, {'ଗ', 'g'}, {'ଘ', 'g'}, {'ଙ', 'n'},
            {'ଚ', 'c'}, {'ଛ', 'c'}, {'ଜ', 'j'}, {'ଝ', 'j'}, {'ଞ', 'n'},
            {'ଟ', 't'}, {'ଠ', 't'}, {'ଡ', 'd'}, {'ଢ', 'd'}, {'ଣ', 'n'},
            {'ତ', 't'}, {'ଥ', 't'}, {'ଦ', 'd'}, {'ଧ', 'd'}, {'ନ', 'n'},
            {'ପ', 'p'}, {'ଫ', 'p'}, {'ବ', 'b'}, {'ଭ', 'b'}, {'ମ', 'm'},
            {'ଯ', 'y'}, {'ର', 'r'}, {'ଲ', 'l'}, {'ବ', 'v'}, {'ଶ', 's'},
            {'ଷ', 's'}, {'ସ', 's'}, {'ହ', 'h'}, {'ଳ', 'l'},
            // Oriya vowels
            {'ଅ', 'a'}, {'ଆ', 'a'}, {'ଇ', 'i'}, {'ଈ', 'i'}, {'ଉ', 'u'},
            {'ଊ', 'u'}, {'ଋ', 'r'}, {'ଏ', 'e'}, {'ଐ', 'a'}, {'ଓ', 'o'}, {'ଔ', 'a'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in oriyaChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Assamese characters (simplified)
    private static string ReplaceAssameseCharacters(string text)
    {
        var assameseChars = new Dictionary<char, char>
        {
            // Assamese consonants (simplified)
            {'ক', 'k'}, {'খ', 'k'}, {'গ', 'g'}, {'ঘ', 'g'}, {'ঙ', 'n'},
            {'চ', 'c'}, {'ছ', 'c'}, {'জ', 'j'}, {'ঝ', 'j'}, {'ঞ', 'n'},
            {'ট', 't'}, {'ঠ', 't'}, {'ড', 'd'}, {'ঢ', 'd'}, {'ণ', 'n'},
            {'ত', 't'}, {'থ', 't'}, {'দ', 'd'}, {'ধ', 'd'}, {'ন', 'n'},
            {'প', 'p'}, {'ফ', 'p'}, {'ব', 'b'}, {'ভ', 'b'}, {'ম', 'm'},
            {'য', 'j'}, {'ৰ', 'r'}, {'ল', 'l'}, {'ৱ', 'w'}, {'শ', 's'},
            {'ষ', 's'}, {'স', 's'}, {'হ', 'h'},
            // Assamese vowels
            {'অ', 'a'}, {'আ', 'a'}, {'ই', 'i'}, {'ঈ', 'i'}, {'উ', 'u'},
            {'ঊ', 'u'}, {'ঋ', 'r'}, {'এ', 'e'}, {'ঐ', 'a'}, {'ও', 'o'}, {'ঔ', 'a'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in assameseChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Nepali characters (simplified)
    private static string ReplaceNepaliCharacters(string text)
    {
        var nepaliChars = new Dictionary<char, char>
        {
            // Nepali consonants (simplified)
            {'क', 'k'}, {'ख', 'k'}, {'ग', 'g'}, {'घ', 'g'}, {'ङ', 'n'},
            {'च', 'c'}, {'छ', 'c'}, {'ज', 'j'}, {'झ', 'j'}, {'ञ', 'n'},
            {'ट', 't'}, {'ठ', 't'}, {'ड', 'd'}, {'ढ', 'd'}, {'ण', 'n'},
            {'त', 't'}, {'थ', 't'}, {'द', 'd'}, {'ध', 'd'}, {'न', 'n'},
            {'प', 'p'}, {'फ', 'p'}, {'ब', 'b'}, {'भ', 'b'}, {'म', 'm'},
            {'य', 'y'}, {'र', 'r'}, {'ल', 'l'}, {'व', 'v'}, {'श', 's'},
            {'ष', 's'}, {'स', 's'}, {'ह', 'h'},
            // Nepali vowels
            {'अ', 'a'}, {'आ', 'a'}, {'इ', 'i'}, {'ई', 'i'}, {'उ', 'u'},
            {'ऊ', 'u'}, {'ऋ', 'r'}, {'ए', 'e'}, {'ऐ', 'a'}, {'ओ', 'o'}, {'औ', 'a'}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in nepaliChars)
        {
            sb.Replace(kvp.Key, kvp.Value);
        }
        return sb.ToString();
    }

    // Sinhala characters
    private static string ReplaceSinhalaCharacters(string text)
    {
        var sinhalaChars = new Dictionary<char, string>
        {
            // Sinhala consonants
            {'ක', "k"}, {'ඛ', "kh"}, {'ග', "g"}, {'ඝ', "gh"}, {'ඞ', "ng"},
            {'ච', "ch"}, {'ඡ', "chh"}, {'ජ', "j"}, {'ඣ', "jh"}, {'ඤ', "ny"},
            {'ට', "t"}, {'ඨ', "th"}, {'ඩ', "d"}, {'ඪ', "dh"}, {'ණ', "n"},
            {'ත', "th"}, {'ථ', "th"}, {'ද', "d"}, {'ධ', "dh"}, {'න', "n"},
            {'ප', "p"}, {'ඵ', "ph"}, {'බ', "b"}, {'භ', "bh"}, {'ම', "m"},
            {'ය', "y"}, {'ර', "r"}, {'ල', "l"}, {'ව', "v"}, {'ශ', "sh"},
            {'ෂ', "sh"}, {'ස', "s"}, {'හ', "h"}, {'ළ', "l"}, {'ෆ', "f"},
            // Sinhala vowels
            {'අ', "a"}, {'ආ', "a"}, {'ඇ', "ae"}, {'ඈ', "aae"}, {'ඉ', "i"},
            {'ඊ', "i"}, {'උ', "u"}, {'ඌ', "u"}, {'ඍ', "ri"}, {'ඎ', "rii"},
            {'ඏ', "lu"}, {'ඐ', "luu"}, {'එ', "e"}, {'ඒ', "ee"}, {'ඓ', "ai"},
            {'ඔ', "o"}, {'ඕ', "oo"}, {'ඖ', "au"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in sinhalaChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    // Burmese characters
    private static string ReplaceBurmeseCharacters(string text)
    {
        var burmeseChars = new Dictionary<char, string>
        {
            // Burmese consonants
            {'က', "k"}, {'ခ', "kh"}, {'ဂ', "g"}, {'ဃ', "gh"}, {'င', "ng"},
            {'စ', "s"}, {'ဆ', "hs"}, {'ဇ', "z"}, {'ဈ', "jh"}, {'ဉ', "ny"},
            {'ည', "nw"}, {'တ', "t"}, {'ထ', "ht"}, {'ད', "d"}, {'ဓ', "dh"},
            {'န', "n"}, {'ပ', "p"}, {'ဖ', "f"}, {'ဗ', "b"}, {'ဘ', "bh"},
            {'မ', "m"}, {'ယ', "y"}, {'ရ', "r"}, {'လ', "l"}, {'ဝ', "w"},
            {'သ', "th"}, {'ဟ', "h"}, {'ဠ', "l"}, {'အ', "a"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in burmeseChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    // Khmer characters
    private static string ReplaceKhmerCharacters(string text)
    {
        var khmerChars = new Dictionary<char, string>
        {
            // Khmer consonants
            {'ក', "k"}, {'ខ', "kh"}, {'គ', "g"}, {'ឃ', "gh"}, {'ង', "ng"},
            {'ច', "ch"}, {'ឆ', "chh"}, {'ជ', "j"}, {'ឈ', "jh"}, {'ញ', "ny"},
            {'ដ', "d"}, {'ឋ', "th"}, {'ឌ', "d"}, {'ឍ', "dh"}, {'ណ', "n"},
            {'ត', "t"}, {'ថ', "th"}, {'ទ', "t"}, {'ធ', "th"}, {'ន', "n"},
            {'ប', "b"}, {'ផ', "ph"}, {'ព', "p"}, {'ភ', "ph"}, {'ម', "m"},
            {'យ', "y"}, {'រ', "r"}, {'ល', "l"}, {'វ', "v"}, {'ស', "s"},
            {'ហ', "h"}, {'ឡ', "l"}, {'អ', "a"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in khmerChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    // Lao characters
    private static string ReplaceLaoCharacters(string text)
    {
        var laoChars = new Dictionary<char, string>
        {
            // Lao consonants
            {'ກ', "k"}, {'ຂ', "kh"}, {'ຄ', "k"}, {'ງ', "ng"}, {'ຈ', "ch"},
            {'ສ', "s"}, {'ຊ', "s"}, {'ຍ', "ny"}, {'ດ', "d"}, {'ຕ', "t"},
            {'ຖ', "th"}, {'ທ', "th"}, {'ນ', "n"}, {'ບ', "b"}, {'ປ', "p"},
            {'ຜ', "ph"}, {'ຝ', "f"}, {'ພ', "ph"}, {'ຟ', "f"}, {'ມ', "m"},
            {'ຢ', "y"}, {'ຣ', "r"}, {'ລ', "l"}, {'ວ', "w"}, {'ຫ', "h"},
            {'ອ', "o"}, {'ຮ', "h"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in laoChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }

    // Georgian characters
    private static string ReplaceGeorgianCharacters(string text)
    {
        var georgianChars = new Dictionary<char, string>
        {
            {'ა', "a"}, {'ბ', "b"}, {'გ', "g"}, {'დ', "d"}, {'ე', "e"},
            {'ვ', "v"}, {'ზ', "z"}, {'თ', "t"}, {'ი', "i"}, {'კ', "k"},
            {'ლ', "l"}, {'მ', "m"}, {'ნ', "n"}, {'ო', "o"}, {'პ', "p"},
            {'ჟ', "zh"}, {'რ', "r"}, {'ს', "s"}, {'ტ', "t"}, {'უ', "u"},
            {'ფ', "f"}, {'ქ', "q"}, {'ღ', "gh"}, {'ყ', "q"}, {'შ', "sh"},
            {'ჩ', "ch"}, {'ც', "ts"}, {'ძ', "dz"}, {'წ', "ts"}, {'ჭ', "ch"},
            {'ხ', "kh"}, {'ჯ', "j"}, {'ჰ', "h"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in georgianChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }


    // Mongolian characters (Cyrillic script)
    private static string ReplaceMongolianCharacters(string text)
    {
        var mongolianChars = new Dictionary<char, string>
        {
            {'а', "a"}, {'А', "a"}, {'б', "b"}, {'Б', "b"}, {'в', "v"}, {'В', "v"},
            {'г', "g"}, {'Г', "g"}, {'д', "d"}, {'Д', "d"}, {'е', "e"}, {'Е', "e"},
            {'ё', "yo"}, {'Ё', "yo"}, {'ж', "j"}, {'Ж', "j"}, {'з', "z"}, {'З', "z"},
            {'и', "i"}, {'И', "i"}, {'й', "i"}, {'Й', "i"}, {'к', "k"}, {'К', "k"},
            {'л', "l"}, {'Л', "l"}, {'м', "m"}, {'М', "m"}, {'н', "n"}, {'Н', "n"},
            {'о', "o"}, {'О', "o"}, {'ө', "o"}, {'Ө', "o"}, {'п', "p"}, {'П', "p"},
            {'р', "r"}, {'Р', "r"}, {'с', "s"}, {'С', "s"}, {'т', "t"}, {'Т', "t"},
            {'у', "u"}, {'У', "u"}, {'ү', "u"}, {'Ү', "u"}, {'ф', "f"}, {'Ф', "f"},
            {'х', "kh"}, {'Х', "kh"}, {'ц', "ts"}, {'Ц', "ts"}, {'ч', "ch"}, {'Ч', "ch"},
            {'ш', "sh"}, {'Ш', "sh"}, {'щ', "sh"}, {'Щ', "sh"}, {'ъ', ""}, {'Ъ', ""},
            {'ы', "y"}, {'Ы', "y"}, {'ь', ""}, {'Ь', ""}, {'э', "e"}, {'Э', "e"},
            {'ю', "yu"}, {'Ю', "yu"}, {'я', "ya"}, {'Я', "ya"}
        };

        var sb = new StringBuilder(text);
        foreach (var kvp in mongolianChars)
        {
            sb.Replace(kvp.Key.ToString(), kvp.Value);
        }
        return sb.ToString();
    }
}
