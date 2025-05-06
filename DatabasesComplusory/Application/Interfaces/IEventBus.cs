namespace DatabasesComplusory.Application.Interfaces;

public interface IEventBus
{
    Task Publish<TEvent>(TEvent eventMessage);  
    Task Subscribe<TEvent>(Action<TEvent> eventHandler);  
}