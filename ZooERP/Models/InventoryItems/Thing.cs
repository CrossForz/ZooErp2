using ZooERP.Interfaces;

namespace ZooERP.Models.InventoryItems;

// Базовый класс для инвентарных предметов.
public abstract class Thing : IInventory
{
  // Статическое поле для генерации уникальных номеров предметов
  private static int _nextNumber = 1;

  public int Number { get; protected set; }
  public string Name { get; protected set; }

  public Thing(string name)
  {
    Name = name;
    Number = _nextNumber++; // Автоматически присваиваем номер и инкрементируем счетчик
  }

  public override string ToString()
  {
    return $"{GetType().Name} - {Name} (Инв. №{Number})";
  }
}