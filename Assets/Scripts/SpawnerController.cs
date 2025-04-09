using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject lizard;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnLizard", 5, 5);
    }

    void SpawnLizard()
    {
        Instantiate(lizard, transform.position, Quaternion.Euler(0, 180, 0));
    }
    

}
