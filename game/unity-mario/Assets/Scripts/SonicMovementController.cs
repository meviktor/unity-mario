using UnityEngine;

public class SonicMovementController : MonoBehaviour {

    private Rigidbody2D rigidboy;
    private Animator anim;
    public LayerMask groundLayerMask;
    public Transform groundDetector;
    public float detectorRadius = 0.4f;

    public Transform fallDeathCheck = null;

    public float maxSpeed = 2f;
    public float jumpForce = 2f;

    public static bool facingRight = true;
    private bool jumpIsAllowed = true;

    // Use this for initialization
    void Start()
    {
        rigidboy = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {  
        float moving = Input.GetAxis("Horizontal");
        
        this.rigidboy.velocity =
            new Vector2(moving * maxSpeed, this.rigidboy.velocity.y);

        anim.SetFloat("MovingSpeed", Mathf.Abs(this.rigidboy.velocity.x));

        if (moving != 0f)
            anim.SetBool("IsRunning", true);
        else
            anim.SetBool("IsRunning", false);

        
        if (moving > 0f && !facingRight)
        {
            flip();
        }        
        else if (moving < 0f && facingRight)
        {
            flip();
        }

        if (Input.GetButtonDown("Jump") && jumpIsAllowed)
        {
            rigidboy.velocity = new Vector2(0, jumpForce);
            jumpIsAllowed = false;
            anim.Play("SonicJumpAnimation");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
             anim.SetBool("FacingDown", true);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("FacingUp", true);
        }
 
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("FacingDown", false);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
           anim.SetBool("FacingUp", false);
        }

        if (transform.position.y < fallDeathCheck.transform.position.y)
        {
            GameObject.FindGameObjectWithTag("GameManager").
                GetComponent<RespawnController>().respawn();
        }

        bool grounded =
            Physics2D.OverlapCircle(
                groundDetector.position,
                detectorRadius,
                groundLayerMask);

        anim.SetBool("IsGrounded", grounded);
        if (grounded)
        {
            jumpIsAllowed = true;
        }
    }

    private void flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
