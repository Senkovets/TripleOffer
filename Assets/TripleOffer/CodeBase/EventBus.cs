using System;
using System.Collections.Generic;
using System.Linq; 

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

            // КРИТИЧЕСКОЕ ИСПРАВЛЕНИЕ:
            // Создаем копию списка подписчиков перед итерацией.
            // Теперь, если кто-то отпишется внутри цикла (вызовет Unsubscribe),
            // он удалится из оригинального списка в Dictionary, 
            // но текущий цикл foreach спокойно дойдет до конца по этой локальной копии.
            var handlersCopy = handlers.ToList();

            foreach (var handler in handlersCopy)
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