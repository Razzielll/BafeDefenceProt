
using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 2f;
    [SerializeField] float maxHealth = 20;
    float currentHealth = 0;
    bool isDead = false;
    public event Action OnDie;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ReplenishHealth()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(GameObject instigator, float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        
        
        
        OnDie?.Invoke();
        if (!this.gameObject.CompareTag("Player"))
        {
            isDead = true;
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<Animator>().SetBool("Dead", true);
            Destroy(gameObject, timeToDestroy);
        }
        
    }

    public bool IsDead()
    {
        return isDead;
    }
}
