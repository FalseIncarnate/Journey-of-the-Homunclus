using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padded_Shoes : TriggerObject {

    // Use this for initialization
    protected override void Start() {
        base.Start();
        is_pickup = true;
        purchase_cost = 2;
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
        gm.ui.UpdateShopText("Padded_Shoes", purchase_cost);
    }

    public override void OnPurchase() {
        gm.padded_shoes++;
        gm.AdjustHP(purchase_cost * -1);
        gm.ui.UpdateStats();
    }
}
