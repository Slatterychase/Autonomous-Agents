using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowField : MonoBehaviour {
    public float rows;
    public float columns;
    public Vector3[,] field;
    public int resolution;
    public Terrain terrain;
    public bool areLinesActive;
    public Material material1;
    public Material material2;
    public float randomAngle;
    public Vector3 randomDirection;
	// Use this for initialization
	void Start () {
        //gets rows and columns based on terrain locations, and divide by the resolution.
        areLinesActive = true;
        resolution = 10;
        rows = (int)terrain.terrainData.size.x;
        rows = rows/resolution;
        columns = (int)terrain.terrainData.size.z;
        columns =columns/resolution;
       
        field = new Vector3[(int)rows, (int)columns];

        //generates a flow field of randomly generated vectors
        randomizeFlowFIeld();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            randomizeFlowFIeld();
        }
	}
    public Vector3 findLocation(Vector3 find)
    {
        //Debug.Log((int)Mathf.Floor(find.x));
        //Debug.Log((int)Mathf.Floor(find.z));
        //returns field vector closest to location of the agent following it
          if ((int)find.x >= 50 && (int)find.z >= 60 || (int)find.x * -1 >= 50 && (int)find.z * -1 >= 60)
        {
            return field[49, 59];
        }
        else if ((int)find.x >= 50 || (int)find.x * -1 >= 50)
        {
            return field[49, Random.Range(0, 59)];
        }
        else if ((int)find.x >= 60 || (int)find.x * -1 >= 60)
        {
            return field[Random.Range(0, 49), 59];
        }
        else if ((int)find.z < 0 && (int)find.x < 0)
        {
            Debug.Log((int)find.z * -1);
            Debug.Log((int)find.x*-1);
            return field[((int)find.x *-1), ((int)find.z * -1)];

        }
        else if ((int)find.z < 0)
        {
            return field[(int)find.x, ((int)find.z*-1)];
        }
        else if((int)find.x < 0)
        {
            return field[((int)find.x*-1), (int)find.z];
        }
      
        else
        {
            return field[(int)find.x, (int)find.z];
        }
        
    }
    public void randomizeFlowFIeld()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int x = 0; x < columns; x++)
            {
                randomAngle = Random.Range(0f, 360f);
                randomDirection = Quaternion.Euler(0, randomAngle, 0) * Vector3.right;
                field[i, x] = randomDirection;
                //field[i, x] = new Vector3(1, 0, 0);
            }
        }
    }

    private void OnRenderObject()
    {
       
        //writes lines to show vectors
        if (areLinesActive)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int x = 0; x < columns; x++)
                {
                    Vector3 posBox = Vector3.zero;
                    posBox.x = i * resolution + (resolution / 2);
                    posBox.z = x * resolution + (resolution / 2);
                    posBox.y = 15;
                    material1.SetPass(0);
                    GL.Begin(GL.LINES);
                    GL.Vertex(posBox);
                    GL.Vertex(posBox + (field[i, x].normalized * 5f));
                    GL.End();
                }
            }
          

          
        }

    }


}
