using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    EnemyBehavior enemyBehavior;
    public GameObject hitFX;
    public bool isBullet;
    public int health;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<EnemyBehavior>() != null)
        {
            enemyBehavior = other.gameObject.GetComponent<EnemyBehavior>();
            if (isBullet)
            {
                Instantiate(hitFX, this.transform.position, Quaternion.identity);
            }
            Debug.Log("Hit block");
            enemyBehavior.HitDelay();
        }
        if (isBullet)
        {
            --health;
            if(health <= 0) 
            {
                DestroySelf();
            }
            
        }
    }

    private void DestroySelf()
    {
        // Instead put bullet in pool to be used later.
        Destroy(gameObject);
    }
}
