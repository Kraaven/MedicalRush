using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxinteract : MonoBehaviour,IInteractable
{
    public ObjectCheckScript oCS;
    public string labelEquip;
    
    public bool pickedScalpel;
    public bool pickedForceps;
    public bool pickedSuturing;
    public bool pickedShockCollar;
    public bool pickedLaser;

    public void Interact()
    {
        if (oCS.basicEquip.Contains(gameObject) && labelEquip == "basic")
        {
            print("already in basic inventory");
        }
        else if(labelEquip == "basic")
        {
            if(gameObject.name == "Scalpel")
            {
                pickedScalpel = true;
                Debug.Log("PICKED UP Scalpel");
            }
            else if(gameObject.name == "Forceps")
            {
                pickedForceps = true;
                Debug.Log("PICKED UP Forceps");
            }
            else if(gameObject.name == "Suturing Device")
            {
                pickedSuturing = true;
                Debug.Log("PICKED UP Suturing Device");
            }

            oCS.basicEquip.Add(gameObject);
            gameObject.SetActive(false);
        }
        
        if (oCS.basicEquip.Contains(gameObject) && labelEquip == "special")
        {
            print("already in special inventory");
        }
        else if(labelEquip == "special")
        {

            if(gameObject.name == "Lazer")
            {
                pickedLaser = true;
                Debug.Log("PICKED UP LAZER");
            }
            else if(gameObject.name == "Shock Collar")
            {
                pickedShockCollar = true;
                Debug.Log("PICKED UP Shock Collar");
            }

            oCS.specialEquip.Add(gameObject);
            gameObject.SetActive(false);
        }
        
        
        
    }
}
