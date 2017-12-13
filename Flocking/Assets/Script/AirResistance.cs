using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirResistance : MonoBehaviour {
    public float c = .1f;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Vector3 checkDrag(Vector3 velocity)
    {
        float speed = velocity.magnitude;
        float dragMagnitude = c * speed * speed;
        Vector3 drag = velocity;
        drag = drag * -1;
        drag = drag.normalized;
        drag = drag * dragMagnitude;
        return drag;


    }
}
