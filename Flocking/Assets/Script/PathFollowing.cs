using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : Vehicle {
    public List<GameObject> targets;
    public int currentTarget;
    public Vector3 ultimateForce;
	// Use this for initialization
	public override void Start () {
        currentTarget = 0;
        base.Start();
    }
	
	// Update is called once per frame



    public override void CalcSteeringForces()

    {
        ultimateForce = Vector3.zero;
        ultimateForce += followPath();
        ApplyForce(ultimateForce);

    }

    public Vector3 followPath()
    {
        if((transform.position - targets[currentTarget].transform.position).magnitude < 10f)
        {
            currentTarget++;
        }
        if (currentTarget > 3)
        {
            currentTarget = 0;
        }

         return Seek(targets[currentTarget].transform.position);
    }
}
