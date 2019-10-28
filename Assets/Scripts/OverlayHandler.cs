using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class OverlayHandler : MonoBehaviour, ITrackableEventHandler
{

    public GameObject Overlay;
    public List<GameObject> WhenDetected;


    private TrackableBehaviour mTrackableBehaviour;

    // Use this for initialization
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Overlay.SetActive(false);
            if(WhenDetected != null && WhenDetected.Count != 0 )
                WhenDetected.ForEach(go => go.SetActive(true));

        }
        else
        {
            Overlay.SetActive(true);
            if (WhenDetected != null && WhenDetected.Count != 0)
                WhenDetected.ForEach(go => go.SetActive(false));
        }
    }
}
