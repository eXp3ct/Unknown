using UnityEngine;

public static class GameObjectExtension
{
    public static bool HasComponent<T>(this GameObject gameObject)
    {
        return gameObject.TryGetComponent<T>(out T component);
    }
    public static bool NearTo(this GameObject gameObject, Transform target)
    {
        var currentPosition = gameObject.transform.position;
        var targetPosition = target.position;
        if (Vector3.Distance(currentPosition, targetPosition) <= 5)
            return true;
        return false;
    }
}