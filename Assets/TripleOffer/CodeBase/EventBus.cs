using System;
using System.Collections.Generic;

namespace TripleOffer.CodeBase
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<Delegate>> _subscribers = new();

        public void Publish<T>(T evt)
        {
            var type = typeof(T);

            if (!_subscribers.TryGetValue(type, out var handlers))
                return;

            foreach (var handler in handlers)
            {
                ((Action<T>)handler)?.Invoke(evt);
            }
        }

        public void Subscribe<T>(Action<T> handler)
        {
            var type = typeof(T);

            if (!_subscribers.ContainsKey(type))
                _subscribers[type] = new List<Delegate>();

            _subscribers[type].Add(handler);
        }

        public void Unsubscribe<T>(Action<T> handler)
        {
            var type = typeof(T);

            if (_subscribers.TryGetValue(type, out var handlers))
            {
                handlers.Remove(handler);
            }
        }
    }
}