using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;

    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        // Entrada de pulo - teclado ou toque
        bool jumpPressed = Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);
        bool jumpHeld = Input.GetButton("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary);
        bool jumpReleased = Input.GetButtonUp("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended);

        #region Jumping
        if (isGrounded && jumpPressed)
        {
            isJumping = true;
            AudioManager.instance.PlaySFX(AudioManager.instance.jump);
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        if (isJumping && jumpHeld)
        {
            if (jumpTimer < jumpTime)
            {
                rb.linearVelocity = Vector2.up * jumpForce;
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (jumpReleased)
        {
            isJumping = false;
            jumpTimer = 0;
        }
        #endregion
    }
}
