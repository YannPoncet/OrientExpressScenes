using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour {

    public GameObject Target;
    public Camera MainCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Target.GetComponentInChildren<Renderer>().isVisible)
        {
            this.GetComponent<Image>().enabled = true;
            this.GetComponentInChildren<Text>().enabled = true;
        }
        else
        {
            this.GetComponent<Image>().enabled = false;
            this.GetComponentInChildren<Text>().enabled = false;
        }
	}
}
