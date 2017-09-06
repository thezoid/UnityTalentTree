using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour {
    public void gtl(int stage)
    {
        TraitManager.manager.saveTraits(TraitManager.manager.traits);
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().save();
        SceneManager.LoadScene(stage);
    }
}
