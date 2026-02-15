using System;

namespace CaesarCipherRu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Шифр Цезаря для русского алфавита (с поддержкой Ё/ё)");
            Console.WriteLine("Программа шифрует и расшифровывает текст, сдвигая буквы на заданное число позиций.");
            Console.WriteLine("-----------------------------");

            while (true)  // Бесконечный цикл до явного выхода
            {
                // Ввод ключа
                Console.Write("Введите ключ (целое число): ");
                string keyInput = Console.ReadLine()?.Trim();

                // Проверяем корректность ключа
                if (string.IsNullOrEmpty(keyInput) || !int.TryParse(keyInput, out int key))
                {
                    Console.WriteLine("Ошибка: ключ должен быть целым числом. Попробуйте снова.\n");
                    continue;  // Возвращаемся к началу цикла
                }

                // Ввод текста
                Console.Write("Введите текст для шифровки: ");
                string plainText = Console.ReadLine();

                // Проверяем, что текст введён
                if (string.IsNullOrEmpty(plainText))
                {
                    Console.WriteLine("Ошибка: текст не введён. Попробуйте снова.\n");
                    continue;  // Возвращаемся к началу цикла
                }

                Console.WriteLine($"\nИсходный текст: {plainText}");

                // Шифрование
                string encrypted = encryptText(plainText, keyInput);
                Console.WriteLine($"Зашифрованный: {encrypted}");

                // Расшифровка
                string decrypted = decryptText(encrypted, keyInput);
                Console.WriteLine($"Расшифрованный: {decrypted}");

                // Проверка корректности
                if (plainText == decrypted)
                    Console.WriteLine("✓ Текст расшифрован верно.");
                else
                    Console.WriteLine("✗ Ошибка: текст после расшифровки не совпадает с исходным!");

                // Предложение продолжить
                Console.WriteLine("Продолжить? (y/n): ");
                string answer = Console.ReadLine()?.Trim().ToUpper();

                if (answer == "N")
                {
                    Console.WriteLine("Работа программы завершена.");
                    break;  // Выход из цикла
                }
                else if (answer != "Y")
                {
                    Console.WriteLine("Неверный ввод. Будем считать, что вы хотите продолжить.\n");
                }
                // Если ответ 'Y' — цикл продолжается автоматически
            }
        }

        /// Шифрует текст по методу Цезаря
        static string encryptText(string text, string key)
        {
            if (!int.TryParse(key, out int shift))
                return "Ошибка: ключ должен быть целым числом.";

            // Нормализуем сдвиг к диапазону [0; 32] (33 буквы в алфавите)
            shift = shift % 33;
            if (shift < 0) shift += 33;

            var result = new System.Text.StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                // Заглавные буквы А–Я
                if (c >= 'А' && c <= 'Я')
                {
                    int idx = (c - 'А' + shift) % 33;
                    result.Append(GetCharUpper(idx));
                }
                // Буква Ё
                else if (c == 'Ё')
                {
                    int idx = (32 + shift) % 33;
                    result.Append(GetCharUpper(idx));
                }
                // Строчные буквы а–я
                else if (c >= 'а' && c <= 'я')
                {
                    int idx = (c - 'а' + shift) % 33;
                    result.Append(GetCharLower(idx));
                }
                // Буква ё
                else if (c == 'ё')
                {
                    int idx = (32 + shift) % 33;
                    result.Append(GetCharLower(idx));
                }
                // Прочие символы (сохраняем как есть)
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        /// Расшифровывает текст, зашифрованный методом Цезаря
        static string decryptText(string cipherText, string key)
        {
            if (!int.TryParse(key, out int shift))
                return "Ошибка: ключ должен быть целым числом.";

            // Обратный сдвиг для расшифровки
            shift = (-shift) % 33;
            if (shift < 0) shift += 33;

            var result = new System.Text.StringBuilder();

            for (int i = 0; i < cipherText.Length; i++)
            {
                char c = cipherText[i];

                if (c >= 'А' && c <= 'Я')
                {
                    int idx = (c - 'А' + shift) % 33;
                    result.Append(GetCharUpper(idx));
                }
                else if (c == 'Ё')
                {
                    int idx = (32 + shift) % 33;
                    result.Append(GetCharUpper(idx));
                }
                else if (c >= 'а' && c <= 'я')
                {
                    int idx = (c - 'а' + shift) % 33;
                    result.Append(GetCharLower(idx));
                }
                else if (c == 'ё')
                {
                    int idx = (32 + shift) % 33;
                    result.Append(GetCharLower(idx));
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        /// Преобразует индекс (0–32) в заглавную букву (Ё → 32)
        static char GetCharUpper(int idx)
        {
            return idx == 32 ? 'Ё' : (char)('А' + idx);
        }

        /// Преобразует индекс (0–32) в строчную букву (ё → 32)
        static char GetCharLower(int idx)
        {
            return idx == 32 ? 'ё' : (char)('а' + idx);
        }
    }
}
