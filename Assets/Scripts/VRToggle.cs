using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using Vuforia;

public class VRToggle : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }

    


    public void ToggleVR()
    {
        if (XRSettings.loadedDeviceName == "None" || XRSettings.loadedDeviceName == "")
        {
            Debug.Log("Changed to VR.");
            this.GetComponentInChildren<Text>().text = "Mode Cardboard : On";
            XRSettings.enabled = true;
            if (CameraDevice.Instance.Stop() && CameraDevice.Instance.Deinit())
            {
                DigitalEyewearARController.Instance.SetEyewearType(DigitalEyewearARController.EyewearType.VideoSeeThrough);
                DigitalEyewearARController.Instance.SetMode(Device.Mode.MODE_VR);
                DigitalEyewearARController.Instance.SetViewerActive(true, true);
            }
        }
        else
        {
            Debug.Log("Changed to AR.");
            this.GetComponentInChildren<Text>().text = "Mode Cardboard : Off";
            XRSettings.enabled = false;
            DigitalEyewearARController.Instance.SetEyewearType(DigitalEyewearARController.EyewearType.None);
            DigitalEyewearARController.Instance.SetMode(Device.Mode.MODE_AR);
            DigitalEyewearARController.Instance.SetViewerActive(false, true);
        }
        //if (XRSettings.loadedDeviceName == "cardboard")
        //{
        //    this.GetComponentInChildren<Text>().text = "Mode Cardboard : Off";
        //    StartCoroutine(LoadDevice("None"));
        //}
        //else
        //{
        //    this.GetComponentInChildren<Text>().text = "Mode Cardboard : On";
        //    StartCoroutine(LoadDevice("cardboard"));
        //}
    }

    //IEnumerator LoadDevice(string newDevice)
    //{
    //    XRSettings.LoadDeviceByName(newDevice);
    //    yield return null;
    //    XRSettings.enabled = true;
    //}
}
