using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float diffMod; 
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        SetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Lose()
    {
        Debug.Log("World Resetting");
        SceneManager.LoadScene("DeathMenu");
    }
    public void OnDeath()
    {
        Invoke("Lose", 2);
    }
    void SetDifficulty()
    {
        diffMod = PlayerPrefs.GetFloat("diffMod");
        Debug.Log(diffMod);
    }
    public void Win()
    {
        SceneManager.LoadScene("WinScene");
    }
}
