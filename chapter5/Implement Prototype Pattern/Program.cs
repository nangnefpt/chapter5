public abstract class Car
{
    protected int basePrice = 0, onRoadPrice = 0;
    public string ModelName { get; set; }

    public int BasePrice
    {
        set => basePrice = value;
        get => basePrice;
    }

    public int OnRoadPrice
    {
        set => onRoadPrice = value;
        get => onRoadPrice;
    }

    public static int SetAdditionalPrice()
    {
        Random random = new Random();
        int additionalPrice = random.Next(200_000, 500_000);
        return additionalPrice;
    }

    public abstract Car Clone();
}
// end Car
public class Mustang : Car
{
    public Mustang(string model) => (ModelName, BasePrice) = (model, 200_000);

    // Tạo một bản sao nông (shallow copy) và trả về nó.
    public override Car Clone() => this.MemberwiseClone() as Mustang;
}

public class Bentley : Car
{
    public Bentley(string model) => (ModelName, BasePrice) = (model, 300_000);

    // Tạo một bản sao nông (shallow copy) và trả về nó.
    public override Car Clone() => this.MemberwiseClone() as Bentley;
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("*** Demo Mẫu Prototype ***\n");

        // Bản gốc hoặc Ban đầu
        Car mustang = new Mustang("Mustang EcoBoost");
        Car bentley = new Bentley("Continental GT Mulliner");

        Console.WriteLine("Trước khi nhân bản, giá cơ bản:");
        Console.WriteLine($" - {mustang.ModelName} có giá cơ bản {mustang.BasePrice} Rs.");
        Console.WriteLine($" - {bentley.ModelName} có giá cơ bản {bentley.BasePrice} Rs.");
  
Car car;
car = mustang.Clone();
// Đang làm việc trên bản sao đã nhân bản
car.OnRoadPrice = car.BasePrice + Car.SetAdditionalPrice();
Console.WriteLine($"Xe là: {car.ModelName}, và giá của nó là Rs. {car.OnRoadPrice}");

car = bentley.Clone();
// Đang làm việc trên bản sao đã nhân bản
car.OnRoadPrice = car.BasePrice + Car.SetAdditionalPrice();
Console.WriteLine($"Xe là: {car.ModelName}, và giá của nó là Rs. {car.OnRoadPrice}");

Console.ReadLine();}
}
