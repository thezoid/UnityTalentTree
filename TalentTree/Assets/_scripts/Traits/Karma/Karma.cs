using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karma : Trait
{
    public override bool Activate()
    {
        if (karmaBonus<= 0)
        {
            Debug.Log("karmaBonus is set to zero or lower");
            return false;
        }
        //do trait activation
        activated = true;
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        //karmaBonus needs to be be set on the object the script is attached to
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("karma", PlayerPrefs.GetFloat("karma", 1) + karmaBonus);
                break;
            case 2:
                PlayerPrefs.SetFloat("karma", PlayerPrefs.GetFloat("karma", 1) + karmaBonus * 2);
                break;
            case 3:
                PlayerPrefs.SetFloat("karma", PlayerPrefs.GetFloat("karma", 1) + karmaBonus * 3);
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
                PlayerPrefs.SetFloat("karma", PlayerPrefs.GetFloat("karma", 1) - karmaBonus);
                break;
            case 2:
                PlayerPrefs.SetFloat("karma", PlayerPrefs.GetFloat("karma", 1) - karmaBonus * 2);
                break;
            case 3:
                PlayerPrefs.SetFloat("karma", PlayerPrefs.GetFloat("karma", 1) - karmaBonus * 3);
                break;
            default:
                break;
        }
        rank = 0;
        save();
        return true;
    }
}
