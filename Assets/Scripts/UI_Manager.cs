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
        HP_2.sprite = HEALTH_BLANK;
        HP_3.sprite = HEALTH_BLANK;
        HP_4.sprite = HEALTH_BLANK;
        
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
}
