namespace ZooERP.Models.Animals.Herbos;

// Абстрактный класс для травоядных животных.
public abstract class Herbo : Animal
{
  // Уровень доброты животного (от 0 до 10).
  public int Kindness { get; protected set; }

  public Herbo(int food, int kindness)
    : base(food)
  {
    Kindness = kindness;
  }

  public override string ToString()
  {
    return base.ToString() + $", Доброта: {Kindness}";
  }
}