using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameOver : MonoBehaviour {

    public Text hintText;

	// Use this for initialization
	void Start () {
        hintText.text = pickHint();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MainMenu() {
        SceneManager.LoadScene("mainMenu");
    }

    public void QuitGame() {
        Application.Quit();
    }

    string pickHint() {
        string[] hintArray = new string[15];
        hintArray[0] = "Enemies aren't affected by black ring pickups, but you are!";
        hintArray[1] = "Enemies will try to move horizontally before vertically.";
        hintArray[2] = "Each Orb Max Up increases your max health by 5, to a maximum of 20 health.";
        hintArray[3] = "Each Vampire Teeth increases the chance enemies you kill will drop health by 2% to a maximum of 50%";
        hintArray[4] = "Each Parry Sword increases the chance you counter-kill enemies by 5%.";
        hintArray[5] = "Surrounded by enemies? Bait them into colliding with each other to thin their numbers!";
        hintArray[6] = "The one who moves first, strikes first. Take the fight to the enemy and emerge victorious!";
        hintArray[7] = "Padded Shoes protect you from being hurt by spikes, but only once per set. Use them wisely!";
        hintArray[8] = "Each Vision Down reduces enemy vision range, meaning they won't try to follow you from as far";
        hintArray[9] = "Each Vision Up increases enemy vision range, making them less likely to lose track of you.";
        hintArray[10] = "Starting with level 5, every 5th level will be a shop where you can purchase upgrades.";
        hintArray[11] = "Spikes will only hurt something when it steps on them. Standing on them won't hurt until you move off.";
        hintArray[12] = "Each health pickup grants 1 health when collected. If you are at full health already, you won't collect it.";
        hintArray[13] = "Sometimes you need to sacrifice a bit of health to reach your goals.";
        hintArray[14] = "Make sure to explore your surroundings fully in case you missed some health pickups!";
        int index = (int)Random.Range(0, hintArray.Length);
        while(index == 15) {
            index = (int)Random.Range(0, hintArray.Length);
        }
        return hintArray[index];
    }

}
