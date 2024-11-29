using UnityEngine;

public enum PlayerState{
    Ground, // 0: player is in the ground
    Jumped, // 1 : player is jumping but aready performed double jump
    DoubleJump,  // 2: can perform double jump
    Climb // 3: when player interacts with Ladder
}
public class PlayerController : Singleton<PlayerController>
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;          
    public float jumpForce = 10f;         
    public float climbSpeed = 5f;

    [Header("Ground Check")]
    [HideInInspector] public Rigidbody2D rb;              // Reference to the Rigidbody2D component
    // private bool isGrounded = false;     // Tracks if the player is on the ground
    public Animator animator;
    
    
    [HideInInspector] public PlayerState plState = 0; 
    private bool facingRight = true;
    private float horizontalInput;             // Horizontal movement input

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        // Get horizontal input (A/D or Left/Right arrow keys)
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(horizontalInput*moveSpeed*Time.deltaTime, 0, 0));
        //Animation
        if (plState == PlayerState.Jumped || plState == PlayerState.DoubleJump){
            animator.Play("Jump");
        }
        else if(Mathf.Abs(horizontalInput) > 0.1f || plState == PlayerState.Climb){
            animator.Play("Move");
        }
        else{
            animator.Play("Idle");
        }
        // Handle key W
        if (Input.GetKeyDown(KeyCode.W)){
            if(plState == PlayerState.Ground || plState == PlayerState.DoubleJump){
                Jump();
            }
            else if (plState == PlayerState.Climb){
                rb.velocity = new Vector2(rb.velocity.x, climbSpeed);
            }
            else{
                // Stop vertical movement when not pressing W
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }

        // Flip the player sprite based on movement direction
        if (horizontalInput > 0 && !facingRight){Flip();}
        else if (horizontalInput < 0 && facingRight){Flip();}
    }

    private void FixedUpdate()
    {
        // Horizontal movement
        
        // Check if the player is on the ground
        
    }

    private void Jump()
    {
        if (plState == PlayerState.Ground){
            plState = PlayerState.DoubleJump;
        }
        else{
            plState = PlayerState.Jumped;
        }
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    private void Flip()
    {
        facingRight = !facingRight;

        // Flip the character by inverting its X scale
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip the X-axis
        transform.localScale = scale;
    }
    void OnCollisionEnter2D(Collision2D other){
        plState = PlayerState.Ground;
    }
    void OnCollisionExit2D(Collision2D other){
        plState = PlayerState.DoubleJump;
    }
}
