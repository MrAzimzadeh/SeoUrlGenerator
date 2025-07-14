# SeoUrlGenerator

A powerful .NET library for generating SEO-friendly URLs with multi-language support. This library can handle over 30 languages and automatically convert special characters to their Latin equivalents.

## Features

- 🌍 **Multi-language support** - Supports 30+ languages including Turkish, German, French, Spanish, Russian, Arabic, Chinese, and many more
- 🔄 **Auto-detection** - Automatically detects the language based on character patterns
- 📏 **Configurable length** - Set maximum URL length and word count
- ✅ **URL validation** - Built-in validation for SEO-friendly URLs
- 🚀 **High performance** - Optimized for speed and efficiency
- 📦 **Zero dependencies** - No external dependencies required

## Supported Languages

- **European**: Turkish (TR), German (DE), French (FR), Spanish (ES), Portuguese (PT), Italian (IT), Swedish (SV), Norwegian (NO), Danish (DA), Finnish (FI), Polish (PL), Czech (CS), Slovak (SK), Hungarian (HU), Romanian (RO), Bulgarian (BG), Croatian (HR), Serbian (SR), Slovenian (SL), Lithuanian (LT), Latvian (LV), Estonian (ET)
- **Cyrillic**: Russian (RU), Ukrainian (UK), Bulgarian (BG), Serbian (SR)
- **Middle Eastern**: Arabic (AR), Hebrew (HE), Persian/Farsi (FA)
- **Asian**: Chinese Simplified (ZH_CN), Chinese Traditional (ZH_TW), Japanese (JA), Korean (KO), Vietnamese (VI), Thai (TH), Hindi (HI)

## Installation

```bash
dotnet add package SeoUrlGenerator
```

## Usage

### Basic Usage

```csharp
using SeoUrlGenerator;

// Basic URL generation with auto-detection
string url = SeoUrlGenerator.GenerateUrl("Merhaba Dünya! Çok güzel bir gün.");
// Result: "merhaba-dunya-cok-guzel-bir-gun"

// Specify language explicitly
string germanUrl = SeoUrlGenerator.GenerateUrl("Schöne Grüße aus München!", LanguageCode.DE);
// Result: "schone-gruse-aus-munchen"
```

### Advanced Usage

```csharp
// Generate URL with custom max length
string longUrl = SeoUrlGenerator.GenerateUrl("Very long title here...", LanguageCode.AUTO, 50);

// Generate slug (limited words)
string slug = SeoUrlGenerator.GenerateSlug("This is a very long title", 3);
// Result: "this-is-very"

// Validate SEO URL
bool isValid = SeoUrlGenerator.IsValidSeoUrl("valid-seo-url-123");
// Result: true
```

### Language-Specific Examples

```csharp
// Turkish
string turkish = SeoUrlGenerator.GenerateUrl("İstanbul'da güzel bir gün", LanguageCode.TR);
// Result: "istanbulda-guzel-bir-gun"

// German
string german = SeoUrlGenerator.GenerateUrl("Müller und Schäfer", LanguageCode.DE);
// Result: "muller-und-schafer"

// Russian
string russian = SeoUrlGenerator.GenerateUrl("Привет мир", LanguageCode.RU);
// Result: "privet-mir"

// Arabic
string arabic = SeoUrlGenerator.GenerateUrl("مرحبا بالعالم", LanguageCode.AR);
// Result: "mrhba-balalm"
```

## API Reference

### SeoUrlGenerator.GenerateUrl()

```csharp
public static string GenerateUrl(string text, LanguageCode languageCode = LanguageCode.AUTO, int maxLength = 100)
```

**Parameters:**
- `text` - The input text to convert
- `languageCode` - Language code for character replacement (default: AUTO)
- `maxLength` - Maximum character length (default: 100)

**Returns:** SEO-friendly URL string

### SeoUrlGenerator.GenerateSlug()

```csharp
public static string GenerateSlug(string text, int maxWords = 5)
```

**Parameters:**
- `text` - The input text to convert
- `maxWords` - Maximum number of words (default: 5)

**Returns:** Slug format string

### SeoUrlGenerator.IsValidSeoUrl()

```csharp
public static bool IsValidSeoUrl(string url)
```

**Parameters:**
- `url` - URL to validate

**Returns:** True if valid SEO URL, false otherwise

## Language Codes

Use the `LanguageCode` enum to specify the language:

```csharp
LanguageCode.AUTO    // Auto-detect (default)
LanguageCode.TR      // Turkish
LanguageCode.DE      // German
LanguageCode.FR      // French
LanguageCode.ES      // Spanish
LanguageCode.RU      // Russian
LanguageCode.AR      // Arabic
// ... and many more
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License.

## Support

If you encounter any issues or have questions, please create an issue on GitHub.
# SeoUrlGenerator
