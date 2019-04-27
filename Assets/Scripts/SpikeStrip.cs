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
            gm.AdjustHP(-1);
            requires_reset = true;
        }
    }

    protected override void DoEnemyTrigger() {
        if(!requires_reset) {
            GameObject target = GetTriggerTarget();
            Destroy(target);
            requires_reset = true;
        }
    }
}
