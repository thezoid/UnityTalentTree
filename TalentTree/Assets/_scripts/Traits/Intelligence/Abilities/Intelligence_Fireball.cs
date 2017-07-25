using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intelligence_Fireball : Trait
{

    public override bool Activate()
    {
        //do trait activation
        activated = true;
        //enable fireball ability flag
        PlayerPrefs.SetInt("fireballUnlocked", 1);
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {

            case 1:
                PlayerPrefs.SetFloat("fireballCost",  0.95f);
                PlayerPrefs.SetFloat("fireballDuration",  1.25f);
                PlayerPrefs.SetFloat("fireballDamage", 1.25f);
                break;
            case 2:
                PlayerPrefs.SetFloat("fireballCost",  0.9f);
                PlayerPrefs.SetFloat("fireballDuration", 2f);
                PlayerPrefs.SetFloat("fireballDamage",  2.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("fireballCost",  0.85f);
                PlayerPrefs.SetFloat("fireballDuration",  4f);
                PlayerPrefs.SetFloat("fireballDamage", 5f);
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
        //disable fireball ability flag
        PlayerPrefs.SetInt("fireballUnlocked", 0);
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("fireballCost", 0.95f);
                PlayerPrefs.SetFloat("fireballDuration",  1.25f);
                PlayerPrefs.SetFloat("fireballDamage",  1.25f);
                break;
            case 2:
                PlayerPrefs.SetFloat("fireballCost",  0.9f);
                PlayerPrefs.SetFloat("fireballDuration",  2f);
                PlayerPrefs.SetFloat("fireballDamage", 2.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("fireballCost",  0.85f);
                PlayerPrefs.SetFloat("fireballDuration",  4f);
                PlayerPrefs.SetFloat("fireballDamage", 5f);
                break;
            default:
                break;
        }
        rank = 0;
        save();
        return true;
    }
}