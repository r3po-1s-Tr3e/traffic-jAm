using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyHead")
        {
            other.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
