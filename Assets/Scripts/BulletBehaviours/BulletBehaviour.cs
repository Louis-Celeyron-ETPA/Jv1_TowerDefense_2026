using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public EnemyContainer targetEnemy;
    public int dammage;
    public SpriteRenderer spriteRenderer;
    public float speed = 0.2f;

    void Update()
    {
     

        // A la fin pour ne pas essayer d'utiliser un objt detruit
        if (targetEnemy == null)
        {
               Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyContainer collisionEnemyComponent = collision.gameObject.GetComponent<EnemyContainer>();

        if (collisionEnemyComponent != null)
        {

            collisionEnemyComponent.myHpManager.RemoveHp(dammage);
            Destroy(gameObject);
        }
    }
}
