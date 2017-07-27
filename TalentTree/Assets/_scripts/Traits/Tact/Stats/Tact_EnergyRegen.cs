using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tact_EnergyRegen : Trait
{
    public float EnergyRegenMod;
    public override bool Activate()
    {
        if (EnergyRegenMod<= 0)
        {
            Debug.Log("EnergyRegenMod is set to zero or lower");
            return false;
        }
        //do trait activation
        activated = true;
        //mod player energy regen
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("energyRegen1", 0.2f * EnergyRegenMod);
                break;
            case 2:
                PlayerPrefs.SetFloat("energyRegen1", 0.5f * EnergyRegenMod);
                break;
            case 3:
                PlayerPrefs.SetFloat("energyRegen1", 1f * EnergyRegenMod);
                break;
            default:
                break;
        }
        save();
        return true;
    }

    public override bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        //unmod player energy regen
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("energyRegen1", EnergyRegenMod/0.1f );
                break;
            case 2:
                PlayerPrefs.SetFloat("energyRegen1", EnergyRegenMod/0.3f);
                break;
            case 3:
                PlayerPrefs.SetFloat("energyRegen1", EnergyRegenMod/0.5f);
                break;
            default:
                break;
        }
        rank = 0; save();
        return true;
    }
}