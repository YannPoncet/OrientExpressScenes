using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public List<GameObject> tutorials;

    public GameObject begin;

    private int index = 0;
	// Use this for initialization
	void Start () {
		tutorials.ForEach(tuto => tuto.SetActive(false));
        tutorials[0].SetActive(true);
	    begin.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Next()
    {
        tutorials[index].SetActive(false);

        index++;

        if (index >= tutorials.Count)
            index = 0;

        tutorials[index].SetActive(true);

        if (index == tutorials.Count-1)
            begin.SetActive(true);
        else
            begin.SetActive(false);
    }

    public void Previous()
    {
        tutorials[index].SetActive(false);

        index--;

        if (index < 0)
            index = tutorials.Count-1;

        tutorials[index].SetActive(true);

        if (index == tutorials.Count-1)
            begin.SetActive(true);
        else
            begin.SetActive(false);
    }
}
