using UnityEngine;

public class TEMP_BallRoller : MonoBehaviour
{
    public float force = 20.0f;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movementX ,0, movementY) * force;

        rb.AddForce(movement);
    }
}
