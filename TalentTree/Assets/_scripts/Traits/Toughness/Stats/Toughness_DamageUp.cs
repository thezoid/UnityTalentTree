using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toughness_DamageUp : Trait
{
    public float DamageIncreaseMod;
    public override bool Activate()
    {
        //do trait activation
        activated = true;
        //increase damage modifier
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("damage",  DamageIncreaseMod);
                break;
            case 2:
                PlayerPrefs.SetFloat("damage", DamageIncreaseMod * 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("damage",  DamageIncreaseMod * 2.0f);
                break;
        }
        save();
        return true;
    }

    public override bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        //decrease damage modifier
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("damage", DamageIncreaseMod);
                break;
            case 2:
                PlayerPrefs.SetFloat("damage",  DamageIncreaseMod * 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("damage",  DamageIncreaseMod * 2.0f);
                break;
        }
        rank = 0; save();
        return true;
    }
}