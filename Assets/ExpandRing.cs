using UnityEngine;

public class ExpandRing : MonoBehaviour
{
    public float expansionSpeed = 1.0f;

    private ParticleSystem particleSystem;
    private ParticleSystem.ShapeModule shapeModule;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        shapeModule = particleSystem.shape;
    }

    private void Update()
    {
        // Increase the ring radius over time
        shapeModule.radius += expansionSpeed * Time.deltaTime;
    }
}
