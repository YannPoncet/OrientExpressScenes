using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveDebugging : MonoBehaviour
{
    private GameObject Marker;

    private List<Transform> MarkerChilds = new List<Transform>();
    private GameObject HierarchyGameObjects;
    private string hierarchyString = "";

    private Text TextDebug;

    private string transformText
    {
        get { return _transformText; }
        set
        {
            _transformText = value;
            TextDebug.text = _transformText;
        }
    }
    private string _transformText;

    private GameObject TogglesTransform;
    private Toggle rotationToogle;
    private Toggle localRotationToogle;
    private Toggle localPositionToggle;
    private Toggle scaleToggle;

    private GameObject DisplacementButtonsParent;

    public Transform activeTransform;
    private const int index = 5;

    private GameObject EditMovementButtons;
    private float movement;


	// Use this for initialization
	void Start ()
	{
	    TextDebug = this.transform.GetComponentInChildren<Text>();
        TogglesTransform = GameObject.Find("TogglesTransform");
        rotationToogle = GameObject.Find("RotationToggle").GetComponent<Toggle>();
	    localRotationToogle = GameObject.Find("LocalRotationToggle").GetComponent<Toggle>();
	    localPositionToggle = GameObject.Find("LocalPositionToggle").GetComponent<Toggle>();
	    scaleToggle = GameObject.Find("ScaleToggle").GetComponent<Toggle>();
        DisplacementButtonsParent = GameObject.Find("DisplacementButtons");

        Marker = GameObject.Find("Marker");
	    HierarchyGameObjects= GameObject.Find("HierarchyGameObjects");

        CountChildren(Marker.transform,0);
        //SetActiveTransform(0);
	    transformText = "World\n" + activeTransform.transform.position.ToString("F3") + "\n" + activeTransform.transform.rotation.ToString("F3") 
	                    + "\n\n" + "Local\n" + activeTransform.transform.localPosition.ToString("F3") + "\n" + activeTransform.transform.localRotation.ToString("F3");

	    EditMovementButtons = GameObject.Find("EditMovementButtons");
        movement = 1f;

        TogglesTransform.SetActive(false);
        localRotationToogle.gameObject.SetActive(false);
        HierarchyGameObjects.SetActive(false);
	    DisplacementButtonsParent.SetActive(false);
	    EditMovementButtons.SetActive(false);
        TextDebug.gameObject.SetActive(false);
    }

    void CountChildren(Transform a,int level)
    {
        if (level >= 3) return;

        foreach (Transform b in a)
        {
            MarkerChilds.Add(b);

            for (int i = 0; i < level; i++)
            {
                hierarchyString += "\t";
            }

            hierarchyString += b.name + "\n";


            //Debug.Log("Child: " + b);
            CountChildren(b,level+1);
        }
    }

    // Update is called once per frame
    void Update () {

    }

    public void MoveTransform(int x, int y,int z)
    {
        if (activeTransform != null)
        {
            if(localRotationToogle.isOn)
                activeTransform.localRotation *= Quaternion.AngleAxis(movement, new Vector3(x, y, z));
            else if(rotationToogle.isOn)
                activeTransform.rotation *= Quaternion.AngleAxis(movement, new Vector3(x, y, z));
            else if(localPositionToggle.isOn)
                activeTransform.localPosition += new Vector3(x * movement, y * movement, z * movement);
            else if(scaleToggle.isOn)
                activeTransform.localScale += new Vector3(x * movement, y * movement, z * movement);
            else
                activeTransform.position += new Vector3(x * movement, y * movement, z * movement);
            //transformText = "World\n" + activeTransform.localScale + "\n" +activeTransform.transform.position + "\n" + activeTransform.transform.rotation.eulerAngles + "\n\n" + "Local\n" + activeTransform.transform.localPosition + "\n" + activeTransform.transform.localRotation.eulerAngles;
        }
    }

    public void MoveX(int x)
    {
        MoveTransform(x,0,0);
    }

    public void MoveY(int y)
    {
        MoveTransform(0, y, 0);
    }

    public void MoveZ(int z)
    {
        MoveTransform(0, 0, z);
    }

    public void SetActiveTransform(int i)
    {
        activeTransform = MarkerChilds[index];
        //if(index+i < MarkerChilds.Count && index+i >=0)
        //{
        //    index += i;
        //    activeTransform = MarkerChilds[index];

        //    hierarchyString = hierarchyString.Replace("\t*", "");
        //    hierarchyString = hierarchyString.Replace(activeTransform.name + "\n", activeTransform.name + "\t*\n");
        //    HierarchyGameObjects.GetComponentInChildren<Text>().text = hierarchyString;
        //    MoveTransform(0, 0, 0);
        //}
    }

    public void SetMovement(float value)
    {
        movement = value;
    }

}
