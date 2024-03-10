using System;

namespace Engine_Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите температуру воздуха: ");
            double Temper = Convert.ToDouble(Console.ReadLine());
            InternalCombustionEngine engine = new InternalCombustionEngine(Temper);
            engine.Start();
        }
    }
}
