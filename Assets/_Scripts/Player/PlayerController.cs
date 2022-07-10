using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    [Header("Ground check settings")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private Vector3 leftRayPosition;
    [SerializeField] private Vector3 rightRayPosition;

    private Vector2 direction;

    public Vector2 Direction => direction;
    public bool IsGrounded { get; private set; }

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        CheckIsGrounded();
        DrawRaycastLines();
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.zero;
        }
    }
    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            rb.AddForce(direction * movementSpeed);
        }
    }
    private void OnBecameInvisible()
    {
        SetOppositePosition();
    }
    private void SetOppositePosition()
    {
        transform.position = new Vector3(-transform.position.x, transform.position.y);
    }
    private bool CheckIsGrounded()
    {
        IsGrounded = Physics2D.Raycast(transform.position + leftRayPosition, transform.up, groundCheckDistance, groundLayerMask)
            || Physics2D.Raycast(transform.position + rightRayPosition, transform.up, groundCheckDistance, groundLayerMask);
        return IsGrounded;
    }
    private void DrawRaycastLines()
    {
        Debug.Log(CheckIsGrounded());
        Debug.DrawRay(transform.position + leftRayPosition, transform.up * groundCheckDistance, Color.red);
        Debug.DrawRay(transform.position + rightRayPosition, transform.up * groundCheckDistance, Color.red);
    }
}
