using DesignPatterns.Patterns;
using DesignPatterns.Patterns.FactoryCommon;
using System;
using System.Collections.Generic;
using SystemConsole = System.Console;

namespace DesignPatterns.Console
{
    class Program
    {
        private static readonly ILogger _logger;

        private static readonly IFactory _factory;
        private static readonly IFactory _otherFactory;

        private static readonly IFactoryMethod _factoryMethod;
        private static readonly IFactoryMethod _otherFactoryMethod;

        static Program()
        {
            _logger = new ConsoleLogger();

            // TODO: create via injection library
            _factory = new SomeObjectFactory(_logger);
            _otherFactory = new SomeOtherObjectFactory(_logger);

            _factoryMethod = new SomeFactoryMethod(_logger);
            _otherFactoryMethod = new SomeOtherFactoryMethod(_logger);
        }
        static void Main(string[] args)
        {
            SystemConsole.WriteLine("Hello World!");

            foreach(IFactory factory in Factories)
            {
                IFactoryObject factoryObject = factory.MakeObject();
                factoryObject.PrintSelf();
            }

            IBuiltObject builtObject1 =
                new Builder(_logger)
                    .Start()
                    .Annoying()
                    .Loud()
                    .WithColor(ConsoleColor.Green)
                    .Build();

            IBuiltObject builtObject2 =
                new Builder(_logger)
                    .Start()
                    .Quiet()
                    .WithColor(ConsoleColor.Yellow)
                    .Build();

            builtObject1.PrintSelf();
            builtObject2.PrintSelf();

            foreach (IFactoryMethod factoryMethod in FactoryMethods)
            {
                IFactoryObject factoryObject = factoryMethod.CreateObject();
                factoryObject.PrintSelf();
            }

            IPrototype prototype = Prototype.InitialPrototype.Clone();
            for(int i = 0; i < 10; ++i){
                SystemConsole.WriteLine($"prototype #{prototype.Id} copied");
                prototype = prototype.Clone();
            }

            Singleton singleton = Singleton.Instance;
            SystemConsole.WriteLine($"Singleton created at {singleton.CreationDateTime}");

            IAddSubtract<int> addSubtract = new AdditionSubtraction();
            IMultiplyDivide<int> multiplyDivideAdapter = new MultiplyDivideAdapter(addSubtract);

            DivisionResult<int> divisionResult = multiplyDivideAdapter.Divide(10, 3);

            SystemConsole.WriteLine($"{nameof(MultiplyDivideAdapter)}: 10 / 3 = {divisionResult.WholePart} with remainder {divisionResult.Remainder}");

            int multiplicationResult = multiplyDivideAdapter.Multiply(10, 3);

            SystemConsole.WriteLine($"{nameof(MultiplyDivideAdapter)}: 10 x 3 = {multiplicationResult}");

            IWaterPipeBridge hotWaterPipeBridge = new WaterPipeBridge(new HotWaterPipeImp(_logger), _logger);
            IWaterPipeBridge coldWaterPipeBridge = new WaterPipeBridge(new HotWaterPipeImp(_logger), _logger);

            _logger.Log("Turn on hot");
            hotWaterPipeBridge.TurnOn();
            _logger.Log("Turn off hot");
            hotWaterPipeBridge.TurnOff();
            _logger.Log("Sprinkling hot");
            hotWaterPipeBridge.Sprinkle();

            _logger.Log("Turn on cold");
            coldWaterPipeBridge.TurnOn();
            _logger.Log("Turn off cold");
            coldWaterPipeBridge.TurnOff();
            _logger.Log("Sprinkling cold");
            coldWaterPipeBridge.Sprinkle();

            SystemConsole.ReadLine();
        }

        static IEnumerable<IFactory> Factories => new List<IFactory>
        {
            _factory, _otherFactory
        };

        static IEnumerable<IFactoryMethod> FactoryMethods => new List<IFactoryMethod>
        {
            _factoryMethod, _otherFactoryMethod
        };
    }
}
