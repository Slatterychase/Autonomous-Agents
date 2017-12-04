using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Vehicle {

    public GameObject humanTarget;
    public GameObject zombieChaser;

    public float seekWeight;
    public float fleeWeight;

    public Vector3 spherePosition;
	// Use this for initialization
	public override void Start ()
    {
        base.Start();
        
	}
	
	// Update is called once per frame
	
    public override void CalcSteeringForces()
    {
        //spherePosition = GameObject.Find("Scenemanager").GetComponent<ExerciseManager>().sphere.transform.position;
       
        Vector3 ultimateForce = Vector3.zero;

        
        ultimateForce += Seek(spherePosition) * seekWeight;
        // ultimateForce.Normalize();
        //Debug.Log(ultimateForce);
        ApplyForce(ultimateForce);
    }
}
