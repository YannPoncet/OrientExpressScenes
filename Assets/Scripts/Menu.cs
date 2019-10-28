using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vuforia;

public class Menu : MonoBehaviour
{
	// Use this for initialization
    private GameObject ARCamera;
	void Start ()
	{
        //ARCamera = GameObject.Find("ARCamera");

        //Pour connaitre la correspondance entre le numéro et la scène --> File/Build Settings

        //Forquenot
	    //SceneManager.LoadSceneAsync(1,LoadSceneMode.Additive);

        //Conducteur Forquenot
	    //SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);

        //Quai Micheline
	    //SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);

        //Baltic
	    //SceneManager.LoadSceneAsync(4, LoadSceneMode.Additive);

        //Quai TEE
	    //SceneManager.LoadSceneAsync(5, LoadSceneMode.Additive);

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
        //SceneManager.MoveGameObjectToScene(ARCamera, SceneManager.GetSceneAt(scene));
        //SceneManager.SetActiveScene(SceneManager.GetSceneAt(scene));
    }
    
}
