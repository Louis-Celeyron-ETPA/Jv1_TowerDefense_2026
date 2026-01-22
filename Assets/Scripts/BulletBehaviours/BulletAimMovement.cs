using UnityEngine;

public class BulletAimMovement : MonoBehaviour
{

    public BulletBehaviour myBulletBehaviour;
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, 
            myBulletBehaviour.targetEnemy.transform.position, 
            myBulletBehaviour.speed);

    }
}
