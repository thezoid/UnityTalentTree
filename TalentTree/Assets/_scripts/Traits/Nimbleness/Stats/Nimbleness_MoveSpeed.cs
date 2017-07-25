using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nimbleness_MoveSpeed : Trait
{
    public float MoveSpeedModifier;
    public override bool Activate()
    {
        //do trait activation
        activated = true;
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        //add movespeed modifier
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("moveSpeed", Mathf.Clamp( MoveSpeedModifier, 1f, 2.5f));
                break;
            case 2:
                PlayerPrefs.SetFloat("moveSpeed", Mathf.Clamp( MoveSpeedModifier * 1.05f, 1f, 2.5f));
                break;
            case 3:
                PlayerPrefs.SetFloat("moveSpeed", Mathf.Clamp( MoveSpeedModifier * 1.15f, 1f, 2.5f));
                break;
        }
        save();
        return true;
    }

    public override bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        //subtract movespeed modifier
        PlayerPrefs.SetFloat("moveSpeed", 1f);
        rank = 0;
        save();
        return true;
    }
}