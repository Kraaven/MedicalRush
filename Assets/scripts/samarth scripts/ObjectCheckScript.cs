using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectCheckScript : MonoBehaviour
{
    public List<GameObject> basicEquip;
    public List<GameObject> specialEquip;
    public List<GameObject> allEquip;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        allEquip = new List<GameObject>(basicEquip);
        allEquip.AddRange(specialEquip);
        allEquip.Sort((a, b) => a.name.CompareTo(b.name));
    }
}
