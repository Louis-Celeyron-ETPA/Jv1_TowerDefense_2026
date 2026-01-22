using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class EnemyContainer : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer;
    public SplineAnimate mySplineAnimate;
    public HpManager myHpManager;

    public int timeToPath;
    public int HpMax;

    // Start is called before the first frame update
    void Awake()
    {
        myHpManager.maxHP = HpMax;
        mySplineAnimate.Container = FindFirstObjectByType<SplineContainer>();
        mySplineAnimate.Duration = timeToPath + Random.Range(-3,3);
        mySplineAnimate.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
