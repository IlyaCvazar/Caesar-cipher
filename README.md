# Caesar Cipher (Russian Alphabet)

A console application implementing the Caesar cipher for the Russian alphabet, including support for the letter «Ё»/«ё».

## Overview

This program demonstrates a classic substitution cipher where each letter in the plaintext is shifted a certain number of places down or up the alphabet. The implementation supports the full Russian alphabet (33 letters) and provides an interactive user experience.

## Features

- **Encryption**: Convert plain text into ciphertext using a user‑defined shift key.  
- **Decryption**: Recover the original text from ciphertext using the same key.  
- **Input validation**: Robust handling of invalid inputs (empty strings, non‑integer keys).  
- **Case preservation**: Maintains uppercase/lowercase distinctions.  
- **Special character handling**: Non‑alphabetic characters (digits, punctuation) are preserved.  
- **Interactive loop**: Users can perform multiple operations without restarting.  
- **Error checking**: Verifies that decryption correctly restores the original text.

## How It Works

### Key Normalization

The shift key is normalized to ensure it falls within the valid range `[0; 32]` (33 letters in the Russian alphabet):
```csharp
shift = shift % 33;
if (shift < 0) shift += 33;
```

### Encryption/Decryption Logic

1. **Character classification**: Each character is checked to determine if it’s:
   - An uppercase Cyrillic letter (`А–Я`, `Ё`).  
   - A lowercase Cyrillic letter (`а–я`, `ё`).  
   - A non‑alphabetic character (preserved as‑is).  

2. **Index calculation**: For alphabetic characters:
   - Convert the letter to its zero‑based index in the alphabet.  
   - Apply the shift (positive for encryption, negative for decryption).  
   - Use modulo 33 to wrap around the alphabet.  

3. **Reconversion**: Map the resulting index back to a Cyrillic letter.

### Helper Methods

- `GetCharUpper(int idx)`: Converts an index (0–32) to an uppercase Cyrillic letter (`Ё` → 32).  
- `GetCharLower(int idx)`: Converts an index (0–32) to a lowercase Cyrillic letter (`ё` → 32).

## Usage

1. **Compile** the project using a C# compiler (e.g., `dotnet build`).  
2. **Run** the executable.  
3. Follow the on‑screen prompts:
   - Enter an integer key (e.g., `5`).  
   - Input the text to encrypt.  
   - View the encrypted and decrypted results.  
   - Choose to continue or exit.

### Example Session

```
Шифр Цезаря для русского алфавита (с поддержкой Ё/ё)
Программа шифрует и расшифровывает текст, сдвигая буквы на заданное число позиций.
-----------------------------
Введите ключ (целое число): 3
Введите текст для шифровки: Привет, мир!

Исходный текст: Привет, мир!
Зашифрованный: Туклх, пло!
Расшифрованный: Привет, мир!
✓ Текст расшифрован верно.
Продолжить? (y/n): n
Работа программы завершена.
```

## Technical Details

- **Language**: C#  
- **Framework**: .NET  
- **Key Data Structures**: `StringBuilder` (for efficient string manipulation).  
- **Input/Output**: Console‑based (`Console.WriteLine`, `Console.ReadLine`).

## Limitations

- Supports only the Russian alphabet (no Latin characters).  
- Does not handle diacritical combinations (e.g., «й» as «и»+«кратка»).  
- No file I/O (text is entered/displayed via console).

## Testing

The program has been tested with:
- Valid keys and texts.  
- Negative keys.  
- Empty inputs.  
- Non‑integer keys.  
- Texts containing special characters and digits.

## Future Enhancements

- Add support for other alphabets (e.g., Latin).  
- Implement file‑based input/output.  
- Include a GUI version.  
- Add brute‑force decryption options.

## License

This project is open‑source and available under the [MIT License](LICENSE).

## Contributing

Contributions are welcome! Please open an issue or submit a pull request on GitHub.
