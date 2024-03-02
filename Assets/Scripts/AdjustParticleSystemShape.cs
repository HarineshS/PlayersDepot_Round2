using UnityEngine;

public class AdjustParticleSystemShape : MonoBehaviour
{
    new ParticleSystem particleSystem; // Rename the variable to avoid hiding the inherited member

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();

        // Calculate the screen dimensions in world space
        float screenHeight = Camera.main.orthographicSize * 2.0f;
        float screenWidth = screenHeight * Camera.main.aspect;

        // Set particle system shape to match the screen size
        ParticleSystem.ShapeModule shapeModule = particleSystem.shape;
        shapeModule.shapeType = ParticleSystemShapeType.Rectangle;
        shapeModule.scale = new Vector3(screenWidth, screenHeight, 1f);
    }
}
