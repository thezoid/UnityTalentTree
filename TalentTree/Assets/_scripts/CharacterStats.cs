using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;

[System.Serializable]
public class CharacterStats : MonoBehaviour {

    //Player Stats
    [Header("Player Stats")]
    public float luck; 
    private float minLuck = 0.0001f;
    public float intelligence; 
    public float strength;
    public float agility;
    public float endurance;
    public float dexterity; 
    public float baseDamage = 5f;

    //In-Game Stats
    [Header("Health Settings")]
    public float timer = 0f;
    public float maxHealth;
    public float Health; //Current health of player, <= 0 == Dead
    public float healthPerSecond = 0f;
    public float damageReduction;

    //energy
    [Header("Energy Settings")]
    public float energy; // current player energy
    public float maxEnergy = 100; //max and starting player energy
    public float energyPerSecond = .25f; //energy per second

    //mana
    [Header("Mana Settings")]
    public float mana; // current player energy
    public float maxMana = 100; //max and starting player energy
    public float manaPerSecond = .15f; //energy per second

    //Derived Stats
    float moveSpeedMulti;
       
    #region Magic
    [Header("Magic Settings")]
    public Magic currentMagic;

    public bool fireballUnlocked;
    public float fireballCost;
    public float fireballBaseCost;
    public float fireballDamage;
    public float fireballBaseDamage;
    public float fireballDuration;
    public GameObject fireBallObject;

    public bool shieldUnlocked;
    public float shieldBaseCost;
    public float shieldCost;
    public float shieldDuration;
    public float shieldBaseDuration;
    public bool shieldActive;
    public float shieldCurrentDuration;

    public bool timeControlUnlocked;
    public float timeControlBaseCost;
    public float timeControlCost;
    public float timeControlDuration;
    public float timeControlBaseDuration;
    public float timeControlCurrentDuration;

    public bool thornsUnlocked;
    public float thornsCost;
    public float thornsBaseCost;
    public float thornsDuration;
    public float thornsBaseDuration;
    public float thornsDamage;
    public float thornsBaseDamage;
    public bool thornsActive;
    public float thornsCurrentDuration;

    public bool stealthUnlocked;
    public float stealthCost;
    public float stealthBaseCost;
    public float stealthDuration;
    public float stealthCurrentDuration;


    public bool pounceUnlocked;
    public float pounceCost;
    public float pounceBaseCost;
    public float pounceForce;
    public float pounceDamageMulti;

    public bool enrageUnlocked;
    public float enrageDuration;
    public float enrageDamageMulti;
    public float enrageCost;
    public float enrageBaseCost;
    public float enrageCurrentDuration;

    public bool[] unlockedMagics = new bool[7];
    #endregion





    [Header("Token Calculation")]
    public int tokens;
    public float StatWeight = 0.25f;

    public void setLuck(float amount) { luck = amount; }
    public void setIntelligence(float amount) { intelligence = amount; }
    public void setstrength(float amount) { strength = amount; }
    public void setagility(float amount) { agility = amount; }
    public void setEndurance(float amount) { endurance = amount; }
    public void setdexterity(float amount) { dexterity = amount; }
   
    public float getluck() { return luck; }
    public float getIntelligence() { return intelligence; }
    public float getstrength() { return strength; }
    public float getagility() { return agility; }
    public float getEndurance() { return endurance; }
    public float getdexterity() { return dexterity; }
    
    public void addluck(float amount) { luck += amount; }
    public void addIntelligence(float amount) { intelligence += amount; }
    public void addstrength(float amount) { strength += amount; }
    public void addagility(float amount) { agility += amount; }
    public void addEndurance(float amount) { endurance += amount; }
    public void adddexterity(float amount) { dexterity += amount; }
    
    public float critChance;
    public float currencyGained;
    public float currencyRetained;
    public float healthLeech;
    public float energyLeech;
    public float manaLeech;
    public float aggroReduction;
    public float damageMod;
    public float knockBack;
    public float swipeRange;

    public bool prompt1 = false;
    public bool prompt2 = false;

