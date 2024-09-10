using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(CalmPhaseTimer());
    }

    IEnumerator CalmPhaseTimer()
    {
        yield return new WaitForSeconds(5);

        Debug.Log("TIME UP");
    }
}
