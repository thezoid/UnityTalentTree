using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;
[System.Serializable]
public class Luck_Crit : Trait
{
    public float critMod;
    public override bool Activate()
    {
        if (critMod <= 0)
        {
            Debug.Log("critMod is set to zero or lower");
            return false;
        }
        //do trait activation
        activated = true;
        //increase player crit chance
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("critChance", critMod);
                break;
            case 2:
                PlayerPrefs.SetFloat("critChance", critMod*1.05f);
                break;
            case 3:
                PlayerPrefs.SetFloat("critChance", critMod*1.15f);
                break;
        }
        //save();
        return true;
    }

    public override bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        //decrease player crit chance
        PlayerPrefs.SetFloat("critChance", 1f);
        rank = 0;
        //save();
        return true;
    }
}