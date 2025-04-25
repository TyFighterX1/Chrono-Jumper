using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject failFX;
    public Transform playerpos;
    public GameManager gm;
    public TimerManager tm;
    public Animator anim;

    
    private float speed = 8f;
    private float jumpingPower = 12f;
    
    
    
    
    [SerializeField]private Rigidbody2D rb;
    [SerializeField] private Transform onGround;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioSource jumpSFX;
    [SerializeField] private AudioSource checkpointSFX;

    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        Debug.Log(gm.checkpointChecker);
        if (gm.checkpointChecker == 1)
        {
            transform.position = new Vector2(174f,-8f);//sends player to checkpoint
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (Input.GetButtonDown("Jump") && IsGrounded()) //checks to see if player is on ground so they can jump
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpSFX.Play();
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) //checks to see if the button is held down so that player can jump higher
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

       

        
    }
    private void FixedUpdate()
    {
        
            rb.velocity = new Vector2( 1 * speed *gm.diffMod, rb.velocity.y); //auto-run
        
            
    }

   
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(onGround.position, 0.2f, groundLayer);
    }
    public void Die()  //for whenever the player loses
    {
        gm.OnDeath();
        Instantiate(failFX, playerpos.position, Quaternion.Euler(0, 180, 0));
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            PlayerPrefs.SetFloat("CurrentTime", tm.remainingTime);
            Die();
        }
        else if (collision.gameObject.CompareTag("Lava"))
        {
            PlayerPrefs.SetFloat("CurrentTime", tm.remainingTime);
            Die();
        }
        else if (collision.gameObject.CompareTag("Ghost"))
        {
            PlayerPrefs.SetFloat("CurrentTime", tm.remainingTime);
            Die();
        }
        else if (collision.gameObject.CompareTag("Checkpoint"))
        {
            PlayerPrefs.SetInt("Checkpoint", 1); //enables checkpoint
            PlayerPrefs.Save();
            checkpointSFX.Play();
            Debug.Log("Checkpoint Hit");
        }
        else if (collision.gameObject.CompareTag("Ending"))
        {
            PlayerPrefs.SetInt("Checkpoint", 0); //resets checkpoint
            PlayerPrefs.SetFloat("CurrentTime", 300f); //resets time
            PlayerPrefs.Save();
            gm.Win();
            Debug.Log("Win hit");
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerPrefs.SetFloat("CurrentTime", tm.remainingTime);
            Die();
        }
        else if (collision.gameObject.CompareTag("EyeBat"))
        {
            PlayerPrefs.SetFloat("CurrentTime", tm.remainingTime);
            Die();
        }
        

    }
}
