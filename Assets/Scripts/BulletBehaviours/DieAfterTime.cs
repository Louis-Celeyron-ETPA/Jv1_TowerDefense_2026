using System.Collections;
using UnityEngine;

public class DieAfterTime : MonoBehaviour
{
    public int dieTime = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(WaitBeforeDie());
    }

    private IEnumerator WaitBeforeDie()
    {
        yield return new WaitForSeconds(dieTime);
        Destroy(gameObject);
    }
}
