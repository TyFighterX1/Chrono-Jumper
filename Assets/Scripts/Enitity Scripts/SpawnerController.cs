using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameManager gm;
    public GameObject lizard;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnLizard", 5 / gm.diffMod, 5 / gm.diffMod);
    }

    void SpawnLizard()
    {
        Instantiate(lizard, transform.position, Quaternion.Euler(0, 180, 0));
    }
    

}
