using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class Trait : MonoBehaviour
{
    [Header("Player Stats")]
    /* This is where you will show all your stats
     * It's important to set it up here in the abstract class in order to provide proper inheritance to the other
     */
    public float luckBonus; //effects drop rate, enemy spawn, etc.
    public float intelligenceBonus; //Magic Damage, MP Pool, and resistance to magic damage
    public float strengthBonus; //attack damage, knockback, etc. 
    public float agilityBonus; //attack speed, etc.
    public float enduranceBonus; //stamina, Max Health
    public float dexterityBonus; //dex, Movespeed 

    public CharacterStats characterStats;

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
    public int cost = 1; //the current cost of the trait
    public int totalCost; //this will change as we buy the trait more, increasing by a floored scale factor defined below
    public int baseCost; //this will be set to the initial price so we can reset the price on a reset command
    public float costScale = 2.0f;
    [Header("Required Trait")]
    public Trait requiredTrait; //the trait that is required to unlock this one

    //[Header("Other")]

    private void Awake()
    {
        characterStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        baseCost = cost; //store our inital cost to preserve it for a reset
        load(); //load the trait when the scene starts
    }

    //this function adds a rank to the trait and then saves its stats to playerprefs
    public void addRank()
    {
        rank++;
        totalCost += cost;
        cost = (int)Mathf.Floor(cost * costScale);
        //save();
    }

    //save the current status of the trait to player prefs
    /*public void save()
    {
        PlayerPrefs.SetInt(name + "Status", (activated ? 1 : 0));
        PlayerPrefs.SetInt(name + "Rank", rank);
    }*/

    //load the trait's status from playerprefs
    public void load()
    {
        /*activated = (PlayerPrefs.GetInt(name + "Status", 0) != 0);
        rank = PlayerPrefs.GetInt(name + "Rank", 0);*/

        //add all the trait bonuses to the character stats
        if (characterStats != null)
        {
            characterStats.addagility(agilityBonus);
            characterStats.adddexterity(dexterityBonus);
            characterStats.addEndurance(enduranceBonus);
            characterStats.addIntelligence(intelligenceBonus);
            characterStats.addluck(luckBonus);
            characterStats.addstrength(strengthBonus);
        }
    }

    public void unload()
    {
        //subtract all the trait bonuses to the character stats
        if (characterStats != null)
        {
            characterStats.addagility(-agilityBonus);
            characterStats.adddexterity(-dexterityBonus);
            characterStats.addEndurance(-enduranceBonus);
            characterStats.addIntelligence(-intelligenceBonus);
            characterStats.addluck(-luckBonus);
            characterStats.addstrength(-strengthBonus);
        }
    }

    public virtual bool Activate()
    {
        //do trait activation
        activated = true;
        //save();
        return true; //this value will be used for debug
    }

    public virtual bool Deactivate()
    {
        //do trait deactivation
        activated = false;
        rank = 0;
        //save();
        return true; //this value will be used for debug
    }

    public virtual TraitData package()
    {
        return new TraitData(luckBonus, intelligenceBonus, strengthBonus, agilityBonus, enduranceBonus, dexterityBonus, HealthBonus, MPBonus, traitName, traitDescription, activated, rank, maxRanks, cost, totalCost, baseCost, costScale);
    }

    public virtual void unpackage(TraitData td)
    {
        if (this.traitName == td.traitName)
        {
            this.luckBonus = td.luckBonus;
            this.intelligenceBonus = td.intelligenceBonus;
            this.strengthBonus = td.strengthBonus;
            this.agilityBonus = td.agilityBonus;
            this.enduranceBonus = td.enduranceBonus;
            this.dexterityBonus = td.dexterityBonus;
            this.HealthBonus = td.HealthBonus;
            this.MPBonus = td.MPBonus;
            this.traitDescription = td.traitDescription;
            this.activated = td.activated;
            this.rank = td.rank;
            this.maxRanks = td.maxRanks;
            this.cost = td.cost;
            this.totalCost = td.totalCost;
            this.baseCost = td.baseCost;
            this.costScale = td.costScale;
        }
    }
}

[System.Serializable]
public class TraitData
{
    public float luckBonus; 
    public float intelligenceBonus;
    public float strengthBonus;
    public float agilityBonus;
    public float enduranceBonus;
    public float dexterityBonus;
    public float HealthBonus; 
    public float MPBonus;
    public string traitName;
    public string traitDescription;
    public bool activated;
    public int rank;
    public int maxRanks;
    public int cost; 
    public int totalCost; 
    public int baseCost;
    public float costScale;

    public TraitData(float luk, float intel, float str, float agi, float end, float dex, float hp, float mp, string name, string desc, bool act, int rank, int maxrank, int cost, int tcost, int bcost, float scale)
    {
        this.luckBonus = luk;
        this.intelligenceBonus = intel;
        this.strengthBonus = str;
        this.agilityBonus = agi;
        this.enduranceBonus = end;
        this.dexterityBonus = dex;
        this.HealthBonus = hp;
        this.MPBonus = mp;
        this.traitName = name;
        this.traitDescription = desc;
        this.activated = act;
        this.rank = rank;
        this.maxRanks = maxrank;
        this.cost = cost;
        this.totalCost = tcost;
        this.baseCost = bcost;
        this.costScale = scale;
    }
}