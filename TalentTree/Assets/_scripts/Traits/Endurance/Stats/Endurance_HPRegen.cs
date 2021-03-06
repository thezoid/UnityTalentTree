﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;
[System.Serializable]
public class Endurance_HPRegen : Trait
{
    public float healthRegen;
    public override bool Activate()
    {
        if (healthRegen <= 0)
        {
            Debug.Log("healthRegen is set to zero or lower");
            return false;
        }
        //do trait activation
        activated = true;
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //healthRegen must be initialized in the code or on the object
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("healthRegen", 0.001f*healthRegen);
                break;
            case 2:
                PlayerPrefs.SetFloat("healthRegen", 0.003f*healthRegen);
                break;
            case 3:
                PlayerPrefs.SetFloat("healthRegen", 0.005f*healthRegen);
                break;
            default:
                PlayerPrefs.SetFloat("healthRegen", 0f);
                break;
        }
        //save();
        return true;
    }

    public override bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        PlayerPrefs.SetFloat("healthRegen", 0f);
        rank = 0;
        //save();
        return true;
    }
}