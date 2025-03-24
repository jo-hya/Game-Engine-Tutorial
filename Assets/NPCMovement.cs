using UnityEngine;

public class NPCPathMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    private int currentWaypointIndex = 0;
    private Animator animator;
    private Vector2 moveInput;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (waypoints.Length > 0)
        {
            MoveToWaypoint();
        }

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
    }

    void MoveToWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }
}
