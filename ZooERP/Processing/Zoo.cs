using ZooERP.Interfaces;
using ZooERP.Models.Animals;

namespace ZooERP.Processing;

// Класс, описывающий зоопарк.
// Содержит список животных и инвентарных предметов, а также связан с ветеринарной клиникой.
public class Zoo
{
  private readonly List<Animal> _animals = new List<Animal>();
  private readonly List<IInventory> _inventoryItems = new List<IInventory>();

  private readonly IVeterinaryClinic _vetClinic;

  public Zoo(IVeterinaryClinic vetClinic)
  {
    _vetClinic = vetClinic;
  }

  /// <summary>
  /// Пытается принять животное после проверки ветеринаром.
  /// </summary>
  public bool AdmitAnimal(Animal animal)
  {
    if (_vetClinic.CheckHealth(animal))
    {
      _animals.Add(animal);
      _inventoryItems.Add(animal); // животное участвует в инвентаризации
      return true;
    }

    return false;
  }

  /// <summary>
  /// Добавляет инвентарный предмет (например, стол или компьютер) на баланс зоопарка.
  /// </summary>
  public void AddInventoryItem(IInventory item)
  {
    _inventoryItems.Add(item);
  }

  public int TotalAnimals => _animals.Count;

  /// <summary>
  /// Общее суточное потребление еды всеми животными.
  /// </summary>
  public int TotalFoodConsumption() => _animals.Sum(a => a.Food);

  /// <summary>
  /// Возвращает список животных, пригодных для контактного зоопарка.
  /// Критерий – животное должно быть травоядным с уровнем доброты больше 5.
  /// </summary>
  public IEnumerable<Animal> GetInteractiveAnimals()
  {
    return _animals
      .Where(a => a is Models.Animals.Herbos.Herbo herbo && herbo.Kindness > 5);
  }

  /// <summary>
  /// Возвращает список всех объектов, участвующих в инвентаризации.
  /// </summary>
  public IEnumerable<IInventory> GetInventoryItems() => _inventoryItems;
}