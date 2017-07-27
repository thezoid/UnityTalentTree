using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endurance_DamageReduction : Trait
{
    public float damageReducMod;
    public override bool Activate()
    {
        if (damageReducMod <= 0)
        {
            Debug.Log("damageReducMod is set to zero or lower");
            return false;
        }
        //do trait activation
        activated = true;
        //mod player damage reduc
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //damageReduceMod must be modified above or on the game object
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("damageReduction", damageReducMod);
                break;
            case 2:
                PlayerPrefs.SetFloat("damageReduction",  damageReducMod*1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("damageReduction",  damageReducMod * 2f);
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
        //unmod player damage reduc
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("damageReduction", damageReducMod);
                break;
            case 2:
                PlayerPrefs.SetFloat("damageReduction",  damageReducMod * 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("damageReduction", damageReducMod * 2f);
                break;
            default:
                break;
        }
        rank = 0;
        save();
        return true;
    }
}