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
        if(!requires_reset) {
            gm.AdjustHP(-1);
            requires_reset = true;
        }
    }
}
