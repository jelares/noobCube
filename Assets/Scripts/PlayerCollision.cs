using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement movement;

    private void OnCollisionEnter(Collision collisionInfo)
    {

        Debug.Log(collisionInfo.collider.name);

        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
        }
    }

}
