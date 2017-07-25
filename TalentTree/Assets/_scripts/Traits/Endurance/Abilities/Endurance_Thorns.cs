using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endurance_Thorns : Trait
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
                //enable thorns ability flag
                PlayerPrefs.SetInt("thornsUnlocked", 1);
                PlayerPrefs.SetFloat("thornsCost", 0.95f);
                PlayerPrefs.SetFloat("thornsDuration", 25f);
                PlayerPrefs.SetFloat("thornsDamage",1.25f);
                break;
            case 2:
                //enable thorns ability flag
                PlayerPrefs.SetInt("thornsUnlocked", 1);
                PlayerPrefs.SetFloat("thornsCost",  0.9f);
                PlayerPrefs.SetFloat("thornsDuration", 4f);
                PlayerPrefs.SetFloat("thornsDamage",  2.5f);
                break;
            case 3:
                //enable thorns ability flag
                PlayerPrefs.SetInt("thornsUnlocked", 1);
                PlayerPrefs.SetFloat("thornsCost",  0.85f);
                PlayerPrefs.SetFloat("thornsDuration", 6f);
                PlayerPrefs.SetFloat("thornsDamage",  5f);
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

        //disable thorns ability flag
        PlayerPrefs.SetInt("thornsUnlocked", 0);
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("thornsCost",  0.95f);
                PlayerPrefs.SetFloat("thornsDuration",  1.25f);
                PlayerPrefs.SetFloat("thornsDamage", 1.25f);
                break;
            case 2:
                PlayerPrefs.SetFloat("thornsCost", 0.9f);
                PlayerPrefs.SetFloat("thornsDuration",2f);
                PlayerPrefs.SetFloat("thornsDamage", 2.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("thornsCost", PlayerPrefs.GetFloat("thornsBaseCost") / 0.85f);
                PlayerPrefs.SetFloat("thornsDuration", PlayerPrefs.GetFloat("thornsBaseDuration") / 4f);
                PlayerPrefs.SetFloat("thornsDamage", PlayerPrefs.GetFloat("thornsBaseDamage") / 5f);
                break;
            default:
                break;
        }
        rank = 0;
        save();
        return true;
    }
}