using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMiddle : MonoBehaviour {
    public Vector3 position;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        CameraControl();
		
    }
    public void CameraControl()
    {
        List<GameObject> flock = GameObject.Find("Scenemanager").GetComponent<ExerciseManager>().flock;
        foreach (GameObject birb in flock)
        {
            position += birb.transform.position;
        }

        transform.position = position / flock.Count;
    }
}
