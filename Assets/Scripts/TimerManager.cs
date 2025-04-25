using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public PlayerController pc;
    public float remainingTime;
    [SerializeField] TextMeshProUGUI timerText;
    private bool playerDead = false;

    void Start()
    {
        remainingTime = PlayerPrefs.GetFloat("CurrentTime");
    }
    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
            remainingTime -= Time.deltaTime;
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            if (playerDead == false) //checks to kill the player and if it is true the player is already dead and this should not call.
            {
                PlayerPrefs.SetFloat("CurrentTime", 300f); // resets time
                PlayerPrefs.SetInt("Checkpoint", 0); //resets checkpoint
                PlayerPrefs.Save();
                pc.Die();
                playerDead = true;
            }
        }
            
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int second = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, second);
    }
}
