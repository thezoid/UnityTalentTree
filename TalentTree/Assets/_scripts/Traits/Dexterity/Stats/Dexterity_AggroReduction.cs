using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;
[System.Serializable]
public class Dexterity_AggroReduction : Trait
{
    public float AggroReducMod;
    public override bool Activate()
    {
        if (AggroReducMod<= 0)
        {
            Debug.Log("AggroReducMod is set to zero or lower");
            return false;
        }
        //do trait activation
        activated = true;
        //modify enemy aggro range
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("aggroRange",  AggroReducMod * 0.95f);
                break;
            case 2:
                PlayerPrefs.SetFloat("aggroRange",  AggroReducMod * 0.9f);
                break;
            case 3:
                PlayerPrefs.SetFloat("aggroRange", AggroReducMod * 0.85f);
                break;
        }
        //save();
        return true;
    }

    public override bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        //modify enemy aggro range
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("aggroRange",  (AggroReducMod * 0.95f));
                break;
            case 2:
                PlayerPrefs.SetFloat("aggroRange",  (AggroReducMod * 0.9f));
                break;
            case 3:
                PlayerPrefs.SetFloat("aggroRange",  (AggroReducMod * 0.85f));
                break;
        }
        if (rank < 0) {
            rank = -1;
        }
        else {
            rank = 0;
        }
        //save();
        return true;
    }
}