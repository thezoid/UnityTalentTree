using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;
[System.Serializable]
public class Agility : Trait
{
    public override bool Activate()
    {
        if (agilityBonus<= 0)
        {
            Debug.Log("agilityBonus is set to zero or lower");
            return false;
        }
        //do trait activation
        activated = true;
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("agility", PlayerPrefs.GetFloat("agility", 1) + agilityBonus);
                break;
            case 2:
                PlayerPrefs.SetFloat("agility", PlayerPrefs.GetFloat("agility", 1) + agilityBonus * 2);
                break;
            case 3:
                PlayerPrefs.SetFloat("agility", PlayerPrefs.GetFloat("agility", 1) + agilityBonus * 3);
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
                PlayerPrefs.SetFloat("agility", PlayerPrefs.GetFloat("agility", 1) - agilityBonus);
                break;
            case 2:
                PlayerPrefs.SetFloat("agility", PlayerPrefs.GetFloat("agility", 1) - agilityBonus * 2);
                break;
            case 3:
                PlayerPrefs.SetFloat("agility", PlayerPrefs.GetFloat("agility", 1) - agilityBonus * 3);
                break;
            default:
                break;
        }
        rank = 0;
        //save();
        return true;
    }
}