    /*public void loadPrefStats()
    {
        luck = PlayerPrefs.GetFloat("luck", 1); //Luck, effects drop rate, positive luck lowers the floor on the difficulty, negitive luck raises the celing.
        intelligence = PlayerPrefs.GetFloat("intelligence", 1); //Magic (Space-bar attack) Damage, MP Pool, and resistance ot magic damage.
        strength = PlayerPrefs.GetFloat("strength", 1); //Strength, (Arrow-keys Attack) Damage
        agility = PlayerPrefs.GetFloat("agility", 1); //Agility, Attack Recovery rate
        endurance = PlayerPrefs.GetFloat("endurance", 1); //Stamina, Max Health
        dexterity = PlayerPrefs.GetFloat("dexterity", 1); //dex, Movespeed (Maybe we should clamp it) || B - let's max it at 1.5 for now and can recap later, step up by .01 or so
        tokens = PlayerPrefs.GetInt("tokens", 0);
        damageReduction = PlayerPrefs.GetFloat("damageReduction", 0f);
        healthPerSecond = PlayerPrefs.GetFloat("healthRegen", 0f);
        maxHealth = PlayerPrefs.GetInt("maxHealth", 100);
        manaPerSecond = PlayerPrefs.GetFloat("manaRegen", 0.02f);
        maxMana = PlayerPrefs.GetFloat("maxMana", 100f);
        critChance = PlayerPrefs.GetFloat("critChance", 0.05f);
        currencyGained = PlayerPrefs.GetFloat("currencyGain", 1f);
        currencyRetained = PlayerPrefs.GetFloat("currencyRetained", 0f);
        healthLeech = PlayerPrefs.GetFloat("healthLeech", 0f);
        manaLeech = PlayerPrefs.GetFloat("manaLeech", 0f);
        energyLeech = PlayerPrefs.GetFloat("energyLeech", 0f);
        aggroReduction = PlayerPrefs.GetFloat("aggroRange", 0f);
        attackDelay = PlayerPrefs.GetFloat("attackCD", 1f);
        moveSpeedMulti = PlayerPrefs.GetFloat("moveSpeed", 1f);
        energyPerSecond = PlayerPrefs.GetFloat("energyRegen1", .2f);

        maxEnergy = PlayerPrefs.GetFloat("maxEnergy", 100f);
        damageMod = PlayerPrefs.GetFloat("damage", 0f);
        baseDamage = PlayerPrefs.GetFloat("baseDamage", 1f);
        knockBack = PlayerPrefs.GetFloat("knockBack", 0f);
        swipeRange = PlayerPrefs.GetFloat("swipeRange", 0.5f);

        //In-Game Stats
        PlayerPrefs.GetFloat("maxHealth", 100);
        Health = PlayerPrefs.GetFloat("health", maxHealth); //Current health of player, <= 0 == Dead
        PlayerPrefs.GetFloat("maxMana", 100);
        mana = PlayerPrefs.GetFloat("mana", maxMana); //Meowgic Power (?) 
        PlayerPrefs.GetFloat("maxEnergy", 100);
        energy = PlayerPrefs.GetFloat("energy", maxEnergy);

        //Cat magic
        currentMagic = (Magic)PlayerPrefs.GetInt("currentCatMagic");
        
        #region MagicUnlock Sets
        //fireball
        unlockedMagics[0] = (PlayerPrefs.GetInt("fireballUnlocked", 0) != 0);
        fireballUnlocked = (PlayerPrefs.GetInt("fireballUnlocked", 0) != 0);

        fireballCost = PlayerPrefs.GetFloat("fireballCost", 1f);
        fireballBaseCost = PlayerPrefs.GetFloat("fireballBaseCost", 25f);
        fireballDamage = PlayerPrefs.GetFloat("fireballDamage", 1.25f);
        fireballBaseDamage = PlayerPrefs.GetFloat("fireballBaseDamage", 1f);
        //shields
        unlockedMagics[1] = (PlayerPrefs.GetInt("shieldUnlocked", 0) != 0);
        shieldUnlocked = (PlayerPrefs.GetInt("shieldUnlocked", 0) != 0);
        shieldCost = PlayerPrefs.GetFloat("shieldCost", 1f);
        shieldBaseCost = PlayerPrefs.GetFloat("shieldBaseCost", 25f);
        shieldDuration = PlayerPrefs.GetFloat("shieldDuration", 1.25f);
        shieldBaseDuration = PlayerPrefs.GetFloat("shieldBaseDuration", 1f);
        //Time Control
        unlockedMagics[2] = (PlayerPrefs.GetInt("timeControlUnlocked", 0) != 0);
        timeControlUnlocked = PlayerPrefs.GetInt("timeControlUnlocked", 0) != 0;
        timeControlCost = PlayerPrefs.GetFloat("timeControlCost", 1f);
        timeControlBaseCost = PlayerPrefs.GetFloat("timeControlBaseCost", 25f);
        timeControlDuration = PlayerPrefs.GetFloat("timeControlDuration", 1.5f);
        timeControlBaseDuration = PlayerPrefs.GetFloat("timeControlBaseDuration", 1f);
        //Thorns
        unlockedMagics[3] = (PlayerPrefs.GetInt("thornsUnlocked", 0) != 0);
        thornsActive = (PlayerPrefs.GetInt("thornsUnlocked", 0) != 0);
        thornsCost = PlayerPrefs.GetFloat("thornsCost", 1f);
        thornsBaseCost = PlayerPrefs.GetFloat("thornsBaseCost", 25f);
        thornsDamage = PlayerPrefs.GetFloat("thornsDamage", 1f);
        thornsBaseDamage = PlayerPrefs.GetFloat("thornsBaseDamage", 1f);
        thornsDuration = PlayerPrefs.GetFloat("thornsDuration", 1.25f);
        thornsBaseDuration = PlayerPrefs.GetFloat("thornsBaseDuration", 1f);
        //stealth
        unlockedMagics[4] = (PlayerPrefs.GetInt("stealthUnlocked", 0) != 0);
        stealthCost = PlayerPrefs.GetFloat("stealthCost", 1f);
        stealthBaseCost = PlayerPrefs.GetFloat("stealthBaseCost", 25f);
        stealthDuration = PlayerPrefs.GetFloat("stealthDuration", 1.25f);

        //Enrage
        unlockedMagics[6] = (PlayerPrefs.GetInt("enrageUnlocked", 0) != 0);
        enrageUnlocked = unlockedMagics[6];
        enrageDamageMulti = PlayerPrefs.GetFloat("enrageMultiplier", 2f);
        enrageDuration = PlayerPrefs.GetFloat("enrageDuration", 5f);
        enrageCost = PlayerPrefs.GetFloat("enrageCost", 1f);
        enrageBaseCost = PlayerPrefs.GetFloat("enrageBaseCost", 25f);
        #endregion
    }*/


