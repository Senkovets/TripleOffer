using System;
using System.Collections.Generic;
using UnityEngine;

namespace TripleOffer.CodeBase
{
    public class WindowService : IWindowService
    {
        private readonly Dictionary<Type, MonoBehaviour> _windows;

        public WindowService(Dictionary<Type, MonoBehaviour> windows)
        {
            _windows = windows;
        }

        public T Open<T>() where T : MonoBehaviour
        {
            var window = (T)_windows[typeof(T)];
            window.gameObject.SetActive(true);
            return window;
        }

        public void Close<T>() where T : MonoBehaviour
        {
            var window = _windows[typeof(T)];
            window.gameObject.SetActive(false);
        }
    }
}