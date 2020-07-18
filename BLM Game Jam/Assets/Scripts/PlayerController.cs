using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Player's movement speed
    public float speed;
    // Player's jump force
    public float jumpForce;
    public float fallMultiplier = 3.5f;
    public float lowJumpMultiplier = 3f;
    // Player's Animator
    private Animator animator;
    // Player's Rigidbody2D component
    private Rigidbody2D rb;

    private HealthComponent hp;

    // Check whether player is not in the air
    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    // Game over
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        // Get the player's Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hp = GetComponent<HealthComponent>();
        gameOverPanel.SetActive(false);
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
        Debug.Log("IM DEAD!!!");
        gameOverPanel.SetActive(true);

        // Go back to main menu after death
        Button resetButton = gameOverPanel.transform.GetChild(1).gameObject.GetComponent<Button>();
        resetButton.onClick.AddListener(ResetGame);
    }

    void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    void Move() 
    {
        float x = Input.GetAxisRaw("Horizontal");
        float movement = x * speed;
        rb.velocity = new Vector2(movement, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W))
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
}
