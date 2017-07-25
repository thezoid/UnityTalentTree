using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nimbleness : Trait
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
                PlayerPrefs.SetFloat("nimbleness", PlayerPrefs.GetFloat("nimbleness", 1) + nimblenessBonus);
                break;
            case 2:
                PlayerPrefs.SetFloat("nimbleness", PlayerPrefs.GetFloat("nimbleness", 1) + nimblenessBonus * 2);
                break;
            case 3:
                PlayerPrefs.SetFloat("nimbleness", PlayerPrefs.GetFloat("nimbleness", 1) + nimblenessBonus * 3);
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
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("nimbleness", PlayerPrefs.GetFloat("nimbleness", 1) - nimblenessBonus);
                break;
            case 2:
                PlayerPrefs.SetFloat("nimbleness", PlayerPrefs.GetFloat("nimbleness", 1) - nimblenessBonus * 2);
                break;
            case 3:
                PlayerPrefs.SetFloat("nimbleness", PlayerPrefs.GetFloat("nimbleness", 1) - nimblenessBonus * 3);
                break;
            default:
                break;
        }
        rank = 0; save();
        return true;
    }
}
