using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject failFX;
    public Transform playerpos;
    public GameManager gm;
    //public CapsuleCollider2D hitBox;
    //public Vector2 standingBox;
    //public Vector2 crouchingBox;
    public Animator anim;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 12f;
    private bool isFacingRight = true;
    
    [SerializeField]private Rigidbody2D rb;
    [SerializeField] private Transform onGround;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        //hitBox = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        //standingBox = hitBox.size;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded()) //checks to see if player is on ground so they can jump
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) //checks to see if the button is held down so that player can jump higher
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        //if(Input.GetKeyDown(KeyCode.S)) // crouching
        //{
        //    hitBox.size = crouchingBox;
        //    anim.SetBool("IsCrouching", true);
        //}

        //if(Input.GetKeyUp(KeyCode.S)) // not crouching
        //{
        //    hitBox.size = standingBox;
        //    anim.SetBool("IsCrouching", false);
        //}

        FlipPlayer();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void FlipPlayer() // flips the sprite to show if the player is moving lwft or right
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal >0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
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
            Die();
        }
        else if (collision.gameObject.CompareTag("Lava"))
        {
            Die();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
        else if (collision.gameObject.CompareTag("EyeBat"))
        {
            Die();
        }
        
    }
}
