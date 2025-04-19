using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBlastControler : MonoBehaviour
{
    public float blastSpeed = 10f;
    public GameManager gm;

    private Rigidbody2D rb;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.left;
        rb.velocity = blastSpeed * direction;
        Invoke("DestroyBlast", 5 / gm.diffMod);
    }
    void DestroyBlast()
    {
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            DestroyBlast();
        }
    }
}
