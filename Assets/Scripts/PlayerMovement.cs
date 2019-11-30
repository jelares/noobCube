using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public PlayerMovement movement;
    public GameObject trail;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float backwardsForce = 0f;
    public float jumpForce = 15f;
    public float forwardJump = 15f;
    public float epsilon = .1f;
    public float jumpWait = 1; 

    public bool invincible = false;
    public bool canjump = true;

  
    //  Check for collision in the movement script:
    private void OnCollisionEnter(Collision collisionInfo)
    {

        // Debug.Log(collisionInfo.collider.name);

        if (collisionInfo.collider.tag == "Obstacle" && !invincible)
        {
            movement.enabled = false;
            FindObjectOfType<gameManager>().EndGame();
        }

    }

    // Make the jump impossible
    void changeJumpState()
    {
        canjump = false;
    } 


    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            if (rb.velocity.z - backwardsForce >= 0)
            {
                rb.AddForce(0, 0, -backwardsForce * Time.deltaTime, ForceMode.VelocityChange);
            }
            else
            {
                // Debug.Log("0z");
                rb.AddForce(0, 0, -rb.velocity.z, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (invincible && (.25 - epsilon <= rb.position.y) && (rb.position.y <= .25 + epsilon))
        {
            invincible = false;
            trail.SetActive(false);
        }

        if (Input.GetKey("space") && (.25 - epsilon <= rb.position.y) && (rb.position.y <= .25 + epsilon) && (canjump))
        {
            invincible = true;
            trail.SetActive(true);
            rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
            rb.AddForce(0, 0, forwardJump, ForceMode.VelocityChange);
            Invoke("changeJumpState", jumpWait);
        }
        
        if (rb.position.y <= -1)
        {
            FindObjectOfType<gameManager>().EndGame();
        }
    }
}
