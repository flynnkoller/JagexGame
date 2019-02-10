using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFinder : MonoBehaviour {

    [SerializeField]
    List<Light> lightsIn = new List<Light>();
    [SerializeField]
    Light _currentLight;

    SceneLights sceneLights;

    private void Start()
    {
        //Might be a more effiecent way to do this so look back here later
        sceneLights = GameObject.Find("LightManager").GetComponent<SceneLights>();
    }

    // Update is called once per frame
    void Update ()
    {
        //Do this in a manager somewhere
        FindClosest();
	}

    public Light CurrentLight
    {
        get { return _currentLight; }
        set { _currentLight = value; }
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

        for (int i = 0; i < sceneLights.Lights.Count; i++)
        {
            //If the distance is less than the players range find the most intense light if there are more sources
            if(Distance(transform, sceneLights.Lights[i].transform) <= sceneLights.Lights[i].range)
            {
                lightsIn.Add(sceneLights.Lights[i]);
            }
        }

        if(lightsIn.Count > 1)
        {
            for (int i = 1; i < lightsIn.Count; i++)
            {
                //Default with the first light
                _currentLight = lightsIn[0];

                //Pick the most intense light
                if (lightsIn[i].intensity > lightsIn[i - 1].intensity)
                {
                    _currentLight = lightsIn[i];
                }
            }
        } else if (lightsIn.Count == 1)
        {
            _currentLight = lightsIn[0];
        }
        else
        {
            _currentLight = null;
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
