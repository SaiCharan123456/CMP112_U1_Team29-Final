using UnityEngine;
using UnityEngine.InputSystem.Composites;

public class ObstacleLogic : PlayerController
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle")) //couldn't get this to work as a regular collision, instead there is a tag around a box collider, simulating a hitbox.
        {
            GameManager.Health -= 1;
            hurtSource.PlayOneShot(damageSound);
            Debug.Log("Player collided with an obstacle!");
            Debug.Log(GameManager.Health);
            playerVelocity *= -0.9f; //reverses the player's motion to move them out the way of the obstacle
        }
    }
}
