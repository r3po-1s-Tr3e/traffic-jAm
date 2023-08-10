using System.Collections;
using UnityEngine;

public class Launch : MonoBehaviour
{
    [SerializeField] ParticleSystem Explosion = null;
    [SerializeField] ParticleSystem Smoke = null;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Explode();
            Smoky();
        }
    }

    public void Explode()
    {
        Explosion.Play();
    }
    public void Smoky()
    {
        Smoke.Play();
    }
}