    public float getMoveSpeed()
    {
        return (moveSpeedMulti);
    }

    float attackDelay;

    public float getAttackDelay()
    {
        return (attackDelay);
    }

    void setStats()
    {
        //Max HP
        float oldMax = maxHealth;
        float newMaxHealth = 90 + (endurance * 10);

        if (oldMax != newMaxHealth)
        {

            float healthRatio = Health / maxHealth;
            Health = newMaxHealth * healthRatio;
        }
        maxHealth = newMaxHealth;

        //Max MP
        oldMax = maxMana;
        float newMaxMana = 90 + (intelligence * 10);
        if (oldMax != newMaxMana)
        {
            float manaRatio = mana / maxMana;
            mana = newMaxMana * manaRatio;
        }
        maxMana = newMaxMana;

        //max energy
        oldMax = maxEnergy;
        float newMaxEnergy = 90 + (agility * 10);
        if (oldMax != newMaxEnergy)
        {
            float energyRatio = energy / maxEnergy;
            energy = newMaxEnergy * energyRatio;
        }
        maxEnergy = newMaxEnergy;

        attackDelay = Mathf.Clamp(1 / Mathf.Sqrt(agility), 1f, 4f); //TODO: calculate min and max attack delays based on stats
        moveSpeedMulti = Mathf.Clamp(3 + Mathf.Log(dexterity), .25f, 2f); //TODO: calculate min and max move speeds through stats
    }

    public float damageCalc()
    {
        return Mathf.Clamp(baseDamage + ((int)strength ^ 2) / 1000, baseDamage, 1000); //will need to determine the max damage we want our player to do
    }

    void Awake()
    {

        Debug.Log(Path.Combine(Application.persistentDataPath, "characterStats.gd")); //see where the characterStats file is saved

        load();

        setStats();
        Health = maxHealth;
        mana = maxMana;
        energy = maxEnergy;
    }

