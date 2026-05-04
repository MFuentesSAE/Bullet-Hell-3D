using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 30f;
    private float currentHealth;

    private void Awake()
    {
        Revive();
	}

    public void Revive() //Usar esta función cuando el enemigo sale del pool para que reinicie su hp
    {
		currentHealth = maxHealth;
	}

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
            //Destroy(gameObject);
            gameObject.SetActive(false);
    }
}
