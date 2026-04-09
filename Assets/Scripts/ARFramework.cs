using UnityEngine;

public class ARFramework<T>: MonoBehaviour where T: ARFramework<T>
{
    public static T Instance { get; private set; }
    public static bool IsInitialized
    {
        get { return Instance != null; }
    }
    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError($"Trying to instantiate a second instance of singleton class {GetType().Name}");
        }
        else
        {
            Instance = (T)this;
        }
    }
    protected virtual void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

}
