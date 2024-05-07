using Demo_Factories_Pattern;
using System;
using System.Collections.Generic;

namespace Demo_Factories_Pattern
{
    // Cả lớp Lion và Tiger đều sẽ triển khai phương thức của giao diện IAnimal.
    public interface IAnimal
    {
        void AboutMe();
    }

    // Lớp Lion
    public class Lion : IAnimal
    {
        public void AboutMe() => Console.WriteLine("Đây là Su tu.");
    }

    // Lớp Tiger
    public class Tiger : IAnimal
    {
        public void AboutMe() => Console.WriteLine("Đây là Ho.");
    }
}
// Cả LionFactory và TigerFactory sẽ sử dụng lớp này.
public abstract class AnimalFactory
{
    /*
    Phương thức factory cho phép một lớp trì hoãn việc khởi tạo đối tượng cho các lớp con.
    Phương thức sau sẽ tạo ra một Tiger hoặc một Lion,
    nhưng tại thời điểm này nó không biết liệu nó sẽ nhận được một Lion hay một Tiger.
    Điều này sẽ được quyết định bởi các lớp con tức là LionFactory hoặc TigerFactory.
    Vì vậy, phương thức sau đây đang hoạt động như một factory (của việc tạo ra).
    */
    public abstract IAnimal CreateAnimal();
}

// LionFactory được sử dụng để tạo ra các Sư tử
public class LionFactory : AnimalFactory
{
    // Tạo ra một Sư tử
    public override IAnimal CreateAnimal() => new Lion();
}
// TigerFactory được sử dụng để tạo ra các con hổ
public class TigerFactory : AnimalFactory
{
    // Tạo một con hổ
    public override IAnimal CreateAnimal() => new Tiger();
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("*** Demo Mau Phương Thuc Factory. ***\n");

        // Tạo một danh sách AnimalFactory bao gồm TigerFactory và LionFactory
        List<AnimalFactory> animalFactoryList = new List<AnimalFactory>
        {
            new TigerFactory(),
            new LionFactory()
        };

        // Lặp qua danh sách và tạo đối tượng animal từ mỗi factory và gọi phương thức AboutMe()
        foreach (var animalFactory in animalFactoryList)
        {
            animalFactory.CreateAnimal().AboutMe();
            Console.ReadLine();
        }
    }
}
