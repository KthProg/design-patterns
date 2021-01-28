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

        private static readonly IMultiplyDivide<int> _multiplyDivideAdapter;

        private static readonly IWaterPipeBridge _hotWaterPipeBridge;
        private static readonly IWaterPipeBridge _coldWaterPipeBridge;
        private static IComposite _composite;

        private static IWrapper<GiftBox> _wrapper;

        static Program()
        {
            _logger = new ConsoleLogger();

            // TODO: create via injection library
            _factory = new SomeObjectFactory(_logger);
            _otherFactory = new SomeOtherObjectFactory(_logger);

            _factoryMethod = new SomeFactoryMethod(_logger);
            _otherFactoryMethod = new SomeOtherFactoryMethod(_logger);

            IAddSubtract<int> addSubtract = new AdditionSubtraction();
            _multiplyDivideAdapter = new MultiplyDivideAdapter(addSubtract);

            _hotWaterPipeBridge = new WaterPipeBridge(new HotWaterPipeImp(_logger), _logger);
            _coldWaterPipeBridge = new WaterPipeBridge(new HotWaterPipeImp(_logger), _logger);

            _composite = _MakeCompositeTree();

            _wrapper = new WrappingPaper(new GiftBox(new Gift("Teddy bear")));
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

            DivisionResult<int> divisionResult = _multiplyDivideAdapter.Divide(10, 3);

            SystemConsole.WriteLine($"{nameof(MultiplyDivideAdapter)}: 10 / 3 = {divisionResult.WholePart} with remainder {divisionResult.Remainder}");

            int multiplicationResult = _multiplyDivideAdapter.Multiply(10, 3);

            SystemConsole.WriteLine($"{nameof(MultiplyDivideAdapter)}: 10 x 3 = {multiplicationResult}");

            _logger.Log("Turn on hot");
            _hotWaterPipeBridge.TurnOn();
            _logger.Log("Turn off hot");
            _hotWaterPipeBridge.TurnOff();
            _logger.Log("Sprinkling hot");
            _hotWaterPipeBridge.Sprinkle();

            _logger.Log("Turn on cold");
            _coldWaterPipeBridge.TurnOn();
            _logger.Log("Turn off cold");
            _coldWaterPipeBridge.TurnOff();
            _logger.Log("Sprinkling cold");
            _coldWaterPipeBridge.Sprinkle();

            _TraverseCompositeTree(_composite);

            _logger.Log($"It seems we have a gift! First let's unwrap the {_wrapper.GetType().Name}");
            GiftBox giftBox = (_wrapper as WrappingPaper).Unwrap();
            _logger.Log($"We have the {giftBox.GetType().Name} open, now let's take our gift out.");
            Gift gift = giftBox.Open();
            _logger.Log($"The gift is a {gift.Name}!");

            SystemConsole.ReadLine();
        }

        private static IEnumerable<IFactory> Factories => new List<IFactory>
        {
            _factory, _otherFactory
        };

        private static IEnumerable<IFactoryMethod> FactoryMethods => new List<IFactoryMethod>
        {
            _factoryMethod, _otherFactoryMethod
        };

        private static IComposite _MakeCompositeTree(){
            IComposite rootComposite = new CompositeA(_logger);

            IComposite childComposite1 = new CompositeB(_logger);
            IComposite childComposite2 = new CompositeB(_logger);

            IComposite childComposite1_1 = new CompositeC(_logger);
            IComposite childComposite2_1 = new CompositeC(_logger);
            IComposite childComposite2_2 = new CompositeC(_logger);

            childComposite1.Add(childComposite1_1);
            childComposite2.Add(childComposite2_1);
            childComposite2.Add(childComposite2_2);

            rootComposite.Add(childComposite1);
            rootComposite.Add(childComposite2);

            return rootComposite;
        }

        private static void _TraverseCompositeTree(IComposite composite, int depth = 0, int index = 0){
            _logger.Log($"{new String('\t', depth)}{index}|", isInline: true);
            composite.PrintSelf();

            for(int compositeChildIndex = 0; compositeChildIndex < composite.ChildrenCount; ++compositeChildIndex){
                IComposite child = composite.GetChildAt(compositeChildIndex);
                _TraverseCompositeTree(child, depth: depth + 1, index: compositeChildIndex);
            }
        }
    }
}
