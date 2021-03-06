﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;
[System.Serializable]
public class Luck_LeechEnergy : Trait
{
    public float energyLeech;
    public override bool Activate()
    {
        if (energyLeech <= 0)
        {
            Debug.Log("energyLeech is set to zero or lower");
            return false;
        }
        //do trait activation
        activated = true;
        //set leechenergy
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("energyLeech", energyLeech);
                break;
            case 2:
                PlayerPrefs.SetFloat("energyLeech", energyLeech * 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("energyLeech", energyLeech * 2f);
                break;
            default:
                break;
        }
        //save();
        return true;
    }

    public override bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        //remove leechenergy
        PlayerPrefs.SetFloat("energyLeech", 0f);
        rank = 0;
        //save();
        return true;
    }
}