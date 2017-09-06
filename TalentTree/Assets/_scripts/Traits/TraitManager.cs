using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine;

public class TraitManager : MonoBehaviour
{
    public Trait[] traits; //an array to hold all your traits
    public GameObject[] traitsGOs; //an array to hold all the scene items
    public Tokens tokens; //the reference to the object managing your tokens

    public static TraitManager manager;

    void Awake()
    {
        Debug.Log(Path.Combine(Application.persistentDataPath, "traits.gd")); //see where the traits file is saved
        //PERSISTENCE
        //there can only ever be one TraitManager
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }else if(manager != this){
            Destroy(gameObject);
        }
        //PERSISTENCE

        traitsGOs = GameObject.FindGameObjectsWithTag("trait"); //find all the trait game objects
        traits = new Trait[traitsGOs.Length]; //assign traits to be the size of how many trait objects are found
        for (int i = 0; i < traitsGOs.Length; i++) //use this loop to populate our array with the traits
        {
            traits[i] = traitsGOs[i].GetComponent<Trait>();
        }
        //load all our traits so they are up to date with the save, then activate them
        loadTraits(traits);
        activateTraits(traits);
    }

    //this method loops through all our traits in the given trait array and triggers their save method
    //save will write the current status of the trait to playerprefs
    public void saveTraits(Trait[] ts)
    {
        if(ts.Length > 0)
        {
            List<TraitData> tds = new List<TraitData>();
            foreach(Trait t in ts)
            {
                tds.Add(t.package());
            }
            TraitManagerData tmd = new TraitManagerData(tds);

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Path.Combine(Application.persistentDataPath, "traits.gd"), FileMode.OpenOrCreate);
            bf.Serialize(file, tmd);
            file.Close();
        }
        //if we fall through to the else case, then we dont have any traits in our array and an error occured finding the traits
        else
        {
            Debug.Log("No traits to save - check traits array");
        }
    }

    //this method loops through all our traits in the given trait array and triggers their load method
    //load will set the status of the trait from the data in playerprefs
    public void loadTraits(Trait[] ts)
    {
        /*if (ts.Length > 0)
        {
            foreach (Trait t in ts)
            {
                t.load();
            }
        }*/
        if (File.Exists(Path.Combine(Application.persistentDataPath, "traits.gd")))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Path.Combine(Application.persistentDataPath, "traits.gd"), FileMode.Open);
            TraitManagerData td = (TraitManagerData)bf.Deserialize(file);
            file.Close();
            if (td.traitdata.Count > 0)
            {
                for (int i = 0; i < td.traitdata.Count; i++)
                {
                    traits[i].unpackage(td.traitdata[i]);
                }
                /*foreach (Trait t in traits)
                {
                    t.unpackage();
                }*/
            }
            //if we fall through to the else case, then we dont have any traits in our array and an error occured finding the traits
            else
            {
                Debug.Log("No traits to load - check traits array");
            }
        }else
        {
            Debug.Log("FILE NOT FOUND - traits.gd not found at: "+Path.Combine(Application.persistentDataPath,"traits.gd"));
        }
        
    }

    //loop through the given trait array and activate all the traits
    public void activateTraits(Trait[] ts)
    {
        if (ts.Length > 0)
        {
            foreach (Trait t in ts)
            {
                if (t.Activate())
                {
                    //uncomment the line below to get more details on what traits are activating; WARNING: this will spam the console
                    //Debug.Log(t.name + " activated successfully!");
                }
                //if we fall through to the else case, then our trait has failed activating and we need to report it to the console
                else
                {
                    Debug.Log(t.traitName + " failed activating!");
                }
            }
        }
        else
        {
            Debug.Log("No traits to activate - check traits array");
        }
    }

    //loop through the given trait array and deactivate all the traits
    public void deactivateTraits(Trait[] ts)
    {
        if (ts.Length > 0)
        {
            foreach (Trait t in ts)
            {
                if (t.Deactivate())
                {
                    //uncomment the line below to get more details on what traits are deactivating; WARNING: this will spam the console
                    //Debug.Log(t.name + " deactivated successfully!");
                }
                //if we fall through to the else case, then our trait failed deactivating and we need to report it failing
                else
                {
                    Debug.Log(t.traitName + " failed deactivating!");
                }
            }
        }
        //if we fall through to this else case, then the array contained no traits to deactivate
        else
        {
            Debug.Log("No traits to deactivate - check traits array");
        }
    }

    //this works similarly to deactiveTraits, but is triggered by a reset button
    //if points were put into a trait, it will refund the points after deactivating the trait
    //otherwise, it works like the normal deavtivate trait function
    public void deactivateTraitsButton(Trait[] ts)
    {
        if (ts.Length > 0)
        {
            foreach (Trait t in ts)
            {
                if (t.rank>0)
                {
                    t.Deactivate();
                    tokens.spendTokens(-t.totalCost); //refund the currency spent on the trait
                    t.cost = t.baseCost; //reset our trait to its base cost
                    //uncomment the line below to get more details on what traits are deactivating; WARNING: this will spam the console
                    //Debug.Log(t.name + " deactivated successfully!");
                }
                else if (t.Deactivate())
                {
                    //uncomment the line below to get more details on what traits are deactivating; WARNING: this will spam the console
                    // Debug.Log(t.name + " deactivated successfully!");
                }
                //if we fall through to the else, then our trait failed to deactivate, so we need to report it to the console
                else
                {
                    Debug.Log(t.traitName + " failed deactivating!");
                }
            }
        }
        //if we fall through to this else case, then the array contained no traits to deactivate
        else
        {
            Debug.Log("No traits to deactivate - check traits array");
        }
    }
}

[System.Serializable]
class TraitManagerData
{
    public List<TraitData> traitdata;
    public TraitManagerData(List<TraitData> tds)
    {
        this.traitdata = tds;
    }
}