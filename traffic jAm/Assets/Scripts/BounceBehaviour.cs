using UnityEngine;

public class BounceBehaviour : MonoBehaviour
{
    [SerializeField] float Bounciness;
    [SerializeField] float MinBounce;

    private void OnTriggerEnter(Collider smth)
    {
        Rigidbody rb = smth.GetComponent<Rigidbody>();
        rb.velocity = new(rb.velocity.x, Mathf.Max(MinBounce * Bounciness, -rb.velocity.y * Bounciness), rb.velocity.z);
    }


}
