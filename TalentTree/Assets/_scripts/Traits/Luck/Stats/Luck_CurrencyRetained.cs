using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;
[System.Serializable]
public class Luck_CurrencyRetained : Trait
{
    public float currencyRetainedRatio;
    public override bool Activate()
    {
        if (currencyRetainedRatio < 0)
        {
            Debug.Log("currencyRetaineRation is set to lower than zero");
            return false;
        }
        //do trait activation
        activated = true;
        //set currency retention ratio
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("currencyRetained",currencyRetainedRatio);
                break;
            case 2:
                PlayerPrefs.SetFloat("currencyRetained", currencyRetainedRatio * 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("currencyRetained", currencyRetainedRatio *2f);
                break;
        }
        //save();
        return true;
    }

    public override bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        //reduce currency retention
        PlayerPrefs.SetFloat("currencyRetained", 0f);
        rank = 0;
        //save();
        return true;
    }
}