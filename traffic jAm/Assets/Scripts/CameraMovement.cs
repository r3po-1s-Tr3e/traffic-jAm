using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Rigidbody playerBody;
    Rigidbody cameraRb;
    private void Start()
    {
        cameraRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (player.position.x > 0)
        {
            cameraRb.velocity = new Vector3(playerBody.velocity.x, playerBody.velocity.y / 1.8f, -playerBody.velocity.y / 4.5f);
            
        }
    }
}
