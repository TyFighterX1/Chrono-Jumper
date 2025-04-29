using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float diffMod;
    public int checkpointChecker;
    [SerializeField] private AudioSource deathSFX;
    
    // Start is called before the first frame update
    void Start()
    {
        SetDifficulty(); //sets difficulty
        CheckpointSet(); //checks for checkpoint status
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Lose() // when player loses
    {
        Debug.Log("World Resetting");
        SceneManager.LoadScene("DeathMenu");
    }
    public void OnDeath() // delays when screen changes
    {
        deathSFX.Play();
        Invoke("Lose", 2);
    }
    void SetDifficulty() // sets difficulty on load
    {
        diffMod = PlayerPrefs.GetFloat("diffMod"); 
        Debug.Log(diffMod);
    }

    public void CheckpointSet() //sets variable for checkpoints on load
    {
        checkpointChecker = PlayerPrefs.GetInt("Checkpoint");
    }
    public void Win() // sends player to win screen
    {

        SceneManager.LoadScene("WinScene");
    }
}
