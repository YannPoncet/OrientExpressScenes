using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;

public class VuforiaRoutine : MonoBehaviour
{
    private long elapsedMs = 0;
    private int cpt = 0;

    private System.Diagnostics.Stopwatch watch ;

    // Use this for initialization
    void Start()
    {
        watch = new Stopwatch();
        StartCoroutine(Loading());

    }

    private void OnVuforiaStarted()
    {
        CameraDevice.Instance.SetFocusMode(
            CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
    }

    private void OnPaused(bool paused)
    {
        if (!paused) // resumed
        {
            // Set again autofocus mode when app is resumed
            CameraDevice.Instance.SetFocusMode(
               CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Loading()
    {
        while (VuforiaRuntime.Instance.InitializationState != VuforiaRuntime.InitState.INITIALIZED || elapsedMs < 3000) //|| cpt < 3)
        {
            this.watch.Stop();
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
            elapsedMs += watch.ElapsedMilliseconds;
            watch = Stopwatch.StartNew();
            GameObject.Find("Slider").GetComponent<Slider>().value = elapsedMs;

            yield return null;
        }

        //GameObject.Find("Marker").SetActive(true);
        GameObject.Find("Loading").SetActive(false);
    }

}
