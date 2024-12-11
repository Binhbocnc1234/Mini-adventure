using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Entity entity; // Public variable to attach the entity
    public Transform realHealthBar; // The red health bar
    
    void Update()
    {
        if (entity != null && realHealthBar != null)
        {
            // Update the health bar's scale based on the entity's health percentage
            float healthPercentage = entity.health/entity.fullHealth;
            realHealthBar.localScale = new Vector3(healthPercentage, 1f, 1f);
        }
    }
}
