
using UnityEngine;

public static class GameObjectExtension
{
    public static bool HasComponent<T>(this GameObject gameObject)
    {
        return gameObject.TryGetComponent<T>(out T component);
    }
}