using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Vehicle {
    public float weight;
   public  GameObject target;
    public Vector3 ultimateForce;
    // Use this for initialization
    public override void  Start ()
    {
        base.Start();
	}
	
	// Update is called once per frame
	
    override public void CalcSteeringForces()
    {
        
        ultimateForce += Seek(target.transform.position)*weight;
        ApplyForce(ultimateForce);
    }
}
