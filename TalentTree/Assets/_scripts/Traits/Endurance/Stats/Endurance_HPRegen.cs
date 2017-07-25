using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endurance_HPRegen : Trait
{
    public float healthRegen;
    public override bool Activate()
    {
        //do trait activation
        activated = true;
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
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
        save();
        return true;
    }

    public override bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        PlayerPrefs.SetFloat("healthRegen", 0f);
        rank = 0;
        save();
        return true;
    }
}