using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBatController : MonoBehaviour
{
    public GameObject eyeBlast;
    public Transform blastPos;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EyeBlast", 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void EyeBlast() // lets the pet fire a projectile
    {
        Instantiate(eyeBlast, blastPos.position, Quaternion.Euler(0, 180, 0));
        Debug.Log("shots fired");
        
    }
}
