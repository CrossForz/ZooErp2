using ZooERP.Interfaces;

namespace ZooERP.Models.Animals;

// Абстрактный класс животного, реализует IAlive и IInventory.
public abstract class Animal : IAlive, IInventory
{
  // Статическое поле для генерации уникальных номеров
  private static int _nextNumber = 1;

  public int Food { get; }
  public int Number { get; }
  public bool IsHealthy { get; set; }

  public Animal(int food)
  {
    Food = food;
    Number = _nextNumber++; // Автоматическое присвоение номера и его инкремент
  }

  public override string ToString()
  {
    return $"{GetType().Name}(Инв. №{Number}), Потребление: {Food} кг/день";
  }
}