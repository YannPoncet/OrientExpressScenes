using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMeshRender : MonoBehaviour {

    public List<MeshFilter> meshes = new List<MeshFilter>();

	// Use this for initialization
	void Start () {

	    foreach (var filter in meshes)
	    {
	        filter.mesh = null;
	        //meshRenderer.enabled = false;
	    }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
