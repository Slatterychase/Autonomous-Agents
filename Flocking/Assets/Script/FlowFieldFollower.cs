using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowFieldFollower : Vehicle {
    public Vector3 ultimateForce;
    public Vector3 flowPosition;
    public Terrain terrainFlow;
    public GameObject center;
	// Use this for initialization
	public override void Start () {
        base.Start();
	}

    // Update is called once per frame
    public override void CalcSteeringForces()
    {
        ultimateForce = Vector3.zero;
        flowPosition = gameObject.transform.position;
        flowPosition.x = flowPosition.x / 10;
        flowPosition.z = flowPosition.z / 10;
        if (transform.position.x < 0 || transform.position.x > terrain.terrainData.size.x || transform.position.z < 0 || transform.position.z > terrain.terrainData.size.z)
        {
            

            ultimateForce += Seek(new Vector3(200, 0, 200));
            
        }
        else
        {
            
            ultimateForce += GameObject.Find("Scenemanager").GetComponent<FlowField>().findLocation((flowPosition));
        }
        
        //Debug.Log(ultimateForce);
        
       

        ApplyForce(ultimateForce*.07f);

    }

}
