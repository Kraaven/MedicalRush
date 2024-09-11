using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeKeeper : MonoBehaviour
{
    public ObjectCheckScript Ocs;
    public List<GameObject> Equiped;
    private void Start()
    {
        StartCoroutine(CalmPhaseTimer());
    }

    IEnumerator CalmPhaseTimer()
    {
        yield return new WaitForSeconds(5);
        if (Ocs.allEquip.SequenceEqual(Equiped))
        {
            Debug.Log("collected all equipment");
        }
        else
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("TIME UP");
        }
        
    }
}
