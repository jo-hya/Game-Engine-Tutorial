using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 0.3f;   // Height of visual jump
    public float jumpDuration = 0.3f; // Duration of jump animation

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 moveInput;

    private bool isJumping = false;
    private Vector3 originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        rb.gravityScale = 0;          // No gravity in top-down
        rb.freezeRotation = true;     // Prevent rotation
    }

    void Update()
    {
        // Movement input
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // Update Animator parameters
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetBool("isWalking", moveInput != Vector2.zero);

        // Jump input (visual only, no physics jump)
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartCoroutine(TopDownJump());
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    // Simple coroutine for top-down jump effect
    private System.Collections.IEnumerator TopDownJump()
    {
        isJumping = true;

        float timer = 0f;
        Vector3 originalPosition = transform.localScale;

        while (timer < jumpDuration)
        {
            float height = Mathf.Sin(Mathf.PI * (timer / jumpDuration)) * jumpHeight;
            transform.localScale = new Vector3(1f + height, 1f + height, 1f);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.one; // Reset to original scale
        isJumping = false;
    }
}
