using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject failFX;
    public Transform playerpos;
    public GameManager gm;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField] private Transform onGround;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
