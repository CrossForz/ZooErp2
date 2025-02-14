namespace ZooERP.Processing;

/// <summary>
/// Класс для работы с консолью с цветным выводом.
/// </summary>
public static class IOController
{
  /// <summary>
  /// Аналог метода Console.Write с цветным выводом.
  /// </summary>
  /// <param name="writeObject">Объект для вывода.</param>
  /// <param name="color">Цвет текста.</param>
  public static void Write(object writeObject, ConsoleColor color)
  {
    Console.ForegroundColor = color; // Устанавливаем цвет.
    Console.Write(writeObject);
    Console.ResetColor(); // Сбрасываем цвет.
  }

  /// <summary>
  /// Аналог метода Console.WriteLine с цветным выводом.
  /// </summary>
  /// <param name="writeObject">Объект для вывода.</param>
  /// <param name="color">Цвет текста.</param>
  public static void WriteLine(object writeObject, ConsoleColor color)
  {
    Console.ForegroundColor = color;
    Console.WriteLine(writeObject);
    Console.ResetColor();
  }

  /// <summary>
  /// Аналог метода Console.ReadLine с цветным выводом.
  /// </summary>
  /// <returns>Введённая строка.</returns>
  public static string? ReadLine()
  {
    Console.ForegroundColor = ConsoleColor.Magenta;
    string? result = Console.ReadLine();
    Console.ResetColor();
    return result;
  }

  /// <summary>
  /// Метод выводит разделитель для визуального разделения этапов работы.
  /// </summary>
  public static void PrintSeparators()
  {
    WriteLine(new string('_', 45), ConsoleColor.Blue);
  }
}