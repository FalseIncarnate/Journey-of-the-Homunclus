using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public UI_Manager ui;

    public int player_HP = 1;
    public int player_MAX = 5;

	// Use this for initialization
	void Start () {
        ui = FindObjectOfType<UI_Manager>();
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
        if(player_HP <= 0) {
            GameOver();
        }
        return true;
    }

    void GameOver() {

    }
}
