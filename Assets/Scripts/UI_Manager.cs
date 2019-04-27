using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    protected GameManager gm;

    public Sprite HEALTH_0;
    public Sprite HEALTH_1;
    public Sprite HEALTH_2;
    public Sprite HEALTH_3;
    public Sprite HEALTH_4;
    public Sprite HEALTH_BLANK;

    public Image HP_1;
    public Image HP_2;
    public Image HP_3;
    public Image HP_4;

    public Text levelText;

    // Use this for initialization
    void Start () {
        gm = FindObjectOfType<GameManager>();
        UpdateHP();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateHP() {

        HP_1.sprite = HEALTH_BLANK;
        if(HP_2.isActiveAndEnabled) {
            HP_2.sprite = HEALTH_BLANK;
        }
        if(HP_3.isActiveAndEnabled) {
            HP_3.sprite = HEALTH_BLANK;
        }
        if(HP_4.isActiveAndEnabled) {
            HP_4.sprite = HEALTH_BLANK;
        }

        if(gm.player_HP > 15) {
            HP_1.sprite = HEALTH_4;
            HP_2.sprite = HEALTH_4;
            HP_3.sprite = HEALTH_4;
            switch(gm.player_HP) {
                case 20:
                    HP_4.sprite = HEALTH_4;
                    break;
                case 19:
                    HP_4.sprite = HEALTH_3;
                    break;
                case 18:
                    HP_4.sprite = HEALTH_2;
                    break;
                case 17:
                    HP_4.sprite = HEALTH_1;
                    break;
                case 16:
                    HP_4.sprite = HEALTH_0;
                    break;
            }
        }else if(gm.player_HP > 10) {
            HP_1.sprite = HEALTH_4;
            HP_2.sprite = HEALTH_4;
            switch(gm.player_HP) {
                case 15:
                    HP_3.sprite = HEALTH_4;
                    break;
                case 14:
                    HP_3.sprite = HEALTH_3;
                    break;
                case 13:
                    HP_3.sprite = HEALTH_2;
                    break;
                case 12:
                    HP_3.sprite = HEALTH_1;
                    break;
                case 11:
                    HP_3.sprite = HEALTH_0;
                    break;
            }
        } else if(gm.player_HP > 5) {
            HP_1.sprite = HEALTH_4;
            switch(gm.player_HP) {
                case 10:
                    HP_2.sprite = HEALTH_4;
                    break;
                case 9:
                    HP_2.sprite = HEALTH_3;
                    break;
                case 8:
                    HP_2.sprite = HEALTH_2;
                    break;
                case 7:
                    HP_2.sprite = HEALTH_1;
                    break;
                case 6:
                    HP_2.sprite = HEALTH_0;
                    break;
            }
        } else {
            switch(gm.player_HP) {
                case 5:
                    HP_1.sprite = HEALTH_4;
                    break;
                case 4:
                    HP_1.sprite = HEALTH_3;
                    break;
                case 3:
                    HP_1.sprite = HEALTH_2;
                    break;
                case 2:
                    HP_1.sprite = HEALTH_1;
                    break;
                case 1:
                    HP_1.sprite = HEALTH_0;
                    break;
            }
        }
    }

    public void UpdateLevelText() {
        switch(gm.level) {
            case 0:
                levelText.text = "Move with W, A, S, D." + "\n" + "Make your way to the exit in the lower right to proceed.";
                break;
            case 1:
                levelText.text = "Picking up red orbs grant health, but black rings steal it!" + "\n" + "You current health is represented by the orbs in the top left.";
                break;
            case 2:
                levelText.text = "Spikes hurt you each time you step on them. Watch your step!" + "\n" + "Run out of health and it is game over!";
                break;
            case 3:
                levelText.text = "Enemies will try to follow you if they see you, but aren't too smart." + "\n" + "You must get rid of all enemies to open the exit.";
                break;
            case 4:
                levelText.text = "Sometimes you need to sacrifice your own health to lure an enemy." + "\n" + "If they lose sight of you, they'll wander randomly!";
                break;
            case 5:
                levelText.text = "Welcome to the shop! You can trade your health for stuff!" + "\n" + "Step on an item for more info, and press E to buy!";
                break;
            case 6:
                levelText.text = "Fighting enemies is risky, you might get hurt!!" + "\n" + "But if you can lure two enemies together, they'll fight each other!";
                break;
            default:
                levelText.text = "";
                break;
        }
    }

    public void UpdateShopText(string thing, int cost) {
        switch(thing) {
            case "Vision_Up":
                levelText.text = "Vision Up: Makes enemies able to see you from further away!" + "\n" + "Costs " + cost + " health.";
                break;
            case "Vision_Down":
                levelText.text = "Vision Down: Reduces the range enemies can see you from." + "\n" + "Costs " + cost + " health.";
                break;
            case "Orb_Max_Up":
                levelText.text = "Orb Max Up: Increases your max health by adding a new orb." + "\n" + "Costs " + cost + " health.";
                break;
        }
    }
}
