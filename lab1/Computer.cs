using System;

namespace Lab1
{
    // Класс процессора
    public class CPU
    {
        private string manufacturer;
        private int cores;
        private int threads;
        private float frequency;

        public CPU(string manufacturer = "Intel", int cores = 2, int threads = 4, float frequency = 2.9f)



        {
            this.manufacturer = manufacturer;
            this.cores = cores;
            this.threads = threads;
            this.frequency = frequency;
        }

        public string Manufacturer => manufacturer;
        public int Cores => cores;
        public int Threads => threads;
        public string FrequencyString => $"{frequency} ГГц";

        public void PrintCPU()
        {
            Console.WriteLine("Характеристики процессора:");
            Console.WriteLine("Производитель: " + manufacturer);
            Console.WriteLine("Кол-во ядер: " + cores);
            Console.WriteLine("Кол-во потоков: " + threads);
            Console.WriteLine("Тактовая частота: " + frequency + " ГГц");
            Console.WriteLine();
        }
    }

    // Класс оперативной памяти
    public class RAM
    {
        private int capacity;
        private int type;
        private int frequency;

        public RAM(int capacity = 8, int type = 3, int frequency = 1600)
        {
            this.capacity = capacity;
            this.type = type;
            this.frequency = frequency;
        }

        public int Capacity => capacity;
        public string Type => "DDR" + type;
        public string FrequencyString => $"{frequency} МГц";

        public void PrintRAM()
        {
            Console.WriteLine("Характеристики ОЗУ:");
            Console.WriteLine("Объём: " + capacity + " Гб");
            Console.WriteLine("Тип: DDR" + type);
            Console.WriteLine("Тактовая частота: " + frequency + " МГц");
            Console.WriteLine();
        }
    }

    // Класс накопителя
    public class StorageDevice
    {
        private string type;
        private int capacity;
        private int speed;

        public StorageDevice(string type = "HDD", int capacity = 512, int speed = 200)
        {
            this.type = type;
            this.capacity = capacity;
            this.speed = speed;
        }

        public string Type => type;
        public string CapacityString => capacity >= 1024 ? $"{capacity / 1024} ТБ" : $"{capacity} ГБ";
        public string SpeedString => $"{speed} МБ/с";

        public void PrintStorage()
        {
            Console.WriteLine("Характеристики накопителя:");
            Console.WriteLine("Тип: " + type);
            Console.WriteLine("Объём: " + capacity + " Гб");
            Console.WriteLine("Скорость: " + speed + " Мб/с");
            Console.WriteLine();
        }
    }

    // Класс видеокарты
    public class VideoCard
    {
        private string? manufacturer;
        private int capacity;
        private int type;
        private int frequency;

        public VideoCard(string? manufacturer = "NVIDIA", int capacity = 4, int type = 6, int frequency = 1185)
        {
            this.manufacturer = manufacturer;
            this.capacity = capacity;
            this.type = type;
            this.frequency = frequency;
        }

        public string? Manufacturer => manufacturer;
        public string CapacityString => $"{capacity} ГБ";
        public string TypeMemory => "GDDR" + type;
        public string FrequencyString => $"{frequency} МГц";
        public bool HasVideoCard => manufacturer != null;

        public void PrintVideoCard()
        {
            if (manufacturer == null)
            {
                Console.WriteLine("Видеокарта отсутствует");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("Характеристики видеокарты:");
            Console.WriteLine("Производитель: " + manufacturer);
            Console.WriteLine("Тип: GDDR" + type);
            Console.WriteLine("Объём: " + capacity + " Гб");
            Console.WriteLine("Тактовая частота GPU: " + frequency + " МГц");
            Console.WriteLine();
        }
    }

    // Главный класс - Персональный компьютер
    public class PersonalComputer
    {
        private bool powerStatus = false; // Статус: выключен по умолчанию

        // Создаем комплектующие (protected, чтобы наследники в 3 задании могли их менять)
        public CPU cpu = new CPU();
        public RAM ram = new RAM();
        public StorageDevice storage = new StorageDevice();
        public VideoCard videoCard = new VideoCard();

        public void PowerOn()
        {
            if (!powerStatus)
            {
                powerStatus = true;
                Console.WriteLine("Включение выполнено!");
            }
        }

        public void PowerOff()
        {
            if (powerStatus)
            {
                powerStatus = false;
                Console.WriteLine("Выключение выполнено!");
            }
        }

        public void Restart()
        {
            if (powerStatus)
            {
                PowerOff();
                PowerOn();
                Console.WriteLine("Перезагрузка выполнена!");
            }
        }

        public void PrintPowerStatus()
        {
            Console.WriteLine($"Статус питания компьютера: {powerStatus}");
            Console.WriteLine();
        }

        public virtual void PrintAllComponents()
        {
            Console.WriteLine("== ХАРАКТЕРИСТИКИ КОМПЬЮТЕРА ==");
            cpu.PrintCPU();
            ram.PrintRAM();
            storage.PrintStorage();
            videoCard.PrintVideoCard();
        }
    }

    public class Office : PersonalComputer
    {
        public Office()
        {
            cpu = new CPU("Intel", 2, 2, 3.5f);
            ram = new RAM(8, 3, 1600);
            storage = new StorageDevice("SSD SATA", 512, 180);
            videoCard = new VideoCard(null); // Офисному ПК видеокарта не нужна
        }
    }

    public class Server : PersonalComputer
    {
        public Server()
        {
            cpu = new CPU("Intel Xeon", 60, 120, 1.9f);
            ram = new RAM(512, 5, 2400);
            storage = new StorageDevice("HDD", 20 * 1024, 270); // 20 ТБ
            videoCard = new VideoCard("NVIDIA", 48, 6, 1410);
        }
    }

    public class Gamer : PersonalComputer
    {
        public Gamer()
        {
            cpu = new CPU("AMD Ryzen", 8, 16, 4.2f);
            ram = new RAM(32, 5, 6000);
            storage = new StorageDevice("SSD SATA", 2 * 1024, 6900); // 2 ТБ
            videoCard = new VideoCard("NVIDIA", 12, 6, 1980);
        }
    }

    public class Laptop : PersonalComputer
    {
        public Laptop()
        {
            cpu = new CPU("Intel Core i7", 6, 12, 2.6f);
            ram = new RAM(16, 4, 2200);
            storage = new StorageDevice("SSD M2", 1024, 2100);
            videoCard = new VideoCard("NVIDIA", 6, 6, 1600);
        }
    }
}