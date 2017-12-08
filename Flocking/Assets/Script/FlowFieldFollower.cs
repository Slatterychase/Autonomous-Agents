using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowFieldFollower : Vehicle {
    public Vector3 ultimateForce;
	// Use this for initialization
	public override void Start () {
        base.Start();
	}

    // Update is called once per frame
    public override void CalcSteeringForces()
    {
        ultimateForce = Vector3.zero;
        ultimateForce = GameObject.Find("Scenemanager").GetComponent<FlowField>().findLocation(gameObject.transform.position);

        ApplyForce(ultimateForce);

    }
}
