using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endurance_HPUP : Trait
{
    public float hpup;
    public override bool Activate()
    {
        if (hpup<= 0)
        {
            Debug.Log("hpup is set to zero or lower");
            return false;
        }
        //do trait activation
        activated = true;
        //increase players hp
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //hpup needs to be set to a value in the editor or above
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("maxHealth",  hpup);
                break;
            case 2:
                PlayerPrefs.SetFloat("maxHealth",  hpup*1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("maxHealth",  hpup*2f);
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
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("maxHealth",  hpup);
                break;
            case 2:
                PlayerPrefs.SetFloat("maxHealth",  hpup * 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("maxHealth",  hpup * 2f);
                break;
            default:
                break;
        }
        rank = 0;
        save();
        return true;
    }
}
