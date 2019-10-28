using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustPosition : MonoBehaviour {

    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = sliderX.value;
        float y = sliderY.value;
        float z = sliderZ.value;
        sliderX.GetComponentInChildren<Text>().text = x.ToString();
        sliderY.GetComponentInChildren<Text>().text = y.ToString();
        sliderZ.GetComponentInChildren<Text>().text = z.ToString();
        this.transform.position = new Vector3(x, y, z);
	}

}
