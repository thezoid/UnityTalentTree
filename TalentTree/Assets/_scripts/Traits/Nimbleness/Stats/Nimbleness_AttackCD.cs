using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nimbleness_AttackCD : Trait
{
    public float AttackCDMod;
    public override bool Activate()
    {
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
                PlayerPrefs.SetFloat("attackCD", AttackCDMod);
                break;
            case 2:
                PlayerPrefs.SetFloat("attackCD", AttackCDMod * .95f);
                break;
            case 3:
                PlayerPrefs.SetFloat("attackCD", AttackCDMod * .90f);
                break;
        }
        save();
        return true;
    }

    public override bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        //add subtractcdmod
        PlayerPrefs.SetFloat("attackCD", 1f);
        rank = 0;
        save();
        return true;
    }
}