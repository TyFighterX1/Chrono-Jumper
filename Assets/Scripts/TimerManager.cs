using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public PlayerController pc;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private bool playerDead = false;

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
                pc.Die();
                playerDead = true;
            }
        }
            
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int second = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, second);
    }
}
