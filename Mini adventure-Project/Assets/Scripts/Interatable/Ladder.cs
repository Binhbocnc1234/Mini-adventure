using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float climbSpeed = 5f; // Speed at which the player climbs the ladder
    private bool isPlayerOnLadder = false; // Whether the player is on the ladder
    PlayerController player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            Debug.Log("Player Climb");
            isPlayerOnLadder = true;
            player = collision.GetComponent<PlayerController>();
            player.plState = PlayerState.Climb;
            // Disable gravity so the player doesn't fall off the ladder
            player.rb.gravityScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            Debug.Log("Player leave ladder");
            isPlayerOnLadder = false;
            player.plState = PlayerState.Ground;
            // Restore gravity when the player leaves the ladder
            player.rb.gravityScale = Setting.gravityScale;
        }
    }

    private void Update()
    {
        if (isPlayerOnLadder && player.rb != null)
        {
            // Climb up when the W key is pressed
            if (Input.GetKey(KeyCode.W))
            {
                player.rb.velocity = new Vector2(player.rb.velocity.x, climbSpeed);
            }
            else
            {
                // Stop vertical movement when not pressing W
                player.rb.velocity = new Vector2(player.rb.velocity.x, 0f);
            }
        }
    }
}
