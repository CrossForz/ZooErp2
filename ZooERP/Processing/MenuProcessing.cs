namespace ZooERP.Processing;

// Класс для работы с меню – вывод главного меню и корректный ввод выбора пользователем.
public static class MenuProcessing
{
  /// <summary>
  /// Вывод главного меню ERP-системы зоопарка.
  /// </summary>
  public static void PrintMainMenu()
  {
    IOController.PrintSeparators();
    IOController.WriteLine("=== ERP-система зоопарка ===", ConsoleColor.Cyan);
    IOController.WriteLine("1. Добавить животное", ConsoleColor.DarkCyan);
    IOController.WriteLine("2. Добавить инвентарный предмет", ConsoleColor.DarkCyan);
    IOController.WriteLine("3. Показать количество животных", ConsoleColor.DarkCyan);
    IOController.WriteLine("4. Показать общее потребление еды", ConsoleColor.DarkCyan);
    IOController.WriteLine("5. Показать животных для контактного зоопарка", ConsoleColor.DarkCyan);
    IOController.WriteLine("6. Показать список инвентаризации", ConsoleColor.DarkCyan);
    IOController.WriteLine("7. Выход", ConsoleColor.DarkCyan);
  }

  /// <summary>
  /// Метод для корректного ввода номера меню.
  /// </summary>
  /// <param name="maxChoice">Максимально допустимый номер пункта меню.</param>
  /// <returns>Выбранный номер пункта меню.</returns>
  public static int InputCorrectMenuChoice(int maxChoice)
  {
    int num;
    while (true)
    {
      IOController.Write("Введите номер действия = ", ConsoleColor.Magenta);
      string? input = IOController.ReadLine();
      if (int.TryParse(input, out num) && num >= 1 && num <= maxChoice)
      {
        break;
      }
      IOController.WriteLine("Некорректный ввод, попробуйте ещё раз.", ConsoleColor.Red);
    }
    return num;
  }
}