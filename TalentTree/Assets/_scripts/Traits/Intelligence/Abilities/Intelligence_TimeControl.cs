using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;
[System.Serializable]
public class Intelligence_TimeControl : Trait
{

    public override bool Activate()
    {
        //do trait activation
        activated = true;

        //enable time control ability flag
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //since this is an ability, this has a bit more to do per rank
        //each ability has a few things:
        //  the unlock flag
        //  the resource cost
        //  the effect duration
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetInt("timeControlUnlocked", 1);
                PlayerPrefs.SetFloat("timeControlCost",  0.95f);
                PlayerPrefs.SetFloat("timeControlDuration", 1.25f);
                break;
            case 2:
                PlayerPrefs.SetInt("timeControlUnlocked", 1);
                PlayerPrefs.SetFloat("timeControlCost",  0.9f);
                PlayerPrefs.SetFloat("timeControlDuration",  2f);
                break;
            case 3:
                PlayerPrefs.SetInt("timeControlUnlocked", 1);
                PlayerPrefs.SetFloat("timeControlCost",  0.85f);
                PlayerPrefs.SetFloat("timeControlDuration",  4f);
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
        //disable time control ability flag
        PlayerPrefs.SetInt("timeControlUnlocked", 0);
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("timeControlCost",  0.95f);
                PlayerPrefs.SetFloat("timeControlDuration",  1.25f);
                break;
            case 2:
                PlayerPrefs.SetFloat("timeControlCost", 0.9f);
                PlayerPrefs.SetFloat("timeControlDuration",  2f);
                break;
            case 3:
                PlayerPrefs.SetFloat("timeControlCost",  0.85f);
                PlayerPrefs.SetFloat("timeControlDuration", 4f);
                break;
            default:
                break;
        }
        rank = 0;
        //save();
        return true;
    }
}