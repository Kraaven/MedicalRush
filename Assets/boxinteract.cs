using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxinteract : MonoBehaviour,IInteractable
{
    public ObjectCheckScript oCS;
    public string labelEquip;
    
    public void Interact()
    {
        if (oCS.basicEquip.Contains(gameObject) && labelEquip == "basic")
        {
            print("already in basic inventory");
        }
        else if(labelEquip == "basic")
        {
            oCS.basicEquip.Add(gameObject);
            gameObject.SetActive(false);
        }
        
        if (oCS.basicEquip.Contains(gameObject) && labelEquip == "special")
        {
            print("already in special inventory");
        }
        else if(labelEquip == "special")
        {
            oCS.specialEquip.Add(gameObject);
            gameObject.SetActive(false);
        }
        
        
        
    }
}
