using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirResistance : MonoBehaviour {
    public float c = .001f;
    public Vector3 drag;
    public Material material1;
    public bool isActive;
    
	// Use this for initialization
	void Start () {
        isActive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isActive = !isActive;
        }
	}
    public Vector3 checkDrag(Vector3 velocity)
    {
        float speed = velocity.magnitude;
        Debug.Log(speed);
        float dragMagnitude = c * speed * speed;
        drag = velocity;
        drag = drag * -1;
        drag = drag.normalized;
        drag = drag * dragMagnitude;
        Debug.Log(drag);
        return drag;


    }

    private void OnRenderObject()
    {
        if (isActive)
        {
            material1.SetPass(0);
            GL.Begin(GL.LINES);
            GL.Vertex(transform.position);
            GL.Vertex((transform.position + drag) * 7f);
            GL.End();

        }
      
    }
}
