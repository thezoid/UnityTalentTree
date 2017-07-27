using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karma_CurrencyGain : Trait
{
    public float currencyGainRatio;
    public override bool Activate()
    {
        if (currencyGainRatio<= 0)
        {
            Debug.Log("currencyGainRatio is set to zero or lower");
            return false;
        }
        //do trait activation
        activated = true;
        //increase player currency gain
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("currencyGained", currencyGainRatio);
                break;
            case 2:
                PlayerPrefs.SetFloat("currencyGained", currencyGainRatio * 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("currencyGained", currencyGainRatio * 2f);
                break;
        }
        save();
        return true;
    }

    public override bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        //decrease player currency gain
        PlayerPrefs.SetFloat("currencyGained", 1f);
        rank = 0;
        save();
        return true;
    }
}