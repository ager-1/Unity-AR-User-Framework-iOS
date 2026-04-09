using UnityEngine;
using System.Collections;
using RotaryHeart.Lib.SerializableDictionary;
[System.Serializable]
public class InteractionModeDictionary:SerializableDictionaryBase<string, GameObject> { }
public class InteractionController : ARFramework<InteractionController>
{
    [SerializeField] InteractionModeDictionary interactionModes;
    GameObject currentMode;
    protected override void Awake()
    {
        base.Awake();
        ResetAllModes();
    }
    void Start()
    {
        _EnableMode("Startup");
    }
    void ResetAllModes()
    {
        foreach(GameObject mode in interactionModes.Values)
        {
            mode.SetActive(false);
        }
    }
    public static void EnableMode(string name)
    {
        Instance?._EnableMode(name);
    }
    void _EnableMode(string name)
    {
        GameObject modeObject;
        if (interactionModes.TryGetValue(name, out modeObject))
        {
            StartCoroutine(ChangeObject(modeObject));
        }
        else
        {
            Debug.LogError($"Undefined mode name:{name} ");
        }
    }
    IEnumerator ChangeObject(GameObject mode)
    {
        if (mode == currentMode) yield break;
        if (currentMode)
        {
            currentMode.SetActive(false);
            yield return null;
        }
        currentMode = mode;
        mode.SetActive(true);
    }
}