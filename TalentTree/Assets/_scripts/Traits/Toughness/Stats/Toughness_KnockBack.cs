using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toughness_KnockBack : Trait
{
    public int KnockBackModifier;
    public override bool Activate()
    {
        //do trait activation
        activated = true;
        //mod player knock back
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("knockback",  KnockBackModifier);
                break;
            case 2:
                PlayerPrefs.SetFloat("knockback",  KnockBackModifier * 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("knockback",  KnockBackModifier * 2.0f);
                break;
        }
        save();
        return true;
    }

    public override bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        //unmod player knock back
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("knockback",  KnockBackModifier);
                break;
            case 2:
                PlayerPrefs.SetFloat("knockback",  KnockBackModifier * 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("knockback",  KnockBackModifier * 2.0f);
                break;
        }
        if (rank < 0)
        {
            rank = -1;
        }
        else
        {
            rank = 0;
        }
        save();
        return true;
    }
}