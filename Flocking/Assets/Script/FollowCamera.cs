using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    public List<GameObject> flock;
    public Vector3 position;
    public Vector3 rotation;

    // Use this for initialization
    void Start ()
    {
        flock = GameObject.Find("Scenemanager").GetComponent<ExerciseManager>().flock;
    }
	
	// Update is called once per frame
	void Update ()
    {

        FindCenter();
        
	}
    public void FindCenter()
    {
        position = Vector3.zero;
        foreach (GameObject birb in flock)
        {
            position += birb.transform.position ;
            

            
        }
        gameObject.transform.position = position / flock.Count;
    }
}
