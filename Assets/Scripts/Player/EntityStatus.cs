using UnityEngine;

public class EntityStatus : MonoBehaviour
{
    private float maxHealth;

    private float currentHealth;

    public float GetEntityHealth()
    {
        return currentHealth;
    }   
}
