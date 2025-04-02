using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Lose()
    {
        Debug.Log("World Resetting");
        SceneManager.LoadScene("testscene");
    }
    public void OnDeath()
    {
        Invoke("Lose", 2);
    }
}
