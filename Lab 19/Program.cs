using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_19
{
    public class PC
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Processor { get; set; }
        public int Frequence { get; set; }
        public int Ram { get; set; }
        public int Disk { get; set; }
        public int Vram { get; set; }
        public int Cost { get; set; }
        public int Value { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<PC> PCmodel = new List<PC>()
            {
                new PC() {Code=12, Name="Gigabyte", Processor="Intel", Frequence=2400, Ram=4, Disk=256, Vram=1, Cost=25000,Value=10},
                new PC() {Code=13, Name="Acer", Processor="Intel", Frequence=3400, Ram=2, Disk=512, Vram=2, Cost=35000,Value=3},
                new PC() {Code=14, Name="MSI", Processor="AMD", Frequence=5400, Ram=8, Disk=1024, Vram=8, Cost=37000,Value=2},
                new PC() {Code=42, Name="HP", Processor="AMD", Frequence=2500, Ram=16, Disk=512, Vram=0, Cost=55000,Value=15},
                new PC() {Code=19, Name="Samsung", Processor="Intel", Frequence=2900, Ram=2, Disk=2048, Vram=6, Cost=21500,Value=4},
                new PC() {Code=102, Name="Apple", Processor="AMD", Frequence=3000, Ram=8, Disk=128, Vram=2, Cost=56400,Value=13}
            };
            Console.Write("Введите наимнование процессора (Intel or AMD) - ");
            string n = Console.ReadLine();
            // Все компьютеры с указанным процессором
            List<PC> selectedProcessor = (from d in PCmodel
                                          where d.Processor == n
                                          select d).ToList();
            foreach (PC d in selectedProcessor)
                Console.WriteLine($"{d.Code} {d.Name}");
            Console.WriteLine();
            // Все компьютеры с ОЗУ не менее ввведенного значения
            Console.Write("Введите объем оперативной памяти - ");
            int m = Convert.ToInt32(Console.ReadLine());
            List<PC> SelectedRam = (from d in PCmodel
                                    where d.Ram >= m
                                    select d).ToList();
            foreach (PC d in SelectedRam)
                Console.WriteLine($"{d.Code} {d.Name} {d.Ram}");
            Console.WriteLine();

            Console.WriteLine("Сортированный список по увеличению стоимости");
            Console.ReadKey();
            List<PC> SelectedValue = (from d in PCmodel
                                      orderby d.Cost
                                      select d).ToList();
            foreach (PC d in SelectedValue)
                Console.WriteLine($"{d.Code} {d.Name} {d.Cost}");
            Console.WriteLine();

            Console.WriteLine("Список, сгруппированный по типу процессора");
            Console.ReadKey();
            var SelectedTypeProcessor = (from PC in PCmodel
                                         group PC by PC.Processor into g
                                         select new { Name = g.Key, Count = g.Count() });

            foreach (var group in SelectedTypeProcessor)
                Console.WriteLine($"{group.Name} : {group.Count}");
            Console.WriteLine();

            Console.WriteLine("Самый дорогой и бюджетный компьютер");
            Console.ReadKey();
            List<PC> SelectedMax = (from d in PCmodel
                                    orderby d.Cost
                                    select d).ToList();
            var minCost = SelectedMax.First();
            var maxCost = SelectedMax.Last();
            Console.WriteLine($"Самый дорогой компьютер {maxCost.Code} {maxCost.Name} стоимостью - {maxCost.Cost}");
            Console.WriteLine($"Самый бюджетный компьютер {minCost.Code} {minCost.Name} стоимостью - {minCost.Cost}");
            Console.WriteLine();

            Console.WriteLine("Eсть ли хотя бы один компьютер в количестве не менее 30 штук?");
            Console.ReadKey();
            bool Check = PCmodel.Any(d => d.Value > 30);
            if (Check)
                Console.WriteLine("Есть в требуемом количестве");
            else
                Console.WriteLine("Нет в требуемом количестве. Печально(");
            Console.ReadKey();
        }
    }
}