    void Update()
    {
        //setStats (); //TODO: dont call this every frame, but only when stats update

        if (luck <= minLuck)
        {
            luck = minLuck; //cant let luck get to or below zero until other calcs are changed
        }
        //internal clock function to regulate actions
        timer += Time.deltaTime;
        if (timer == 60f)
        {
            timer = 0f;
        }
        //Spell timers
        bool spellActive = false;
        if (thornsCurrentDuration > 0f)
        {
            thornsCurrentDuration -= Time.deltaTime;
            thornsActive = true;
            spellActive = true;
        }
        if (shieldCurrentDuration > 0f)
        {
            shieldCurrentDuration -= Time.deltaTime;
            shieldActive = true;
            spellActive = true;
        }
        if (stealthCurrentDuration > 0f)
        {
            stealthCurrentDuration -= Time.deltaTime;
            spellActive = true;
        }

        if (timeControlCurrentDuration > 0f)
        {
            timeControlCurrentDuration -= Time.deltaTime;
            spellActive = true;
        }

        if (enrageCurrentDuration > 0f)
        {
            enrageCurrentDuration -= Time.deltaTime;
            spellActive = true;
        }
        if (!spellActive)
        {
           //do what happens when there are no spells 
        }


        //resource regen
        if ((int)timer % 2 == 0)//resources regen every 2 seconds
        {
            bool regening = false;
            if (energy < maxEnergy)
            {
                if (energy > maxEnergy)
                {
                    energy = maxEnergy;
                }
                else
                {
                    energy += energyPerSecond * 2;//* maxEnergy; add this to scale it off the maximum amount
                    regening = true;
                }
            }
            if (mana < maxMana)
            {
                
                if (mana > maxMana)
                {
                    mana = maxMana;
                }
                else
                {
                    mana += manaPerSecond * 2;// * maxMana;add this to scale it off the maximum amount
                    regening = true;
                }
            }
            if (Health < maxHealth)
            {
                Health += healthPerSecond * 2;// * maxHealth;add this to scale it off the maximum amount
                regening = true;
            }
            if (regening == true)
            {
                timer = 1f; //skip the timer to 1 to stop you from instantly regaining all your stat
                regening = false;
            }
        }
        //stop energy and mana from being negative
        if (energy <= 0f)
        {
            energy = 0f;
        }
        if (mana <= 0f)
        {
            mana = 0f;
        }


    }

    public void takeDamage(int amount)
    {
        if (enrageCurrentDuration > 0)
        {
            Health -= amount * enrageDamageMulti;
        }
        else
        {
            Health -= amount;
        }
        if (Health <= 0)
        {
            die();
        }
    }

    int tokenCalc()
    {
        float tokenTemp = tokens;
        tokenTemp = tokenTemp + tokenTemp * StatWeight * luck; //add tokens based on luck
        Debug.Log("1Tokens earned: " + (int)tokenTemp);
        tokenTemp = tokenTemp + tokenTemp * StatWeight * intelligence; //add tokens based on int
        Debug.Log("2Tokens earned: " + (int)tokenTemp);
        tokenTemp = tokenTemp + tokenTemp * StatWeight * strength; //add tokens based on strength
        Debug.Log("3Tokens earned: " + (int)tokenTemp);
        tokenTemp = tokenTemp + tokenTemp * StatWeight * agility; //add tokens based on agility
        Debug.Log("4Tokens earned: " + (int)tokenTemp);
        tokenTemp = tokenTemp + tokenTemp * StatWeight * endurance; //add tokens based on endurance
        Debug.Log("5Tokens earned: " + (int)tokenTemp);
        tokenTemp = tokenTemp + tokenTemp * StatWeight * dexterity; //add tokens based on dexterity
        Debug.Log("6Tokens earned: " + (int)tokenTemp);
        //tokenTemp *= PlayerPrefs.GetFloat("currencyGained");
        //Debug.Log("7Tokens earned: " + (int)tokenTemp);
        //Debug.Log(PlayerPrefs.GetFloat("currencyGained"));
        return (int)tokenTemp;
    }

