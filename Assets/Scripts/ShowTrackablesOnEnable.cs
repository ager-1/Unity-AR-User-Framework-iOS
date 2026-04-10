using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ShowTrackablesOnEnable : MonoBehaviour
{
    [SerializeField] XROrigin sessionOrigin;
    ARPlaneManager planeManager;
    ARPointCloudManager cloudManager;
    bool isStarted;
    void Awake()
    {
        planeManager = sessionOrigin.GetComponent<ARPlaneManager>();
        cloudManager = sessionOrigin.GetComponent<ARPointCloudManager>();
    }
    void OnEnable()
    {
        ShowTrackables(true);
    }
    void OnDisable()
    {
        if (isStarted) ShowTrackables(false);
    }
    private void Start()
    {
        isStarted = true;
    }
    void ShowTrackables(bool show)
    {
        if (cloudManager)
        {
            cloudManager.SetTrackablesActive(show);
            cloudManager.enabled = show;
        }
        if(planeManager)
        {
            planeManager.SetTrackablesActive(show);
            planeManager.enabled = show;
        }
    }

}
