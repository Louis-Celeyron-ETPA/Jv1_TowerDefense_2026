using System.Collections;
using UnityEngine;

public class SpawnNewBulletOnDeath : MonoBehaviour
{
    public BulletBehaviour bulletBehaviour;
    public float waitTime = 1;
    public Shooter newPrefab;
    private void OnDestroy()
    {
        if(bulletBehaviour.targetEnemy != null)
        {
            Shooter newTurret = Instantiate(newPrefab);
            newTurret.transform.position = transform.position;

        }
    }

}
