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
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetFloat("diffMod"));
        buttonSFX.Play();
    }
}
