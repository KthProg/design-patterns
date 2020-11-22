﻿using DesignPatterns.Patterns;
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

        static Program()
        {
            _logger = new ConsoleLogger();

            // TODO: create via injection library
            _factory = new SomeObjectFactory(_logger);
            _otherFactory = new SomeOtherObjectFactory(_logger);
        }
        static void Main(string[] args)
        {
            SystemConsole.WriteLine("Hello World!");

            foreach(IFactory factory in Factories)
            {
                IFactoryObject factoryObject = factory.MakeObject();
                factoryObject.PrintSelf();
            }

            SystemConsole.ReadLine();
        }

        static IEnumerable<IFactory> Factories => new List<IFactory>
        {
            _factory, _otherFactory
        };
    }
}