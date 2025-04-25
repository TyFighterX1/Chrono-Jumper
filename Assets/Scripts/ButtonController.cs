using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    [SerializeField] private AudioSource buttonSFX;
    public void ChangeScreen(string sceneName) //lets you change scenes 
    {
       
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() //lets you leave game
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
    

    public void DifficultyModdifier(float diffMod) //modifies enitiy speed, check the inpsector of the three difficulty buttons for more info on their values
    {
        PlayerPrefs.SetFloat("diffMod", diffMod);
        PlayerPrefs.SetInt("Checkpoint", 0); //player shouldnt swap difficulties in the middle of the game
        PlayerPrefs.SetFloat("CurrentTime", 300f); //both are to fully reset the level
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetFloat("diffMod"));
        buttonSFX.Play();
    }

    public void Restart() //lets you restart level fully
    {
        PlayerPrefs.SetInt("Checkpoint", 0);
        PlayerPrefs.SetFloat("CurrentTime", 300f); //resets time
        PlayerPrefs.Save();
        SceneManager.LoadScene("Main Level");
    }
}
