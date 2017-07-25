using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nimbleness_Stealth : Trait
{

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
                //enable player stealth ability flag
                PlayerPrefs.SetInt("stealthUnlocked", 1);
                PlayerPrefs.SetFloat("stealthCost",  0.95f);
                PlayerPrefs.SetFloat("stealthDuration",  1.25f);
                break;
            case 2:
                //enable player stealth ability flag
                PlayerPrefs.SetInt("stealthUnlocked", 1);
                PlayerPrefs.SetFloat("stealthCost",  0.9f);
                PlayerPrefs.SetFloat("stealthDuration",  2f);
                break;
            case 3:
                //enable player stealth ability flag
                PlayerPrefs.SetInt("stealthUnlocked", 1);
                PlayerPrefs.SetFloat("stealthCost",  0.85f);
                PlayerPrefs.SetFloat("stealthDuration",  4f);
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
        //disable player stealth ability flag
        PlayerPrefs.SetInt("stealthUnlocked", 0);
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("stealthCost",  0.95f);
                PlayerPrefs.SetFloat("stealthDuration",  1.25f);
                break;
            case 2:
                PlayerPrefs.SetFloat("stealthCost",  0.9f);
                PlayerPrefs.SetFloat("stealthDuration", 2f);
                break;
            case 3:
                PlayerPrefs.SetFloat("stealthCost",  0.85f);
                PlayerPrefs.SetFloat("stealthDuration",  4f);
                break;
            default:
                break;
        }
        rank = 0;
        save();
        return true;
    }
}