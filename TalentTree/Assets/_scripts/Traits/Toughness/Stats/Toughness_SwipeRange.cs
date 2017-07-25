using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toughness_SwipeRange : Trait
{
    public float swipeRangeMod;
    public override bool Activate()
    {
        //do trait activation
        activated = true;
        //mod player swipe range
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("swipeRange",  swipeRangeMod);
                break;
            case 2:
                PlayerPrefs.SetFloat("swipeRange",  swipeRangeMod * 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("swipeRange", swipeRangeMod * 2f);
                break;
        }
        save();//after modifying the stats, save our traits status
        return true;
    }

    public override bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        //unmod player swipe range
        //this switch will be based off the current rank of the trait
        //it can easily be expanded by increasing the max rank of the trait
        //add another case per additional rank
        //if it can't find the stat, it will default to 1
        switch (rank)
        {
            case 1:
                PlayerPrefs.SetFloat("swipeRange", PlayerPrefs.GetFloat("baseSwipeRange", .5f) - swipeRangeMod);
                break;
            case 2:
                PlayerPrefs.SetFloat("swipeRange", PlayerPrefs.GetFloat("baseSwipeRange", .5f) - swipeRangeMod * 1.5f);
                break;
            case 3:
                PlayerPrefs.SetFloat("swipeRange", PlayerPrefs.GetFloat("baseSwipeRange", .5f) - swipeRangeMod * 2f);
                break;
        }
        rank = 0; //reset the rank to 0
        save();//after modifying the stats, save our traits status
        return true;
    }
}