    void die()
    {

        TraitManager.manager.deactivateTraits(TraitManager.manager.traits);

        /*#region PlayerPref Setts

        PlayerPrefs.SetFloat("luck", Mathf.Clamp(luck * .025f, 1, 5)); //Luck, effects drop rate, positive luck lowers the floor on the difficulty, negitive luck raises the celing.
        PlayerPrefs.SetFloat("intelligence", Mathf.Clamp(intelligence * .025f, 1, 5)); //Magic (Space-bar attack) Damage, MP Pool, and resistance ot magic damage.
        PlayerPrefs.SetFloat("strength", Mathf.Clamp(strength * .025f, 1, 5)); //Strength, (Arrow-keys Attack) Damage
        PlayerPrefs.SetFloat("agility", Mathf.Clamp(agility * .025f, 1, 5)); //Agility, Attack Recovery rate
        PlayerPrefs.SetFloat("endurance", Mathf.Clamp(endurance * .025f, 1, 5)); //Stamina, Max Health
        PlayerPrefs.SetFloat("dexterity", Mathf.Clamp(dexterity * .025f, 1, 5)); //dex, Movespeed (Maybe we should clamp it) || B - let's max it at 1.5 for now and can recap later, step up by .01 or so
        tokens = tokenCalc();
        PlayerPrefs.SetInt("tokens", tokens);

        PlayerPrefs.SetInt("fireballUnlocked", 0);
        PlayerPrefs.SetInt("shieldUnlocked", 0);
        PlayerPrefs.SetInt("timeControlUnlocked", 0);
        PlayerPrefs.SetInt("thornsUnlocked", 0);
        PlayerPrefs.SetInt("stealthUnlocked", 0);

        //In-Game Stats
        PlayerPrefs.SetFloat("currMaxHealth", 1);
        PlayerPrefs.SetFloat("currHealth", 1); //Current health of player, <= 0 == Dead
        PlayerPrefs.SetFloat("currMaxMP", 1);
        PlayerPrefs.SetFloat("currMP", 1); //Meowgic Power (?)
        PlayerPrefs.SetInt("hasWings", 0);
        PlayerPrefs.SetInt("hasWitch", 0);
        PlayerPrefs.SetInt("hasCollar", 0);
        PlayerPrefs.SetInt("currentCatMagic", 0);

        #endregion*/
        Cursor.lockState = CursorLockMode.None;
    }

