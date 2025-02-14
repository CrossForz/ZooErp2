using ZooERP.Models;
using ZooERP.Models.Animals;

namespace ZooERP.Interfaces;

public interface IVeterinaryClinic
{
  // Проверяет состояние здоровья животного.
  bool CheckHealth(Animal animal);
}