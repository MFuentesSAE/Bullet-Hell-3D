using UnityEngine;

public class PoolManager : MonoBehaviour
{
	public GameObjectPool playerBulletPool, enemyPool, enemyBulletPool;

	public static PoolManager instance;

	private void Awake()
	{
		instance = this;
	}
}
