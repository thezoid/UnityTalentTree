using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraitButton : MonoBehaviour {

    public Trait trait; //a reference to the trait under the trait manager the button represents
    public Button button; //a reference to the button
    public bool tooltipShow; //a flag for whether or not to show the tooltip
    public string tooltipName; //the name of the trait to be displayed on the
    public string tooltipDesc; //the description of the trait to be displayed
    public string tooltipCost; //the cost of the trait to be displayed
    public Texture tooltipBackground; //the texture of the background of the tooltip
    public GUISkin tooltipSkin; //the guiskin to determine the display of the tooltip
    bool reported = false; //a boolean used for debugging
    public Tokens tokens; //a reference to the object managing the tokens
    public Text purchase; //the text that displays feedback for an action with a button

    //all the tooltip drawing is handled in OnGUI
    private void OnGUI()
    {
        GUI.skin = tooltipSkin;
        if (tooltipShow)
        {
            //if the trait is at max ranks, then we just need to draw the background, name, and description
            //if you want to show the cost, reference the second label of the else case (for example, it will show something like "Cost: 3/3")
            if (trait.rank == trait.maxRanks)
            {
                //tooltip background
                GUI.Box(new Rect(Input.mousePosition.x + 20, Screen.height - Input.mousePosition.y, 175, Mathf.Max((float)Screen.height * 0.20f, ((float)tooltipDesc.Length) + 75f, 125f)),tooltipBackground);
                //tooltip name
                GUI.Label(new Rect(Input.mousePosition.x + 20, Screen.height - Input.mousePosition.y, Mathf.Clamp(tooltipName.Length * 10,75,175), 40), tooltipName);
                //tooltip cost
                GUI.Label(new Rect(Input.mousePosition.x + 20, Screen.height - Input.mousePosition.y + 40, 170, 240), tooltipDesc);
            }
            //if the button isnt interactable but it isnt at max ranks, then it must be a disabled trait,
            //therefore we only need the background, name, and description drawn
            else if (!this.button.interactable)
            {
                //tooltip background
                GUI.Box(new Rect(Input.mousePosition.x + 20, Screen.height - Input.mousePosition.y, 175, Mathf.Max((float)Screen.height * 0.20f, ((float)tooltipDesc.Length) + 75f, 125f)), tooltipBackground);
                //tooltip name
                GUI.Label(new Rect(Input.mousePosition.x + 20, Screen.height - Input.mousePosition.y, Mathf.Clamp(tooltipName.Length * 10, 75, 175), 40), tooltipName);
                //tooltiip description
                GUI.Label(new Rect(Input.mousePosition.x + 20, Screen.height - Input.mousePosition.y + 40, 170, 240), tooltipDesc);
            }
            //the trait is a standard trait that can rank up, 
            //therefore it needs the background, name, cost, and description drawn
            else
            {
                //tooltip description
                GUI.Box(new Rect(Input.mousePosition.x + 20, Screen.height - Input.mousePosition.y, 175, Mathf.Max((float)Screen.height * 0.20f,((float)tooltipDesc.Length) + 75f, 125f)), tooltipBackground);
                //tooltip name
                GUI.Label(new Rect(Input.mousePosition.x + 20, Screen.height - Input.mousePosition.y, Mathf.Clamp(tooltipName.Length * 10, 75, 175), 40), tooltipName);
                //tooltip cost
                GUI.Label(new Rect(Input.mousePosition.x + 20, Screen.height - Input.mousePosition.y + 40, 170, 20), tooltipCost);
                //tooltip description
                GUI.Label(new Rect(Input.mousePosition.x + 20, Screen.height - Input.mousePosition.y + 60, 170, 240), tooltipDesc);
            }
        }
    }

    //when the mouse hovers over one of the buttons, update and show the tooltip
    public void mouseEnter()
    {
        updateTooltip();
        tooltipShow = true;
    }

    //when the mouse stops hovering over a button, stop showing the tooltip
    public void mouseExit()
    {
        tooltipShow = false;
    }

    //do the initial update for the tooltip
    private void Awake()
    {
        updateTooltip();
    }

    private void Update()
    {
        //DEV CHEAT TO ADD TOKENS, REMOVE THIS LATER
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Tokens.tokens = 1000000;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Tokens.tokens = 0;
        }
        //DEV CHEAT TO ADD TOKENS, REMOVE THIS LATER


        if (!(trait.rank < trait.maxRanks)) //if a trait is at max ranks, make it not interactable
        {
            this.button.interactable = false;
        }else if(trait.rank < 0){ //if a trait is at a rank lower than zero, report it to the console as disabled, then disable the button
            if (!reported)
            {
                Debug.Log(trait.traitName+" disabled (rank < 0)");
                reported = true;
            }
            this.button.interactable = false;
        }
        else //otherwise make the button interactable
        {
            this.button.interactable = true;
        }
    }

    //grab the button's trait's data and prepare the tooltip strings
    void updateTooltip()
    {
        //if the button is interactable, prepare the tooltip to reflect an active trait
        if (this.button.interactable)
        {
            
            tooltipName = trait.traitName + ": " + trait.rank + "/" + trait.maxRanks;
            tooltipCost = "Cost: " + trait.cost;
            tooltipDesc = trait.traitDescription;
        }
        else
        {
            //if the trait is at max ranks, prepare the tooltip to show that
            //since it is at max rank, it no longer shows a cost
            if (trait.rank == trait.maxRanks)
            {
                tooltipName = trait.traitName + ": " + trait.rank + "/" + trait.maxRanks;
                tooltipDesc = trait.traitDescription;
            }
            else
            {
                //if its not interactable and its not at max ranks, then it must be disabled
                //make the tooltip reflect the fact that the trait is disabled
                tooltipName = trait.traitName + "-- DISABLED";
                tooltipDesc = "WIP Coming soon";
            }
        }
    }


    //this function works to try to increase a traits rank when the button is clicked
    public void increaseTrait()
    {
        //if the trait isnt at max rank and we have enough tokens
        //spend tokens equal to the traits cost
        //add a rank to the trait
        //update the tooltip
        //inform the user via the purchase text
        if (trait.rank < trait.maxRanks && Tokens.tokens >= trait.cost)
        {
            tokens.spendTokens(trait.cost);
            trait.addRank();
            updateTooltip();
            purchase.color = new Color(1f, 1f, 1f, 1f);
            purchase.text = "-- PURCHASE COMPLETE --\nYou purchased: "+trait.traitName;
            Invoke("purchaseTextFade", 5f);
        }
        //in all other cases, inform the player that the purchase didnt go through
        else
        {
            purchase.color = new Color(1f, 0f, 0f, 1f);
            purchase.text = "-- INVALID PURCHASE --\nYOU CAN'T AFFORD THAT";
            Invoke("purchaseTextFade", 5f);
        }
    }

    public void purchaseTextFade()
    {
        purchase.CrossFadeAlpha(0.0f, 1f, true);
    }
}
