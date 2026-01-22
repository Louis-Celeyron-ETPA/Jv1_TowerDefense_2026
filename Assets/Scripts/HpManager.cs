using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour
{

    public int currentHP;
    public int maxHP;
    public int goldToWin;
    public GoldManager goldManager;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void RemoveHp(int pvPerdu)
    {
        currentHP -= pvPerdu;
        if(currentHP <= 0)
        {
            Die();
        }
    }
    

    public void Die()
    {
        goldManager.AddGold(goldToWin);
        Destroy(gameObject);
    }
}
