using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public EnemyContainer targetEnemy;
    public float speed = 0.2f;
    public int dammage;
    public SpriteRenderer spriteRenderer;

    void Update()
    {
        if (targetEnemy == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 targetPosition = targetEnemy.transform.position;
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Oriente la balle vers la cible
        if (direction.sqrMagnitude > 0.0001f)
        {
            transform.up = direction;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);
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