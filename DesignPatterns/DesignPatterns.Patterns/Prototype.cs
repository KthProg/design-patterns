namespace DesignPatterns.Patterns
{
    public interface IPrototype {
        int Id { get; }
        IPrototype Clone();
    }

    public class Prototype : IPrototype {
        public static IPrototype InitialPrototype => new Prototype(1);

        private Prototype(int id) {
            Id = id;
        }

        public int Id { get; private set; }

        public IPrototype Clone() => new Prototype(Id + 1);
    }

}