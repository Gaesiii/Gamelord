using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator animator;
    public Vector3 playerMoveDirection;     // Update is called once per frame
    public float playerMaxHealth;
    public float playerHealth;
    void Awake()
    {
            if(Instance != null && Instance != this)
            {
                Destroy(this);
            } else{
                Instance = this;
            }
        
    }

    void Start()
    {
        playerHealth = playerMaxHealth;
        UIController.Instance.UpdatePlayerHealthSlider();
    }
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
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
    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        UIController.Instance.UpdatePlayerHealthSlider();
        if (playerHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
