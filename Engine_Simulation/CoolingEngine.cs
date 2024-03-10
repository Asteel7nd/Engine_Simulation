using System;

namespace Engine_Simulation
{
    class CoolingEngine : Engine
    {
        private double _vc {  get; set; }

        public CoolingEngine(double Temper)
        {
            C = 0.1;
            ExternalTemperature = Temper;
        }

        public double Start(double EngineTemperature)
        {
            _vc = C * (ExternalTemperature - EngineTemperature);
            return _vc;
        }
    }
}
