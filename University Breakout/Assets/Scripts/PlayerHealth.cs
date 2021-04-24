using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    HealthBar healthBar;

    void Start()
    {
        healthBar = GetComponent<HealthBar>();
        healthBar.SetMaxHealth(hitPoints);
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        healthBar.SetHealth(hitPoints);

        if (hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
