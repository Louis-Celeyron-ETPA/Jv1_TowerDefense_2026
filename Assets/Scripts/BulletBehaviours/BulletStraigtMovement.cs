using UnityEngine;

public class BulletStraigtMovement : MonoBehaviour
{
    public BulletBehaviour mbb;
    public Vector3 targetDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(mbb.targetEnemy != null)
        {
            targetDirection = (mbb.targetEnemy.transform.position-transform.position);
        }
    }

    private void Update()
    {
        transform.position += targetDirection * mbb.speed;
    }
}
