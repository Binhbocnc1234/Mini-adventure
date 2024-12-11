using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                // Find the instance even if it is inactive
                _instance = FindSingletonInstance();

                if (_instance == null)
                {
                    // Create a new instance if none found
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    _instance = singletonObject.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
        }
        else if (_instance != this)
        {
            Debug.LogError("Detected multiple singletons: " + typeof(T).Name);
            Destroy(gameObject); // Prevent duplicates
        }
    }

    private static T FindSingletonInstance()
    {
        // Include inactive objects in the search
        T[] instances = Resources.FindObjectsOfTypeAll<T>();
        return instances.Length > 0 ? instances[0] : null;
    }
}
