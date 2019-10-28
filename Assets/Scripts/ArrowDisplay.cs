using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDisplay : MonoBehaviour {

    public List<GameObject> elements;

    public Button next;
    public Button previous;

    // Use this for initialization
    void Start () {
        next.onClick.AddListener(NextOnClick);
        previous.onClick.AddListener(PreviousOnClick);
    }

    void NextOnClick()
    {

        for (int i = 0; i < elements.Count; ++i)
        {
            if(elements[i].active){
                if (i == (elements.Count - 1))
                    elements[0].active = true;
                else
                    elements[i+1].active = true;

                elements[i].active = false;
                break;
            }
    
        }
    }
    void PreviousOnClick()
    {
        for (int i = 0; i < elements.Count; ++i)
        {
            if (elements[i].active)
            {
                if (i == 0)
                    elements[elements.Count-1].active = true;
                else
                    elements[i -1].active = true;

                elements[i].active = false;
                break;
            }

        }
    }
}
