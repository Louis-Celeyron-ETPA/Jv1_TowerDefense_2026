using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    public GameObject towerPrefab;
    private void OnMouseDown()
    {
        var tower = Instantiate(towerPrefab);
        tower.transform.position = transform.position + new Vector3(0.5f, 0.5f, 0f);
        Destroy(gameObject);
    }
}