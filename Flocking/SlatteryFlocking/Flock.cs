﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : Vehicle {
    public List<GameObject> flock;
    public Vector3 align;
    public Vector3 cohesion;
    public int neighborCountCohesion;
    public Vector3 ultimateForce;

    public Vector3 averagePosition;

    public List<GameObject> obs;

    public override void CalcSteeringForces()

    {
        ultimateForce = Vector3.zero;
       ultimateForce += computeCohesion();
        ultimateForce += computeAlignment();
        foreach(GameObject obstacle in obs)
        {
            ultimateForce += AvoidObstacle(obstacle.transform.position, 5f);
        }
        ultimateForce += Seperation();
        ultimateForce += Seek(GameObject.Find("Scenemanager").GetComponent<ExerciseManager>().target.transform.position);
      
       //ApplyForce( computeCohesion());
        ApplyForce(ultimateForce);
    }

    // Use this for initialization
   public override void  Start () 
{
        obs = GameObject.Find("Scenemanager").GetComponent<ExerciseManager>().obstacles;
        flock = GameObject.Find("Scenemanager").GetComponent<ExerciseManager>().flock;
       
        base.Start();
		
	}
	
	// Update is called once per frame
	

    public Vector3 computeAlignment()
    {
        align = Vector3.zero;
        foreach (GameObject agent in flock)
        {
            if((transform.position.magnitude+agent.transform.position.magnitude)<1f && (transform.position.magnitude + agent.transform.position.magnitude) > 0)
            {
                align += agent.GetComponent<Vehicle>().velocity;
            }

            
        }
        return align/flock.Count;
    }
    public Vector3 computeCohesion()
    {
        cohesion = Vector3.zero;
        neighborCountCohesion = 0;
        foreach (GameObject agent in flock)
        {
            cohesion += agent.transform.position;
           
            
        }
       // Debug.Log(neighborCountCohesion);
      
        
            averagePosition = (cohesion / flock.Count);
            
            return Seek((averagePosition));
        
    }
    public Vector3 Seperation()
    {
        Vector3 flee = Vector3.zero;
        foreach(GameObject agent in flock)
        {
            if((transform.position - agent.transform.position).magnitude<10f && (transform.position - agent.transform.position).magnitude != 0)
            {
                flee+= Flee(agent.transform.position);
                
            }
            
            
        }
        return flee;
    }
    private void OnRenderObject()
    {
        material1.SetPass(0);
        GL.Begin(GL.LINES);
        GL.Vertex(averagePosition);
        GL.Vertex(direction);
        GL.End();
    }

}
