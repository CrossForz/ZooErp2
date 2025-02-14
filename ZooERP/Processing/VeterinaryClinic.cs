using ZooERP.Interfaces;
using ZooERP.Models.Animals;

namespace ZooERP.Processing;

public class VeterinaryClinic : IVeterinaryClinic
{
  public bool CheckHealth(Animal animal)
  {
    IOController.PrintSeparators();
    IOController.WriteLine(
      $"Ветеринар осматривает животное: {animal.GetType().Name} (Инв. №{animal.Number})",
      ConsoleColor.Cyan);
    IOController.Write("Животное здорово? (да/нет) = ", ConsoleColor.Magenta);
    string? input = IOController.ReadLine()?.Trim().ToLower();
    bool result = new[] { "да", "yes", "y" }.Contains(input);
    animal.IsHealthy = result;

    // Красивый вывод результата проверки
    if (result)
    {
      IOController.WriteLine("Ветеринар: Животное принято в зоопарк.", ConsoleColor.Green);
    }
    else
    {
      IOController.WriteLine("Ветеринар: Отказ в приёме животного.", ConsoleColor.Red);
    }

    return result;
  }
}