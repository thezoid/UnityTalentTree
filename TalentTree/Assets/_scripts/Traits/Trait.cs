using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class Trait : MonoBehaviour {
    [Header("Player Stats")]
    /* This is where you will show all your stats
     * It's important to set it up here in the abstract class in order to provide proper inheritance to the other
     * My game this is derrived from was based on a cat player character, hence the acronym KITTEN being the stats
     */
    public float karmaBonus; //Luck, effects drop rate, positive luck lowers the floor on the difficulty, negitive luck raises the celing.
    public float intelligenceBonus; //Magic Damage, MP Pool, and resistance ot magic damage.
    public float toughnessBonus; //Strength, 
    public float tactBonus; //Agility, Attack Recovery rate
    public float enduranceBonus; //Stamina, Max Health
    public float nimblenessBonus; //dex, Movespeed 

    [Header("In Game Stats")]
    /* This section allows you to add health and mana bonuses to a trait
     */
    public float HealthBonus; //increase to current Health (Might want to avoid making this negative)
    public float MPBonus; //Magic Power bonus
    
    [Header("Trait Vars")]
    /* This section contains the variables relative to the trait itself, rather than bonuses to the player
     * Set these equal to your default values for a generic trait
     */
    public string traitName = "Generic trait default name";
    public string traitDescription = "Generic trait default description";
    public bool activated = false;
    public int rank = 0;
    public int maxRanks = 1;
    public int cost = 0;

    private void Awake()
    {
        load(); //load the trait when the scene starts
    }

    //this function adds a rank to the trait and then saves its stats to playerprefs
    public void addRank()
    {
        rank++;
        save();
    }

    //save the current status of the trait to player prefs
    public void save()
    {
        PlayerPrefs.SetInt(name + "Status", (activated ? 1 : 0));
        PlayerPrefs.SetInt(name + "Rank", rank);
    }

    //load the trait's status from playerprefs
    public void load()
    {
        activated = (PlayerPrefs.GetInt(name + "Status", 0) != 0);
        rank = PlayerPrefs.GetInt(name + "Rank", 0);
    }

    public virtual bool Activate()
    {
        //do trait activation
        activated = true;
        save();
        return true; //this value will be used for debug
    }

    public virtual bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        rank = 0;
        save();
        return true; //this value will be used for debug
    }
}