    public void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Path.Combine(Application.persistentDataPath, "characterStats.gd"), FileMode.OpenOrCreate);
        PlayerData pd = new PlayerData(luck,intelligence,agility,strength,endurance,dexterity,maxHealth,Health,damageReduction,energy,maxEnergy,energyPerSecond,mana,maxMana,manaPerSecond,currentMagic,fireballUnlocked,
            fireballCost,fireballBaseCost,fireballDamage,fireballBaseDamage,fireballDuration,shieldUnlocked,shieldBaseCost,shieldCost,shieldDuration,shieldBaseDuration,shieldActive,shieldCurrentDuration,timeControlUnlocked,
            timeControlBaseCost,timeControlCost,timeControlDuration,timeControlBaseDuration,timeControlCurrentDuration,thornsUnlocked,thornsCost,thornsBaseCost,thornsDuration,thornsBaseDuration,thornsDamage,thornsBaseDamage,
            thornsActive,thornsCurrentDuration,stealthUnlocked,stealthCost,stealthBaseCost,stealthDuration,stealthCurrentDuration,pounceUnlocked,pounceCost,pounceBaseCost,pounceForce,pounceDamageMulti,enrageUnlocked,
            enrageDuration,enrageDamageMulti,enrageCost,enrageBaseCost,enrageCurrentDuration,healthPerSecond,baseDamage);
        bf.Serialize(file, pd);
        file.Close();
    }

    public void load()
    {
        if (File.Exists(Path.Combine(Application.persistentDataPath, "characterStats.gd")))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Path.Combine(Application.persistentDataPath, "characterStats.gd"), FileMode.Open);
            PlayerData pd = (PlayerData)bf.Deserialize(file);
            file.Close();
            this.luck = pd.luck;this.intelligence = pd.intelligence;this.agility = pd.agility;this.strength = pd.strength;this.maxHealth = pd.maxHealth;this.Health = pd.Health;this.damageReduction = pd.damageReduction;
            this.energy = pd.energy;this.maxEnergy = pd.maxEnergy;this.energyPerSecond = pd.energyPerSecond;this.mana = pd.mana;this.maxMana = pd.maxMana;this.manaPerSecond = pd.manaPerSecond;this.currentMagic = pd.currentMagic;
            this.fireballUnlocked = pd.fireballUnlocked;this.fireballCost = pd.fireballCost;this.fireballBaseCost = pd.fireballBaseCost;this.fireballDamage = pd.fireballDamage;this.fireballBaseDamage = pd.fireballBaseDamage;
            this.fireballDuration = pd.fireballDuration;this.shieldUnlocked = pd.shieldUnlocked;this.shieldBaseCost = pd.shieldBaseCost;this.shieldCost = pd.shieldCost;this.shieldDuration = pd.shieldDuration;this.shieldBaseDuration = pd.shieldBaseDuration;
            this.shieldActive = pd.shieldActive;this.shieldCurrentDuration = pd.shieldCurrentDuration;this.timeControlUnlocked = pd.timeControlUnlocked;this.timeControlBaseCost = pd.timeControlBaseCost;this.timeControlCost = pd.timeControlCost;
            this.timeControlDuration = pd.timeControlDuration;this.timeControlBaseDuration = pd.timeControlBaseDuration;this.timeControlCurrentDuration = pd.timeControlCurrentDuration;this.thornsUnlocked = pd.thornsUnlocked;
            this.thornsCost = pd.thornsCost;this.thornsBaseCost = pd.thornsBaseCost;this.thornsDuration = pd.thornsDuration;this.thornsBaseDuration = pd.thornsBaseDuration;this.thornsDamage = pd.thornsDamage;this.thornsBaseDamage = pd.thornsBaseDamage;
            this.thornsActive = pd.thornsActive;this.thornsCurrentDuration = pd.thornsCurrentDuration;this.stealthUnlocked = pd.stealthUnlocked;this.stealthCost = pd.stealthCost;this.stealthBaseCost = pd.stealthBaseCost;
            this.stealthDuration = pd.stealthDuration;this.stealthCurrentDuration = pd.stealthCurrentDuration;this.pounceUnlocked = pd.pounceUnlocked;this.pounceCost = pd.pounceCost;this.pounceBaseCost = pd.pounceBaseCost;
            this.pounceForce = pd.pounceForce;this.pounceDamageMulti = pd.pounceDamageMulti;this.enrageUnlocked = pd.enrageUnlocked;this.enrageDuration = pd.enrageDuration;this.enrageDamageMulti = pd.enrageDamageMulti;
            this.enrageCost = pd.enrageCost;this.enrageBaseCost = pd.enrageBaseCost;this.enrageCurrentDuration = pd.enrageCurrentDuration;this.healthPerSecond = pd.healthPerSecond;this.baseDamage = pd.baseDamage;
        }
        else
        {
            Debug.Log("FILE NOT FOUND - characterStats.gd not found at: " + Path.Combine(Application.persistentDataPath, "characterStats.gd"));
        }
    }
}

//this enumeration holds all our magic types so we can use it in the main class and the container class
public enum Magic { none, fireball, shield, timeStop, thorns, stealth, pounce, enrage };


//the player data container class to save
[System.Serializable]
class PlayerData
{
    //Player Stats
    public float luck;
    public float intelligence;
    public float strength;
    public float agility;
    public float endurance;
    public float dexterity;
    public float baseDamage;

    //In-Game Stats
    public float maxHealth;
    public float Health; //Current health of player, <= 0 == Dead
    public float healthPerSecond = 0f;
    public float damageReduction;

    //energy
    public float energy; // current player energy
    public float maxEnergy = 100; //max and starting player energy
    public float energyPerSecond = .25f; //energy per second

    //mana
    public float mana; // current player energy
    public float maxMana = 100; //max and starting player energy
    public float manaPerSecond = .15f; //energy per second

    #region Magic
    //Magic
    public Magic currentMagic;

    public bool fireballUnlocked;
    public float fireballCost;
    public float fireballBaseCost;
    public float fireballDamage;
    public float fireballBaseDamage;
    public float fireballDuration;

    public bool shieldUnlocked;
    public float shieldBaseCost;
    public float shieldCost;
    public float shieldDuration;
    public float shieldBaseDuration;
    public bool shieldActive;
    public float shieldCurrentDuration;

    public bool timeControlUnlocked;
    public float timeControlBaseCost;
    public float timeControlCost;
    public float timeControlDuration;
    public float timeControlBaseDuration;
    public float timeControlCurrentDuration;

