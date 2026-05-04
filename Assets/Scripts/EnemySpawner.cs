using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObjectPool enemyPool;
    [SerializeField] private GameObjectPool enemyBulletPool;
    [SerializeField] private float spawnInterval = 3f;

    private void Start()
    {
        if(enemyPool == null)
        {
            return;
        }

        SpawnEnemy();
        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval);
    }

    private void SpawnEnemy()
    {
        GameObject enemy = enemyPool.GetGameObjectFromPool(transform.position);

        //Una vez que se tiene al enemygo del pool, revivirlo
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        enemyHealth?.Revive();
    }
}
