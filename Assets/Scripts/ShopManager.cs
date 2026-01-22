using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopUI;
    public TowerSpawn selectedTowerSpawn;
    public GoldManager goldmanager;


    private void Awake()
    {
        goldmanager = FindFirstObjectByType<GoldManager>();
    }

    public void OpenShop(TowerSpawn towerToSelect)
    {
        shopUI.SetActive(true);
        selectedTowerSpawn = towerToSelect;
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
    }

    public void CreateTower(TowerContainer towerPrefab)
    {
        if(towerPrefab.towerPrice<=goldmanager.currentGold)
        {
            print("coucou");
            var tower = Instantiate(towerPrefab);
            goldmanager.AddGold(-towerPrefab.towerPrice);
            tower.transform.position = selectedTowerSpawn.transform.position;
            Destroy(selectedTowerSpawn.gameObject);
            CloseShop();
        }
    }

}
