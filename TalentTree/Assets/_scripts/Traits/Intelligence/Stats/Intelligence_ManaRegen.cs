using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intelligence_ManaRegen : Trait
{
    public float manaRegenUp;
    public override bool Activate()
    {
        //do trait activation
        activated = true;
        //increase mana regen
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank) {
            case 1:
                PlayerPrefs.SetFloat("manaRegen", 0.001f * manaRegenUp);
                break;
            case 2:
                PlayerPrefs.SetFloat("manaRegen", 0.003f * manaRegenUp);
                break;
            case 3:
                PlayerPrefs.SetFloat("manaRegen", 0.005f * manaRegenUp);
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
        //decrease mana regen
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("manaRegen", manaRegenUp/0.001f);
                break;
            case 2:
                PlayerPrefs.SetFloat("manaRegen", manaRegenUp / 0.003f );
                break;
            case 3:
                PlayerPrefs.SetFloat("manaRegen", manaRegenUp / 0.005f);
                break;
            default:
                break;
        }
        rank = 0;
        save();
        return true;
    }
}