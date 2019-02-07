using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFinder : MonoBehaviour {

    //Might have to store all of the lights in the scene at the start so that we can always find the closest one
    //This list should be made avaliable in a seperate class so that all characters in the scene can use it instead of running once per character
    [SerializeField]
    List<Light> lights = new List<Light>();
    [SerializeField]
    List<Light> lightsIn = new List<Light>();
    [SerializeField]
    Light currentLight;

	// Use this for initialization
	void Start ()
    {
        //Find all lights in the scene, only run once as is an expensive function
        foreach(Light l in FindObjectsOfType(typeof(Light)))
        {
            lights.Add(l);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Do this in a manager somewhere
        FindClosest();
	}

    void FindClosest()
    {
        //Run throought the list and the closest light is chosen 
        //When chosen run a ray that updates the distance / range
        //Get the intesity of the light

        //OR WE CAN ONLY USE THE INTESITY TO MAKE THINGS EASIER/PLAY BETTER

        //If leave the closest light source then look for the new closest???

        //Maybe do constant checks of only the lights in a range of the player and get their intensities
        //So that's 2 lists one of the whole scene and one of whats close to us
        //This is especially good in the case of lights overlapping
        //Also works best if the range is kept consistant of light sources so the check range is always that

        lightsIn.Clear();

        for (int i = 0; i < lights.Count; i++)
        {
            //If the distance is less than the players range find the most intense light if there are more sources
            if(Distance(transform, lights[i].transform) <= lights[i].range)
            {
                lightsIn.Add(lights[i]);

                Debug.Log(Distance(transform, lights[i].transform));
                Debug.Log(lights[i]);
            }
        }

        if(lightsIn.Count > 1)
        {
            for (int i = 1; i < lightsIn.Count; i++)
            {
                //Default with the first light
                currentLight = lightsIn[0];

                //Pick the most intense light
                if (lightsIn[i].intensity > lightsIn[i - 1].intensity)
                {
                    currentLight = lightsIn[i];
                }
            }
        } else if (lightsIn.Count == 1)
        {
            currentLight = lightsIn[0];
        }
        else
        {
            currentLight = null;
        }

    }

    //Should probably move this to a public function access somewhere as it'll be used more
    float Distance(Transform start, Transform end)
    {
        var x = Mathf.Pow((start.position.x - end.position.x), 2);
        var y = Mathf.Pow((start.position.y- end.position.y), 2);
        var z = Mathf.Pow((start.position.z - end.position.z), 2);

        var c = Mathf.Sqrt(x + y + z);
        return c;
    }
}
