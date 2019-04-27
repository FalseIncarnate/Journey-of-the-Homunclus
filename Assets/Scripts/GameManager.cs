using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public UI_Manager ui;
    public PlayerControl pc;

    public int player_HP = 1;
    public int player_MAX = 5;

    internal const int HP_MAX_LIMIT = 20;

    public int enemies_left = 0;
    public int level = 1;

    public int sightMod = 0;
    public int parry_chance = 5;

    public GameObject[] levelArray = new GameObject[15];

    protected GameObject cur_level;

	// Use this for initialization
	void Start () {
        ui = FindObjectOfType<UI_Manager>();
        pc = FindObjectOfType<PlayerControl>();
        ui.UpdateHP();

        cur_level = Instantiate(levelArray[level]);
        ui.UpdateLevelText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool AdjustHP(int amt) {
        if(player_HP + amt > player_MAX) {
            if(player_HP == player_MAX) {
                return false;
            }
            player_HP = player_MAX;
            return true;
        }
        player_HP = Mathf.Max(0, player_HP + amt);
        player_HP = Mathf.Min(player_HP, player_MAX);
        ui.UpdateHP();
        if(amt < 0) {
            pc.GetHurt();
        }
        if(player_HP <= 0) {
            GameOver();
        }
        return true;
    }

    public void UpdateMax(int amt) {
        player_MAX += amt;
        Mathf.Min(player_MAX, HP_MAX_LIMIT);
        if(player_MAX > 15) {
            ui.HP_4.gameObject.SetActive(true);
            ui.HP_4.enabled = true;
        }
        if(player_MAX > 10) {
            ui.HP_3.gameObject.SetActive(true);
            ui.HP_3.enabled = true;
        }
        if(player_MAX > 5) {
            ui.HP_2.gameObject.SetActive(true);
            ui.HP_2.enabled = true;
        }
        ui.UpdateHP();
    }

    public void UpdateVision(int amt) {
        sightMod += amt;
    }

    public void UpdateParry(int amt) {
        parry_chance += amt;
    }

    public void LevelUp() {
        Destroy(cur_level);
        level++;
        cur_level = Instantiate(levelArray[level]);
        pc.move_goal = Vector3.zero;
        pc.transform.position = Vector3.zero;
        ui.UpdateLevelText();
    }

    void GameOver() {
        Application.Quit();
    }
}
