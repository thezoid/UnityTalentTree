﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;
[System.Serializable]
public class Endurance : Trait
{
    public override bool Activate()
    { 
        if (enduranceBonus<= 0)
        {
            Debug.Log("enduranceBonus is set to zero or lower");
            return false;
        }
        //do trait activation
        activated = true;
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        //endurance bonus is declared by our parent class Trait, therefore we will have to modify this on the object the script is attached to
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("endurance", PlayerPrefs.GetFloat("endurance", 1) + enduranceBonus);
                break;
            case 2:
                PlayerPrefs.SetFloat("endurance", PlayerPrefs.GetFloat("endurance", 1) + enduranceBonus*2);
                break;
            case 3:
                PlayerPrefs.SetFloat("endurance", PlayerPrefs.GetFloat("endurance", 1) + enduranceBonus * 3);
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
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("endurance", PlayerPrefs.GetFloat("endurance", 1) - enduranceBonus);
                break;
            case 2:
                PlayerPrefs.SetFloat("endurance", PlayerPrefs.GetFloat("endurance", 1) - enduranceBonus * 2);
                break;
            case 3:
                PlayerPrefs.SetFloat("endurance", PlayerPrefs.GetFloat("endurance", 1) - enduranceBonus * 3);
                break;
            default:
                break;
        }
        rank = 0;
        //save();
        return true;
    }
}