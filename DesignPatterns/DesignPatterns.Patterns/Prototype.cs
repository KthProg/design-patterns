public interface IPrototype {
    IPrototype Clone();
}

public interface IPrototypeClient {
    IPrototypeClient Create(IPrototype prototype);
}