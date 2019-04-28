using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeStrip : TriggerObject {

    // Use this for initialization
    protected override void Start() {
        base.Start();
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
        if(!requires_reset) {
            if(gm.padded_shoes > 0) {
                gm.padded_shoes--;
                gm.ui.UpdateStats();
            } else {
                gm.AdjustHP(-1);
            }
            requires_reset = true;
        }
    }

    protected override void DoEnemyTrigger() {
        if(!requires_reset) {
            GameObject target = GetTriggerTarget();
            target.GetComponent<EnemyControl>().GetHurt();
            requires_reset = true;
        }
    }
}
