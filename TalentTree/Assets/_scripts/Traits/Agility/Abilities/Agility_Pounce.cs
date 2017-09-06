using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;
[System.Serializable]
public class Agility_Pounce : Trait
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
                //enable pounce ability flag
                PlayerPrefs.SetInt("pounceUnlocked", 1);
                PlayerPrefs.SetFloat("pounceCost", PlayerPrefs.GetFloat("pounceBaseCost") * 0.95f);
                PlayerPrefs.SetFloat("pounceDuration", PlayerPrefs.GetFloat("pounceBaseDuration") * 1.25f);
                PlayerPrefs.SetFloat("pounceDamage", PlayerPrefs.GetFloat("pounceBaseDamage") * 1.25f);
                break;
            case 2:
                //enable pounce ability flag
                PlayerPrefs.SetInt("pounceUnlocked", 1);
                PlayerPrefs.SetFloat("pounceCost", PlayerPrefs.GetFloat("pounceBaseCost") * 0.9f);
                PlayerPrefs.SetFloat("pounceDuration", PlayerPrefs.GetFloat("pounceBaseDuration") * 2f);
                PlayerPrefs.SetFloat("pounceDamage", PlayerPrefs.GetFloat("pounceBaseDamage") * 2.5f);
                break;
            case 3:
                //enable pounce ability flag
                PlayerPrefs.SetInt("pounceUnlocked", 1);
                PlayerPrefs.SetFloat("pounceCost", PlayerPrefs.GetFloat("pounceBaseCost") * 0.85f);
                PlayerPrefs.SetFloat("pounceDuration", PlayerPrefs.GetFloat("pounceBaseDuration") * 4f);
                PlayerPrefs.SetFloat("pounceDamage", PlayerPrefs.GetFloat("pounceBaseDamage") * 5f);
                break;
            default:
                break;
        }
        //save();
        return true;
    }

    public override bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        //disable pounce ability flag
        PlayerPrefs.SetInt("pounceUnlocked", 1);
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("pounceCost", PlayerPrefs.GetFloat("pounceBaseCost") / 0.95f);
                PlayerPrefs.SetFloat("pounceDuration", PlayerPrefs.GetFloat("pounceBaseDuration") / 1.25f);
                PlayerPrefs.SetFloat("pounceDamage", PlayerPrefs.GetFloat("pounceBaseDamage") / 1.25f);
                break;
            case 2:
                PlayerPrefs.SetFloat("pounceCost", PlayerPrefs.GetFloat("pounceBaseCost") / 0.9f);
                PlayerPrefs.SetFloat("pounceDuration", PlayerPrefs.GetFloat("pounceBaseDuration") / 2f);
                PlayerPrefs.SetFloat("pounceDamage", PlayerPrefs.GetFloat("pounceBaseDamage") / 2.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("pounceCost", PlayerPrefs.GetFloat("pounceBaseCost") / 0.85f);
                PlayerPrefs.SetFloat("pounceDuration", PlayerPrefs.GetFloat("pounceBaseDuration") / 4f);
                PlayerPrefs.SetFloat("pounceDamage", PlayerPrefs.GetFloat("pounceBaseDamage") / 5f);
                break;
            default:
                break;
        }
        if (rank < 0)
        {
            rank = -1;
        }
        else
        {
            rank = 0;
        }
        //save();
        return true;
    }
}