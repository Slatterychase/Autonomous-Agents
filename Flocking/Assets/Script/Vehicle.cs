using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Vehicle class
// Placed on a monster object
// Setup for autonomous agents

public abstract class Vehicle : MonoBehaviour 
{

    // Vectors for AA movement
    public Vector3 acceleration;
    public Vector3 direction;
    public Vector3 velocity;
    public Vector3 position;
    public Vector3 targetPosition;

    // Floats for AA
    public float mass;          // Use now
    public float maxSpeed;      // Use now
    public float maxForce;      // User later
    public float radius;		// Use later for collisions

    public bool isSeeking = true;
    public float safeDistance;

    public Terrain terrain;
    // Use this for initialization

    float wanderAngle;
    public Material material1;
    public Material material2;
    public Material material3;
    public bool areLinesActive;
    virtual public void Start()
    {
        terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
        // Get the starting position from the inspector
        position = transform.position;


    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 localPos = gameObject.transform.position;
        localPos.y = terrain.SampleHeight(gameObject.transform.position);
        gameObject.transform.position = localPos;
        CalcSteeringForces();
        UpdatePosition();
        SetTransform();


  

    }

    // void ApplyForce()
    // Applies a force to this vehicle's acceleration
    // Mass affects acceleration
    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    // Seek method
    // Params:  Target's position
    // Returns: Seeking steering force
    // Method calculates and returns the seeking steering force
    public Vector3 Seek(Vector3 targetPosition)
    {
        // Desired velocity = target's pos - my pos
        Vector3 desiredVelocity = targetPosition - position;

        // Scale desired to max speed
        desiredVelocity.Normalize();
        desiredVelocity = desiredVelocity * maxSpeed;

        // Calc steering force = desired - current velocity
        Vector3 seekingForce = desiredVelocity - velocity;

        // Return the steering force to be applied
        return seekingForce;
    }
    public Vector3 Flee(Vector3 targetPosition)
    {
        // Desired velocity = target's pos - my pos
        Vector3 desiredVelocity = targetPosition - position;

        // Scale desired to max speed
        desiredVelocity.Normalize();
        desiredVelocity = desiredVelocity * maxSpeed;
        desiredVelocity = desiredVelocity * -1;
        // Calc steering force = desired - current velocity
        Vector3 seekingForce = desiredVelocity - velocity;

        // Return the steering force to be applied
        return seekingForce;
    }

    abstract public void CalcSteeringForces();

    public void UpdatePosition()
    {
        velocity += acceleration;
        velocity.y = 0;
        position += velocity;
        // position.y = 1;
     
        direction = velocity.normalized;
        acceleration = Vector3.zero;
    }
    public void SetTransform()
    {
        transform.position = position;
        transform.forward = velocity;
    }
    //function to avoid obstacles
    public Vector3 AvoidObstacle(Vector3 positionOb, float rad)
    {
        if (Vector3.Dot(gameObject.transform.forward, positionOb) < 0)
        {
            return Vector3.zero;
        }
        else
        {
            if ((gameObject.transform.position - positionOb).magnitude > safeDistance)
            {
                return Vector3.zero;
            }

            else
            {
                if (Vector3.Dot(gameObject.transform.right, positionOb) > radius + rad)
                {
                    return Vector3.zero;
                }
                else
                {
                    //if greater than 0 go left, less than zero go right
                    if (Vector3.Dot(gameObject.transform.right, positionOb) > 0)
                    {
                        Vector3 desiredVelocity;
                        desiredVelocity = -gameObject.transform.right;
                        desiredVelocity = desiredVelocity.normalized * maxSpeed;
                        return desiredVelocity - velocity;

                    }
                    else
                    {
                        Vector3 desiredVelocity;
                        desiredVelocity = gameObject.transform.right;
                        desiredVelocity = desiredVelocity.normalized * maxSpeed;
                        return desiredVelocity - velocity;
                    }
                }

            }
        }
    }
    //basic wander function
    public Vector3 Wander()
    {
        //creates circle target center
        Vector3 future = transform.position + velocity.normalized + (velocity * 2);
        //chooses random angle from that circle
        Vector3 target = future + (new Vector3(2f, 0, 2f) * Random.Range(-1f, 1f));
        return Seek(target);

    }



}
