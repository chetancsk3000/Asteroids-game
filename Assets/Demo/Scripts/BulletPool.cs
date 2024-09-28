using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// The BulletPool class manages a pool of bullets to optimize game performance by reducing the need for
/// frequent instantiation and destruction of bullet objects.
/// </summary>
public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize = 20;
    private List<GameObject> bulletPool;

    void Start()
    {
        // Initialize the bullet pool
        bulletPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public void SpawnBullet(Vector2 position, Vector2 direction)
    {
        GameObject bullet = GetPooledBullet();
        if (bullet != null)
        {
            bullet.transform.position = position;
            bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
            bullet.SetActive(true);
            bullet.GetComponent<Bullet>().CallDestroy();
        }
    }

    private GameObject GetPooledBullet()
    {
        foreach (var bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null; // All bullets are currently in use
    }
}
