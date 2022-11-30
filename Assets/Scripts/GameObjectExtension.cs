using UnityEngine;

namespace Extensions
{
    public static class GameObjectExtension
    {
        private const int nearDistance = 7;

        public static bool HasComponent<T>(this GameObject gameObject)
        {
            return gameObject.TryGetComponent<T>(out T component);
        }
        public static bool NearTo(this GameObject gameObject, Transform target)
        {
            var currentPosition = gameObject.transform.position;
            var targetPosition = target.position;
            if (Vector3.Distance(currentPosition, targetPosition) <= nearDistance)
                return true;
            return false;
        }
    }
}