using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Player's movement speed
    public float speed;
    // Player's jump force
    public float jumpForce;
    public float fallMultiplier = 3.5f;
    public float lowJumpMultiplier = 3f;

    private Animator animator;
    private Rigidbody2D rb;
    private TextMeshProUGUI prologueText;

    private HealthComponent hp;

    // Check whether player is not in the air
    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public GameManager manager;
    public string[] prologueLines;
    private int lineNum;
    public float prologueTime = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hp = GetComponent<HealthComponent>();
        prologueText = GetComponentInChildren<TextMeshProUGUI>();
        lineNum = 0;
        prologueText.text = "";
        InvokeRepeating("DisplayPrologue", 0, prologueTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckIfGrounded();
        Jump();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectibles")) 
        {
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Obstacle")) 
        {
            hp.Damage();
        }
    }

    void OnBecameInvisible()
    {
        Die();
    }

    public void Die()
    {
        manager.GameOver();
    }

    void Move() 
    {
        float x = Input.GetAxisRaw("Horizontal");
        float movement = x * speed;
        rb.velocity = new Vector2(movement, rb.velocity.y);

        animator.SetFloat("speed", Mathf.Abs(movement));
        
        // Flip sprite
        if (rb.velocity.x < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;
    }

    void Jump()
    {
        if (Input.GetAxisRaw("Vertical") > 0 && isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        else if (rb.velocity.y > 0 && Input.GetAxisRaw("Vertical") <= 0)
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
    }

    void CheckIfGrounded()
    {
        Collider2D col = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (col != null)
        {
            isGrounded = true;
            animator.SetBool("isGround", true);
        }
        else
        {
            isGrounded = false;
            animator.SetBool("isGround", false);
        }
    }

    void DisplayPrologue()
    {
        if (lineNum < prologueLines.Length)
        {
            prologueText.text = prologueLines[lineNum];
            lineNum++;
        }
        else
        {
            prologueText.text = "";
        }
    }
}
