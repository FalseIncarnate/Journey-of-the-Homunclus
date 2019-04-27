using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_Max_Up : TriggerObject
{

    // Use this for initialization
    protected override void Start() {
        base.Start();
        is_pickup = true;
        purchase_cost = 4;
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
        gm.ui.UpdateShopText("Orb_Max_Up", purchase_cost);
    }

    public override void OnPurchase() {
        gm.UpdateMax(5);
        gm.AdjustHP(purchase_cost * -1);
    }
}
