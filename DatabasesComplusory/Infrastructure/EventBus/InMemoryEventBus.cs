using DatabasesComplusory.Application.Interfaces;

namespace DatabasesComplusory.Infrastructure.EventBus;

public class InMemoryEventBus : IEventBus
{
    private readonly Dictionary<Type, List<Delegate>> _handlers;  
    
    public InMemoryEventBus()  
    {  
        _handlers = new Dictionary<Type, List<Delegate>>();  
    }  
    
    public Task Publish<TEvent>(TEvent eventMessage)
    {
        if (_handlers.TryGetValue(typeof(TEvent), out var eventHandlers))  
        {  
            foreach (var handler in eventHandlers.Cast<Action<TEvent>>())  
            {  
                handler(eventMessage);  
            }  
        }  
        return Task.CompletedTask;
    }

    public Task Subscribe<TEvent>(Action<TEvent> eventHandler)
    {
        if (!_handlers.ContainsKey(typeof(TEvent)))  
        {  
            _handlers[typeof(TEvent)] = new List<Delegate>();  
        }  
  
        _handlers[typeof(TEvent)].Add(eventHandler);
        return Task.CompletedTask;
    }
}