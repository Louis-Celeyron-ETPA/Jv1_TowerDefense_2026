using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public List<EnemyContainer> enemiesInRange;
    public EnemyContainer targetEnemy;
    public float shootTime;
    public int dammage;
    public Color bulletColor;
    public BulletBehaviour bulletPrefab;
    public int bulletAmount=1;
    public float waitTimeInOneShoot = 0.08f;
    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        SetTargetEnemy();   
    }
    
    private IEnumerator Shoot()
    {
        while (true)
        {
            while(targetEnemy == null)
            {
                yield return new WaitForEndOfFrame();
            }

            for (int i = 0; i < bulletAmount; i++)
            {
                ShootAction();
                yield return new WaitForSeconds(waitTimeInOneShoot);
                
            }

            yield return new WaitForSeconds(shootTime);
        }
    }

    private void ShootAction()
    {
        var newBullet = Instantiate(bulletPrefab);
     
        newBullet.targetEnemy = targetEnemy;
        newBullet.dammage = dammage;
        newBullet.spriteRenderer.color = bulletColor;
        newBullet.transform.position = transform.position;
        // Vous pouvez changer cette fonction pour changer ce qu'il se passe quand on tire
    }

    private void SetTargetEnemy()
    {
        // Vous pouvez changer cette fonction pour changer l'ennemi a target en priorité
        if(enemiesInRange.Count<=0)
        {
            targetEnemy = null;
        }
        else
        {
            targetEnemy = enemiesInRange[0];
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyContainer collisionEnemyComponent = collision.gameObject.GetComponent<EnemyContainer>();
        if (collisionEnemyComponent != null)
        {
            enemiesInRange.Add(collisionEnemyComponent);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyContainer collisionEnemyComponent = collision.gameObject.GetComponent<EnemyContainer>();
        if (collisionEnemyComponent != null)
        {
            enemiesInRange.Remove(collisionEnemyComponent);
        }
    }
}
