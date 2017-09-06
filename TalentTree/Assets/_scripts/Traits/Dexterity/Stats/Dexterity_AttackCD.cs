using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;
[System.Serializable]
public class Dexterity_AttackCD : Trait
{
    public float attackCDMod;
    public override bool Activate()
    {
        if (attackCDMod <= 0)
        {
            Debug.Log("attackCDModis set to zero or lower");
            return false;
        }
        //do trait activation
        activated = true;
        //subtract attackcdmod
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("attackCD", attackCDMod);
                break;
            case 2:
                PlayerPrefs.SetFloat("attackCD", attackCDMod * .95f);
                break;
            case 3:
                PlayerPrefs.SetFloat("attackCD", attackCDMod * .90f);
                break;
        }
        //save();
        return true;
    }

    public override bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        //reset attackCD to 1
        PlayerPrefs.SetFloat("attackCD", 1f);
        rank = 0;
        // save();
        return true;
    }
}