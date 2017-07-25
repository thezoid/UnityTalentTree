using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intelligence_Shield : Trait
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
                PlayerPrefs.SetInt("shieldUnlocked", 1);
                PlayerPrefs.SetFloat("shieldCost",  0.95f);
                PlayerPrefs.SetFloat("shieldDuration",  1.25f);
                break;
            case 2:
                PlayerPrefs.SetInt("shieldUnlocked", 1);
                PlayerPrefs.SetFloat("shieldCost",  0.9f);
                PlayerPrefs.SetFloat("shieldDuration",  2f);
                break;
            case 3:
                PlayerPrefs.SetInt("shieldUnlocked", 1);
                PlayerPrefs.SetFloat("shieldCost",  0.85f);
                PlayerPrefs.SetFloat("shieldDuration", 4f);
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
        //disable time control ability flag
        PlayerPrefs.SetInt("shieldUnlocked", 0);
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("shieldCost", 0.95f);
                PlayerPrefs.SetFloat("shieldDuration",  1.25f);
                break;
            case 2:
                PlayerPrefs.SetFloat("shieldCost",  0.9f);
                PlayerPrefs.SetFloat("shieldDuration", 2f);
                break;
            case 3:
                PlayerPrefs.SetFloat("shieldCost",  0.85f);
                PlayerPrefs.SetFloat("shieldDuration",  4f);
                break;
            default:
                break;
        }
        rank = 0;
        save();
        return true;
    }
}