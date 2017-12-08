using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowField : MonoBehaviour {
    public float rows;
    public float columns;
    public Vector3[,] field;
    public int resolution;
    public Terrain terrain;
	// Use this for initialization
	void Start () {
        //gets rows and columns based on terrain locations, and divide by the resolution.
        resolution = 10;
        rows = terrain.terrainData.size.x;
        rows = Mathf.Floor(rows)/resolution + 1;
        columns = terrain.terrainData.size.y;
        columns = Mathf.Floor(columns)/resolution + 1;
       
        field = new Vector3[(int)rows, (int)columns];

        //generates a flow field of randomly generated vectors
        for(int i = 0; i<rows; i++)
        {
            for (int x = 0; x<columns; x++)
            {
                field[i, x] = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Vector3 findLocation(Vector3 find)
    {
        Debug.Log((int)Mathf.Floor(find.x));
        Debug.Log((int)Mathf.Floor(find.z));
        //returns field vector closest to location of the agent following it

        if((int)Mathf.Floor(find.z) < 0 && (int)Mathf.Floor(find.x) < 0)
        {
            return field[((int)Mathf.Floor(find.x) *-1)-1, ((int)Mathf.Floor(find.z) * -1)-1];

        }
        else if ((int)Mathf.Floor(find.z) < 0)
        {
            return field[(int)Mathf.Floor(find.x)-1, ((int)Mathf.Floor(find.z)*-1)-1];
        }
        else if((int)Mathf.Floor(find.x) < 0)
        {
            return field[((int)Mathf.Floor(find.x)*-1)-1, (int)Mathf.Floor(find.z)-1];
        }
        else
        {
            return field[(int)Mathf.Floor(find.x)-1, (int)Mathf.Floor(find.z)-1];
        }
        
    }


}
