using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LookAtCamera : MonoBehaviour {

    public List<Transform> objectsToTurn;
    public GameObject ArCamera;
	// Update is called once per frame
	void Update () {

	    foreach (var transform1 in objectsToTurn)
	    {
	        transform1.LookAt(ArCamera.transform.position);
	    }
	}
}