    public bool thornsUnlocked;
    public float thornsCost;
    public float thornsBaseCost;
    public float thornsDuration;
    public float thornsBaseDuration;
    public float thornsDamage;
    public float thornsBaseDamage;
    public bool thornsActive;
    public float thornsCurrentDuration;

    public bool stealthUnlocked;
    public float stealthCost;
    public float stealthBaseCost;
    public float stealthDuration;
    public float stealthCurrentDuration;


    public bool pounceUnlocked;
    public float pounceCost;
    public float pounceBaseCost;
    public float pounceForce;
    public float pounceDamageMulti;

    public bool enrageUnlocked;
    public float enrageDuration;
    public float enrageDamageMulti;
    public float enrageCost;
    public float enrageBaseCost;
    public float enrageCurrentDuration;
    #endregion

    public PlayerData(float luk,float intel, float agi, float str, float end, float dex, float maxHP, float HP, float DR, float nrg, float maxNrg, float eps, float MP, float maxMP, float mps,
        Magic curMagi, 
        bool FBUnlock,float FBCost,float FBBaseCost,float FBdam,float FBBaseDam, float FBdur,
        bool SUnlocked, float SBaseCost, float SCost, float SDur,float SBaseDur, bool SActive, float Scurdur,
        bool timeCtrlUnlock, float timeCtrlBaseCost, float timeCtrlCost,float timeCtrlDur,float timeCtrlBaseDur,float TimeCtrlCurDur,
        bool THUnlock, float THCost, float THBaseCost, float THDur, float THBaseDur,float THDam, float THBaseDam,bool THActive, float THCurDur,
        bool stlUnlock, float stlCost, float stlBaseCost, float stlDur, float stlCurDur, 
        bool pUnlock, float pCost, float pBaseCost,float pForce,float pDamageMulti,
        bool enrUnlock,float enrDur,float enrDamMulti,float enrCost,float enrBaseCost,float enrCurDur,
        float hps = 0f, float baseDam = 5f)
    {
        this.luck = luk;this.intelligence = intel;this.agility = agi;this.strength = str;this.endurance = end;this.dexterity = dex;

        this.maxHealth = maxHP;this.Health = HP;this.damageReduction = DR;

        this.energy = nrg;this.maxEnergy = maxNrg;this.energyPerSecond = eps;this.mana = MP;this.maxMana = maxMP;this.manaPerSecond = mps;

        this.currentMagic = curMagi;

        this.fireballUnlocked = FBUnlock;this.fireballCost = FBCost;this.fireballBaseCost = FBBaseCost;this.fireballDamage = FBdam; this.fireballBaseDamage = FBBaseDam;this.fireballDuration = FBdur;

        this.shieldUnlocked = SUnlocked;this.shieldBaseCost = SBaseCost;this.shieldCost = SCost;this.shieldDuration = SDur;this.shieldBaseDuration = SBaseDur;this.shieldActive = SActive;this.shieldCurrentDuration = Scurdur;

        this.timeControlUnlocked = timeCtrlUnlock;this.timeControlBaseCost = timeCtrlBaseCost;this.timeControlCost = timeCtrlCost;this.timeControlDuration = timeCtrlDur;this.timeControlBaseDuration = timeCtrlBaseDur;this.timeControlCurrentDuration = TimeCtrlCurDur;

        this.thornsUnlocked = THUnlock;this.thornsCost = THCost;this.thornsBaseCost = THBaseCost;this.thornsDuration = THDur;this.thornsBaseDuration = THBaseDur;this.thornsDamage = THDam;this.thornsBaseDamage = THBaseDam;this.thornsActive = THActive;this.thornsCurrentDuration = THCurDur;

        this.stealthUnlocked = stlUnlock;this.stealthCost = stlCost;this.stealthBaseCost = stlBaseCost;this.stealthDuration = stlDur;this.stealthCurrentDuration = stlCurDur;

        this.pounceUnlocked = pUnlock;this.pounceCost = pCost;this.pounceBaseCost = pBaseCost;this.pounceForce = pForce;this.pounceDamageMulti = pDamageMulti;

        this.enrageUnlocked = enrUnlock;this.enrageDuration = enrDur;this.enrageDamageMulti = enrDamMulti;this.enrageCost = enrCost;this.enrageBaseCost = enrBaseCost;this.enrageCurrentDuration = enrCurDur;

        this.healthPerSecond = hps; this.baseDamage = baseDam;
    }
}