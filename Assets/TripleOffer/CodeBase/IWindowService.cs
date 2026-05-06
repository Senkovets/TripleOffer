using UnityEngine;

namespace TripleOffer.CodeBase
{
    public interface IWindowService
    {
        T Open<T>() where T : MonoBehaviour;
        void Close<T>() where T : MonoBehaviour;
    }
}