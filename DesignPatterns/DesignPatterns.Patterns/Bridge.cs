using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Patterns {
    public interface IBridge<ImpType> {
        ImpType Implementation { get; }
    }

    public interface IWaterPipeImp : IPrintsSelf {
        bool IsOn { get; }
        void TurnOn();
        void TurnOff();
    }

    public interface IWaterPipeBridge : IBridge<IWaterPipeImp> {
        void TurnOn();
        void TurnOff();
        void Sprinkle();
    }

    public abstract class WaterPipeImpCommon : CommonLogsSelf, IWaterPipeImp {
        public WaterPipeImpCommon(ILogger logger) : base(logger){

        }

        private bool _isOn;
        public bool IsOn {
            get => _isOn;
            private set {
                _isOn = value;
                PrintSelf();
            }
        }
        public void TurnOn() => IsOn = true;

        public void TurnOff() => IsOn = false;

        public override void PrintSelf() => Logger.Log($"Pipe is flowing: {IsOn}");
    }

    public class HotWaterPipeImp : WaterPipeImpCommon {
        public HotWaterPipeImp(ILogger logger) : base(logger){
            
        }
        public override void PrintSelf()  {
            base.PrintSelf();
            Logger.Log("Pipe is hot");
        }
    }

    public class ColdWaterPipeImp : WaterPipeImpCommon {
        public ColdWaterPipeImp(ILogger logger) : base(logger){
            
        }
        public override void PrintSelf()  {
            base.PrintSelf();
            Logger.Log("Pipe is cold");
        }
    }

    public class WaterPipeBridge : CommonLogsSelf, IWaterPipeBridge {
        private readonly IWaterPipeImp _implementation;
        public WaterPipeBridge(IWaterPipeImp implementation, ILogger logger) : base(logger){
            _implementation = implementation;
        }
        public IWaterPipeImp Implementation => _implementation;
        public void TurnOn() => Implementation.TurnOn();
        public void TurnOff() => Implementation.TurnOff();

        public void Sprinkle() {
            TurnOn();
            TurnOff();
        }

        public override void PrintSelf() => Implementation.PrintSelf();
    }
}