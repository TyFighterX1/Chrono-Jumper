using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LizardController : MonoBehaviour
{
   
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", 60f); // so that the lizard wont be around too long
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + 1 , transform.position.y), Time.deltaTime); // lizard movement
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lava")) // kills lizard when they fall in lava
        {
            Destroy(gameObject);
        }
    }
    private void Die() // kills lizard
    {
        Destroy(gameObject);
    }
}
