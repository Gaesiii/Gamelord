using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator animator;
    public Vector3 playerMoveDirection;     // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        playerMoveDirection = new Vector3(inputX , inputY).normalized;
        animator.SetFloat("moveX",inputX);
        animator.SetFloat("moveY",inputY);
        if (playerMoveDirection == Vector3.zero)
        {
            animator.SetBool("moving",false);
        }
        else
        {
            animator.SetBool("moving",true);
        }
    }
    void FixedUpdate()
    {
         rb.linearVelocity = new Vector2(playerMoveDirection.x * moveSpeed, playerMoveDirection.y * moveSpeed   );
    }
}
