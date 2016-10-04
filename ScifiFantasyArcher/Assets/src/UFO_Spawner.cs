using UnityEngine;
using System.Collections;

public class UFO_Spawner : MonoBehaviour {


    public GameObject ufo_refab;//SET IN EDITOR
    public Transform[] spawn_points;

   GameObject spawned_ufo = null;



    void Start()
    {
        //SpawnUFO();
        StartCoroutine(ufo_spawner_routine());

    }


    IEnumerator ufo_spawner_routine()
    {
        while (true)
        {
            if(spawned_ufo == null && GameController.GetInstance().game_is_running) SpawnUFO();
            yield return new WaitForSeconds(Random.RandomRange(1f, 5f));
           
        }
    }



    public void SpawnUFO()
    {
        spawned_ufo = Instantiate(ufo_refab, spawn_points[Random.RandomRange(0, spawn_points.Length)].position, Quaternion.identity) as GameObject;
    }

}
