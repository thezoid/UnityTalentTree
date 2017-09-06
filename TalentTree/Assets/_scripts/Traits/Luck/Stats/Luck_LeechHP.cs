using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;
[System.Serializable]
public class Luck_LeechHP : Trait
{
    public float healthLeech;
    public override bool Activate()
    {
        if (healthLeech <= 0)
        {
            Debug.Log("healthLeech is set to zero or lower");
            return false;
        }
        //do trait activation
        activated = true;
        //set leechhp
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("healthLeech", healthLeech);
                break;
            case 2:
                PlayerPrefs.SetFloat("healthLeech", healthLeech * 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("healthLeech", healthLeech * 2f);
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
        //remove leechhp
        PlayerPrefs.SetFloat("healthLeech", 0f);
        rank = 0;
        //save();
        return true;
    }
}