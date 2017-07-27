using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intelligence_ManaUp : Trait
{
    public float manaUp;
    public override bool Activate()
    {
        if (manaUp <= 0f)
        {
            Debug.Log("manaUp is set to zero or lower");
            return false;
        }
        //do trait activation
        activated = true;
        //increase player mana
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //mana up must be initialized to a value above on on the object the script is attached to
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("maxMana", PlayerPrefs.GetFloat("maxMana") + manaUp);
                break;
            case 2:
                PlayerPrefs.SetFloat("maxMana", PlayerPrefs.GetFloat("maxMana") + manaUp * 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("maxMana", PlayerPrefs.GetFloat("maxMana") + manaUp * 2f);
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
        //add another case per additional 
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("maxMana", PlayerPrefs.GetFloat("maxMana") - manaUp);
                break;
            case 2:
                PlayerPrefs.SetFloat("maxMana", PlayerPrefs.GetFloat("maxMana") - manaUp / 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("maxMana", PlayerPrefs.GetFloat("maxMana") - manaUp / 2f);
                break;
            default:
                break;
        }
        rank = 0;
        save();
        return true;
    }
}