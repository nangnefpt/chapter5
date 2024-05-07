// Lớp sealed: lớp này không thể được kế thừa
public sealed class Singleton
{
    // Thể hiện tĩnh của lớp Singleton
    private static readonly Singleton Instance;

    // Tổng số thể hiện đã được tạo
    private static int TotalInstances = 0;

    // Constructor private được sử dụng để ngăn việc tạo thể hiện bằng từ khóa 'new' bên ngoài lớp này
    private Singleton()
    {
        Console.WriteLine("--Constructor private được gọi.");
    }

    // Constructor static để khởi tạo thể hiện singleton và theo dõi tổng số thể hiện đã tạo
    static Singleton()
    {
        // In một số thông điệp trước khi tạo thể hiện
        Console.WriteLine("--Constructor static được gọi.");
        Instance = new Singleton();
        TotalInstances++;
        Console.WriteLine($"--Thể hiện Singleton được tạo. Số lần tạo: {TotalInstances}");
        Console.WriteLine("--Thoát khỏi constructor static.");
    }

    // Thuộc tính để lấy thể hiện singleton
    public static Singleton GetInstance => Instance;

    // Thuộc tính để lấy tổng số thể hiện đã tạo
    public int GetTotalInstances => TotalInstances;

    // Phương thức để in một thông điệp
    public void Print() => Console.WriteLine("Xin chào thế giới.");
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("#1. Trying to get a Singleton instance, called firstInstance.");
        Singleton firstInstance = Singleton.GetInstance;
        Console.Write("--Invoke Print() method : ");
        firstInstance.Print();

        Console.WriteLine("#2. Trying to get another Singleton instance, called secondInstance.");
        Singleton secondInstance = Singleton.GetInstance;
        Console.WriteLine($"--Number of instances: {secondInstance.GetTotalInstances}");
        Console.Write(" --Invoke Print() method : ");
        secondInstance.Print();

        if (firstInstance.Equals(secondInstance))
        {
            Console.WriteLine("=> The firstInstance and secondInstance are the same.");
        }
        else
        {
            Console.WriteLine("=> Different instances exist.");
        }

        Console.Read();
    }
}