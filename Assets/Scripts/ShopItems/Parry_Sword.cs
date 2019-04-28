using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry_Sword : TriggerObject {

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
        gm.ui.UpdateShopText("Parry_Sword", purchase_cost);
    }

    public override void OnPurchase() {
        gm.UpdateParry(5);
        gm.AdjustHP(purchase_cost * -1);
        gm.ui.UpdateStats();
    }
}
