using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraitResetButton : MonoBehaviour {

    public TraitManager tm; //a reference to the trait manager object that runs the whole system
    public GameObject[] btns; //an array to hold all the trait buttons; this will be used to trigger deactivations
    public Text purchase; //a reference to the text that will inform the user the traits are being reset

    private void Awake()
    {
        //find our traitmanager
        //NOTE: the tag must match the tag on your trait manager object
        tm = GameObject.FindGameObjectWithTag("traitManager").GetComponent<TraitManager>();
        //find all our trait buttons
        //NOTE: the tag must match the tag on your trait buttons
        btns = GameObject.FindGameObjectsWithTag("traitButton");
    }

    public void deactivateTraits()
    {
        //change the text to inform the user that the traits have been reset
        purchase.color = new Color(1f, 1f, 1f, 1f); 
        purchase.text = "--Traits reset--";
        Invoke("purchaseTextFade", 5f); //make the text fade after 5 seconds

        //go through our array of buttons and make them interactable if their rank is greater than zero
        //we're assuming that anything with a negative rank is disabled
        foreach (GameObject g in btns)
        {
            if (g.GetComponent<TraitButton>().trait.rank > 0)
            {
                g.GetComponent<Button>().interactable = true;
            }
        }
        tm.deactivateTraitsButton(tm.traits); //reach out the the trait manager to tell it to deactivate the trait while refunding the point
    }

    //this method is used to fade the message confirming a purchase
    //it is invoked on a delay
    public void purchaseTextFade()
    {
        purchase.CrossFadeAlpha(0.0f, 1f, true);
    }
}
