using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire_Teeth : TriggerObject
{

    // Use this for initialization
    protected override void Start() {
        base.Start();
        is_pickup = true;
        purchase_cost = 8;
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
        gm.ui.UpdateShopText("Vampire_Teeth", purchase_cost);
    }

    public override void OnPurchase() {
        gm.UpdateVampire(2);
        gm.AdjustHP(purchase_cost * -1);
        gm.ui.UpdateStats();
    }
}
