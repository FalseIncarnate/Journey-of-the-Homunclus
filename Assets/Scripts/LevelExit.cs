using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : TriggerObject {

    public Sprite INACTIVE_SPRITE;
    public Sprite ACTIVE_SPRITE;

    protected int check_counter = 0;
    protected const int CHECK_RATE = 60;

    protected SpriteRenderer sr;

    // Use this for initialization
    protected override void Start() {
        base.Start();
        sr = GetComponent<SpriteRenderer>();
    }

    protected override void Update() {
        base.Update();
        check_counter++;
        if(check_counter == CHECK_RATE) {
            if(gm.enemies_left == 0) {
                sr.sprite = ACTIVE_SPRITE;
            } else {
                sr.sprite = INACTIVE_SPRITE;
            }
            check_counter = 0;
        }
    }

    public override void GetTriggered() {
        base.GetTriggered();
        if(player_trigger) {
            DoPlayerTrigger();
        } else {
            DoEnemyTrigger();
        }
    }

    protected override void DoPlayerTrigger() {
        if(gm.enemies_left == 0) {
            gm.LevelUp();
        }
    }

    protected override void DoEnemyTrigger() {
        return;
    }
}
