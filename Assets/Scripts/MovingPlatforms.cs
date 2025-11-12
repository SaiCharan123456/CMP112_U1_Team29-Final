using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float speed = 2f;

    private Rigidbody rb;
    private Vector3 target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        target = pointB.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector3.Distance(rb.position, target) < 0.05f)
        {
            if (target == pointA.position)
            {
                target = pointB.position;
            }
            else
            {
                target = pointA.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
