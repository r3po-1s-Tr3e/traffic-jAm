using UnityEngine;

public class CollectibleInteraction : MonoBehaviour
{
    int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            other.gameObject.SetActive(false);
            count++;
        }
    }
}
