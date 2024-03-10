using System;

namespace Engine_Simulation
{
    class InternalCombustionEngine : Engine
    {
        private int[] _m {  get; set; }
        private int[] _v { get; set; }
        private double _hm { get; set; }
        private double _hv { get; set; }
        private double _vh { get; set; }
        private int _secondToOvertheating {  get; set; }

        private CoolingEngine _Cooling {  get; set; }

        public InternalCombustionEngine(double Temper)
        {
            EngineTemperature = Temper;
            ExternalTemperature = Temper;
            Inertia = 10;
            _m = new int[] { 20, 75, 100, 105, 75, 0 };
            _v = new int[] { 0, 75, 150, 200, 250, 300 };
            OverheatingTemperature = 110;
            _hm = 0.01;
            _hv = 0.0001;
            _Cooling = new CoolingEngine(Temper);
            _secondToOvertheating = 0;
        }

        public void Start()
        {
            for (int i = 0; i < _m.Length || i < _v.Length; i++)
            {
                Console.WriteLine(EngineTemperature);
                _vh = (_m[i] * _hm) + ((_v[i] * _v[i]) * _hv);
                EngineTemperature += _vh;
                EngineTemperature += _Cooling.Start(EngineTemperature);
                _secondToOvertheating++;
                Console.WriteLine($"Скорость нагрева двигателя C/сек: {_vh}");
                Console.WriteLine($"Температура двигателя: {EngineTemperature}");
            }
            while (EngineTemperature <= OverheatingTemperature)
            {
                EngineTemperature += _vh;
                EngineTemperature += _Cooling.Start(EngineTemperature);
                _secondToOvertheating++;
                Console.WriteLine(EngineTemperature);
            }
            Console.WriteLine($"{_secondToOvertheating} секунд до перегрева.");
        }
    }
}
