using ZooERP.Interfaces;
using ZooERP.Models.Animals;
using ZooERP.Models.Animals.Herbos;
using ZooERP.Models.Animals.Predators;
using ZooERP.Models.InventoryItems;

namespace ZooERP.Processing;

// Класс для работы с операциями зоопарка: добавление животных и инвентарных предметов,
// а также вывод информации. Номера присваиваются автоматически.
public static class ZooMenu
{
  /// <summary>
  /// Добавление нового животного в зоопарк.
  /// Пользователю запрашиваются только необходимые данные – количество потребляемой еды и (при необходимости) уровень доброты.
  /// Номер животного назначается автоматически.
  /// </summary>
  /// <param name="zoo">Экземпляр зоопарка.</param>
  public static void AddAnimal(Zoo zoo)
  {
    IOController.PrintSeparators();
    IOController.WriteLine("Выберите тип животного:", ConsoleColor.Cyan);
    IOController.WriteLine("1. Обезьяна", ConsoleColor.DarkCyan);
    IOController.WriteLine("2. Кролик", ConsoleColor.DarkCyan);
    IOController.WriteLine("3. Тигр", ConsoleColor.DarkCyan);
    IOController.WriteLine("4. Волк", ConsoleColor.DarkCyan);
    IOController.Write("Ваш выбор = ", ConsoleColor.Magenta);
    string? typeChoice = IOController.ReadLine();

    IOController.Write("Введите количество потребляемой еды (кг/день) = ", ConsoleColor.Magenta);
    if (!int.TryParse(IOController.ReadLine(), out int food))
    {
      IOController.WriteLine("Некорректное значение еды.", ConsoleColor.Red);
      return;
    }

    // Номер инвентаризации больше не запрашивается, он задается автоматически

    Animal? animal = null;
    switch (typeChoice)
    {
      case "1":
        IOController.Write("Введите уровень доброты (0-10) = ", ConsoleColor.Magenta);
        if (!int.TryParse(IOController.ReadLine(), out int monkeyKindness))
        {
          IOController.WriteLine("Некорректное значение доброты.", ConsoleColor.Red);
          return;
        }

        animal = new Monkey(food, monkeyKindness);
        break;
      case "2":
        IOController.Write("Введите уровень доброты (0-10) = ", ConsoleColor.Magenta);
        if (!int.TryParse(IOController.ReadLine(), out int rabbitKindness))
        {
          IOController.WriteLine("Некорректное значение доброты.", ConsoleColor.Red);
          return;
        }

        animal = new Rabbit(food, rabbitKindness);
        break;
      case "3":
        animal = new Tiger(food);
        break;
      case "4":
        animal = new Wolf(food);
        break;
      default:
        IOController.WriteLine("Неверный выбор типа животного.", ConsoleColor.Red);
        return;
    }

    if (zoo.AdmitAnimal(animal))
    {
      IOController.WriteLine("Животное успешно добавлено в зоопарк!", ConsoleColor.Green);
    }
    else
    {
      IOController.WriteLine("Животное не прошло проверку ветеринарной клиники.", ConsoleColor.Red);
    }
  }

  /// <summary>
  /// Добавление инвентарного предмета.
  /// Пользователю запрашивается только наименование предмета,
  /// а номер присваивается автоматически.
  /// </summary>
  /// <param name="zoo">Экземпляр зоопарка.</param>
  public static void AddInventoryItem(Zoo zoo)
  {
    IOController.PrintSeparators();
    IOController.WriteLine("Выберите тип инвентарного предмета:", ConsoleColor.Cyan);
    IOController.WriteLine("1. Стол", ConsoleColor.DarkCyan);
    IOController.WriteLine("2. Компьютер", ConsoleColor.DarkCyan);
    IOController.Write("Ваш выбор = ", ConsoleColor.Magenta);
    string? choice = IOController.ReadLine();

    IOController.Write("Введите наименование предмета = ", ConsoleColor.Magenta);
    string? name = IOController.ReadLine();

    // Номер для предмета больше не запрашивается, он задается автоматически

    IInventory? item = choice switch
    {
      "1" => new Table(name!),
      "2" => new Computer(name!),
      _ => null
    };

    if (item is null)
    {
      IOController.WriteLine("Неверный выбор типа предмета.", ConsoleColor.Red);
      return;
    }

    zoo.AddInventoryItem(item);
    IOController.WriteLine("Предмет успешно добавлен в инвентаризацию.", ConsoleColor.Green);
  }

  /// <summary>
  /// Вывод списка животных, пригодных для контактного зоопарка.
  /// </summary>
  /// <param name="zoo">Экземпляр зоопарка.</param>
  public static void ShowInteractiveAnimals(Zoo zoo)
  {
    IOController.PrintSeparators();
    IOController.WriteLine("Животные, пригодные для контактного зоопарка:", ConsoleColor.Cyan);
    var interactiveAnimals = zoo.GetInteractiveAnimals().ToList();
    if (interactiveAnimals.Any())
    {
      foreach (var animal in interactiveAnimals)
      {
        IOController.WriteLine(animal.ToString(), ConsoleColor.Yellow);
      }
    }
    else
    {
      IOController.WriteLine("Нет животных, удовлетворяющих критериям.", ConsoleColor.Red);
    }
  }

  /// <summary>
  /// Вывод списка всех инвентарных объектов зоопарка.
  /// </summary>
  /// <param name="zoo">Экземпляр зоопарка.</param>
  public static void ShowInventoryItems(Zoo zoo)
  {
    IOController.PrintSeparators();
    IOController.WriteLine("Объекты, стоящие на балансе зоопарка:", ConsoleColor.Cyan);
    foreach (var item in zoo.GetInventoryItems())
    {
      IOController.WriteLine(item.ToString(), ConsoleColor.Yellow);
    }
  }
}