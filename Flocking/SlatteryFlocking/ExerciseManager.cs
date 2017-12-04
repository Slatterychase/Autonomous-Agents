using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExerciseManager : MonoBehaviour {
    public GameObject birb;
    public GameObject obj;
    public GameObject target;
 
    public List<GameObject> humans = new List<GameObject>();
    public List<GameObject> obstacles = new List<GameObject>();
    public List<GameObject> flock = new List<GameObject>();
    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < 10; i++)
        {
            flock.Add(Instantiate(birb));
            float randomX = Random.Range(150, 400);
            float randomY = Random.Range(150, 400);
            Vector3 terrain = new Vector3(randomX, 0, randomY);
            //creates a vector 3 for the objects based on the terrain mapping
            Vector3 change = new Vector3(randomX, Terrain.activeTerrain.SampleHeight(terrain) +5f, randomY);
            flock[i].transform.position = change;

        }
        for(int i = 0; i<30; i++)
        {
         obstacles.Add(Instantiate(obj));
            float randomX = Random.Range(150, 400);
            float randomY = Random.Range(150, 400);
            Vector3 terrain = new Vector3(randomX, 0, randomY);
            //creates a vector 3 for the objects based on the terrain mapping
            Vector3 change = new Vector3(randomX, Terrain.activeTerrain.SampleHeight(terrain) + 5f, randomY);
            obstacles[i].transform.position = change;
        }
        target = Instantiate(target);
        float random1 = Random.Range(150, 400);
        float random2 = Random.Range(150, 400);
        Vector3 terrains = new Vector3(random1, 0, random2);
        //creates a vector 3 for the objects based on the terrain mapping
        Vector3 changes = new Vector3(random1, Terrain.activeTerrain.SampleHeight(terrains) + 5f, random2);
        target.transform.position = changes;



    }
	
	// Update is called once per frame

	void Update ()
    {
		 foreach(GameObject flc in flock)
        {
            if((flc.transform.position-target.transform.position).magnitude < 3f)
            {
                float random1 = Random.Range(150, 400);
                float random2 = Random.Range(150, 400);
                Vector3 terrains = new Vector3(random1, 0, random2);
                //creates a vector 3 for the objects based on the terrain mapping
                Vector3 changes = new Vector3(random1, Terrain.activeTerrain.SampleHeight(terrains) + 5f, random2);
                target.transform.position = changes;
            }
        }
	}
}
