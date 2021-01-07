using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Patterns
{
    public class Singleton {
        public static readonly Singleton Instance;

        static Singleton(){
            Instance = new Singleton(DateTime.Now);
        }

        public DateTime CreationDateTime { get; }
        private Singleton(DateTime creationDateTime){
            CreationDateTime = creationDateTime;
        }
    }
}