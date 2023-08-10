using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] float DashSpeed; 
    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new(rb.velocity.x, -rb.velocity.x*3, rb.velocity.z);
        }
    }
}
