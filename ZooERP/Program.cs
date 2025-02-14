using Microsoft.Extensions.DependencyInjection;
using ZooERP.Processing;

namespace ZooERP;

class Program
{
  static void Main(string[] args)
  {
    // Настройка DI-контейнера
    var serviceCollection = new ServiceCollection();
    ConfigureServices(serviceCollection);
    var serviceProvider = serviceCollection.BuildServiceProvider();

    // Получаем экземпляр зоопарка через DI
    var zoo = serviceProvider.GetService<Zoo>()!;

    bool exit = false;
    while (!exit)
    {
      // Вывод главного меню
      MenuProcessing.PrintMainMenu();
      int choice = MenuProcessing.InputCorrectMenuChoice(7);

      // Обработка выбора пользователя
      switch (choice)
      {
        case 1:
          ZooMenu.AddAnimal(zoo);
          break;
        case 2:
          ZooMenu.AddInventoryItem(zoo);
          break;
        case 3:
          IOController.WriteLine($"\nОбщее количество животных: {zoo.TotalAnimals}", ConsoleColor.Yellow);
          break;
        case 4:
          IOController.WriteLine($"\nОбщее потребление еды: {zoo.TotalFoodConsumption()} кг/день", ConsoleColor.Yellow);
          break;
        case 5:
          ZooMenu.ShowInteractiveAnimals(zoo);
          break;
        case 6:
          ZooMenu.ShowInventoryItems(zoo);
          break;
        case 7:
          exit = true;
          break;
      }

      if (!exit)
      {
        IOController.PrintSeparators();
        IOController.WriteLine("Нажмите любую клавишу для продолжения...", ConsoleColor.DarkCyan);
        Console.ReadKey();
        Console.Clear();
      }
    }
  }

  /// <summary>
  /// Метод для регистрации зависимостей в DI-контейнере.
  /// </summary>
  /// <param name="services">Коллекция сервисов.</param>
  private static void ConfigureServices(IServiceCollection services)
  {
    // Регистрируем реализацию ветеринарной клиники и зоопарк
    services.AddSingleton<Interfaces.IVeterinaryClinic, VeterinaryClinic>();
    services.AddSingleton<Zoo>();
  }
}