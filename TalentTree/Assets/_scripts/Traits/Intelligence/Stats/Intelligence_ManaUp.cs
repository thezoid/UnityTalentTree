using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intelligence_ManaUp : Trait
{
    public float manaUp;
    public override bool Activate()
    {
        //do trait activation
        activated = true;
        //increase player mana
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("maxMana", manaUp);
                break;
            case 2:
                PlayerPrefs.SetFloat("maxMana", manaUp * 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("maxMana",  manaUp * 2f);
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
        //decrease player mana
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("maxMana", manaUp);
                break;
            case 2:
                PlayerPrefs.SetFloat("maxMana", manaUp * 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("maxMana", manaUp * 2f);
                break;
            default:
                break;
        }
        rank = 0;
        save();
        return true;
    }
}