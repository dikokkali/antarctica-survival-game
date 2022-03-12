using UnityEngine;

public class EntityStatus : MonoBehaviour
{   
    #region Status Variables

    public float CurrentHealth { get; private set; }
    public float CurrentStamina { get; private set; }

    public float MaxHealth { get; private set; }    
    public float MaxStamina { get; private set; }

    private float _staminaLossPerSecond;
    private float _staminaGainPerSecond;

    #endregion

    private void Awake()
    {
        
    }

    private void Start()
    {
        CurrentHealth = MaxHealth; 
    }

    private void Update()
    {
        // TODO: Figure out how to know if running cleanly - events for start/stop running?

        ReplenishStamina(_staminaGainPerSecond);
    }

    #region Health Methods

    private void CalculateDamage(float damage)
    {
        CurrentHealth = CurrentHealth - damage;

        if (CurrentHealth <= 0)
        {
            Debug.Log("Player died.");
            
            // Kill player
        }

        CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);
    }

    #endregion

    #region Stamina Methods

    private void DrainStamina()
    {
        if (CurrentStamina <= 0f) return;

        CurrentStamina = CurrentStamina - _staminaLossPerSecond;
        CurrentStamina = Mathf.Clamp(CurrentStamina, 0f, MaxStamina);
    }

    private void ReplenishStamina(float amount)
    {
        if (CurrentStamina >= MaxStamina) return;

        CurrentStamina = CurrentStamina + amount * Time.deltaTime; // Per second calculation
        CurrentStamina = Mathf.Clamp(CurrentStamina, 0f, MaxStamina);
    }

    #endregion
}
