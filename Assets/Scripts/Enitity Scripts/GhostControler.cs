using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class GhostControler : MonoBehaviour
{
    private int direction = -1;
    public GameManager gm;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, transform.position.y -4 * direction * gm.diffMod), Time.deltaTime); // moves ghost
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //lets ghost change direction when hitting the floor or ceiling
        {
            direction = direction * -1;
            
        }
    }
}
