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
        rows = Mathf.Floor(rows)/resolution;
        columns = terrain.terrainData.size.y;
        columns = Mathf.Floor(columns)/resolution;
       
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
        //returns field vector closest to location of the agent following it
        return field[(int)Mathf.Floor(find.x),(int) Mathf.Floor(find.z)];
    }


}
