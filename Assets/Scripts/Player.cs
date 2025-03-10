using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private Animator animator;  // Animator reference

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();  // Get the Animator component attached to this GameObject
    }

    private void FixedUpdate()
    {
        // Get raw input values
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Update animator parameters based on input:
        // - 'isWalking' is true if either x or y is non-zero, otherwise false.
        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Vertical", y);
        animator.SetBool("isWalking", (x != 0 || y != 0));

        // Reset moveDelta based on input
        moveDelta = new Vector3(x, y, 0);

        
        // Check vertical movement using a BoxCast and move if possible
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y),
                                  Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // Check horizontal movement using a BoxCast and move if possible
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0),
                                  Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
