using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karma_LeechMP : Trait
{
    public float manaLeech; //this needs to be set >0
    public override bool Activate()
    {
        if(manaLeech <= 0)
        {
            Debug.Log("manaLeech is set to zero or lower");
            return false;
        }
        //do trait activation
        activated = true;
        //set mpleech
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("manaLeech", manaLeech);
                break;
            case 2:
                PlayerPrefs.SetFloat("manaLeech", manaLeech*1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("manaLeech", manaLeech*2f);
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
        //remove mpleech
        PlayerPrefs.SetFloat("manaLeech", 0);
        rank = 0;
        save();
        return true;
    }
}