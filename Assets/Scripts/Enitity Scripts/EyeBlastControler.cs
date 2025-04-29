using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBlastControler : MonoBehaviour
{
    public float blastSpeed = 7f;
    

    private Rigidbody2D rb;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        direction = Vector2.left; //keeps the blast going the same way
        rb.velocity = blastSpeed * direction;
        Invoke("DestroyBlast", 5); //lets blast fizzle out 
    }
    void DestroyBlast() // destroys blast
    {
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //destroys blast on inpact with walls so it wont go throgh them.
        {
            DestroyBlast();
        }
    }
}
