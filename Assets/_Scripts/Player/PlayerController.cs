using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Camera mainCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        EventManager.EnterGameplay += EventManager_EnterGameplay;
    }

    private void EventManager_EnterGameplay()
    {
        if (!gameObject.activeInHierarchy) { gameObject.SetActive(true); }
    }

    private void Update()
    {
        if (!gameObject.activeInHierarchy) { return; }

        CheckIsGrounded();
        DrawRaycastLines();
        SetDirection();

        EventManager.OnUpdatePlayerPosition(transform.position);
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
        if (mainCamera == null) { return; }

        Vector3 positionInCameraView = mainCamera.WorldToViewportPoint(transform.position);

        if (positionInCameraView.y < 0f)
        {
            EventManager.OnPlayerDied();
            gameObject.SetActive(false);
        }
        else
        {
            SetOppositePosition();
        }
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
        Debug.DrawRay(transform.position + leftRayPosition, transform.up * groundCheckDistance, Color.red);
        Debug.DrawRay(transform.position + rightRayPosition, transform.up * groundCheckDistance, Color.red);
    }
    private void SetDirection()
    {
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
}
