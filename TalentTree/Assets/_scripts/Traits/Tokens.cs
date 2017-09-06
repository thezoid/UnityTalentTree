using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Tokens : MonoBehaviour {

    public int tokens; //the number of tokens saved; tokens are a generic name for skill points, or whatever themed currency you would like to use for your talents
    public Text tokenText; //the text showing how many tokens you have

    public static Tokens manager;

    private void Awake()
    {
        //PERSISTENCE
        //there can only ever be one TraitManager
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
        //PERSISTENCE

        //when the token object awakes, load the tokens number from playerprefs
        tokens = PlayerPrefs.GetInt("tokens");
        //also find the tokenText object
        tokenText = GameObject.FindGameObjectWithTag("tokenText").GetComponent<Text>();
    }

    //this function decrements our tokens and then saves the value to playerprefs
    public void spendTokens(int x)
    {
        tokens -= x;
        PlayerPrefs.SetInt("tokens", tokens);
    }

    public void Update()
    {
        tokens = tokens < 0 ? 0 : tokens; //this conditional expression will, per frame, set the tokens to 0 or their current value, this stops us from getting negative tokens
        tokenText.text = "Skill Points Remaining: " + tokens; //update the text showing how many skill points are left, per frame
    }
}
