using TMPro;
using UnityEngine;

public class ShopButtonBridge : MonoBehaviour
{
    public ShopManager shopManager;
    public TowerContainer towerToSpawn;
    public TextMeshProUGUI priceText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopManager = FindFirstObjectByType<ShopManager>();
    }

    public void Update()
    {
        priceText.text= towerToSpawn.towerPrice.ToString("00") + "$";
    }

    public void CallTowerBuy()
    {
        shopManager.CreateTower(towerToSpawn);
    }

}
