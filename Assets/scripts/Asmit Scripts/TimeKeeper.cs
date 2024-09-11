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
        Equiped.Sort((a, b) => a.name.CompareTo(b.name));
    }

    IEnumerator CalmPhaseTimer()
    {
        yield return new WaitForSeconds(5);
        if (Ocs.allEquip.SequenceEqual(Equiped))
        {
            Debug.Log("collected all equipment");
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("TIME UP");
        }
        
    }
}
