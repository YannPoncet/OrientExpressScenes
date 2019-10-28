using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAlongPath : MonoBehaviour {

    public List<Transform> pathPoints;
    public float speed = 5;

    private bool walking = false;

    Animator animator;
    int index = 0;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void OnAnimatorMove () {
        if (pathPoints.Count > 0)
        {
            if (walking)
            {
                Vector2 flatPosition = new Vector2(transform.position.x, transform.position.z);
                Vector2 flatDestination = new Vector2(pathPoints[index].position.x, pathPoints[index].position.z);
                if (Vector2.Distance(flatPosition, flatDestination) < speed)
                {
                    index++;
                    index %= pathPoints.Count;
                    walking = false;
                    animator.SetBool("Walking", false);
                }
                else
                {
                    transform.LookAt(pathPoints[index]);
                    transform.position += speed * transform.forward;
                }
            }
            
        }
	}

    public void StartWalking()
    {
        walking = true;
        animator.SetBool("Walking", true);
    }
}
