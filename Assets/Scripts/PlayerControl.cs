using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerControl : MoveableObject
{



    // Use this for initialization
    public override void Start() {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();
        if(Input.GetKey("w")) {
            AttemptMove(NORTH);
        }
        if(Input.GetKey("a")) {
            AttemptMove(WEST);
        }
        if(Input.GetKey("s")) {
            AttemptMove(SOUTH);
        }
        if(Input.GetKey("d")) {
            AttemptMove(EAST);
        }
    }

    protected override void HandleMove() {
        base.HandleMove();
        AttemptPickup();
    }

    void AttemptPickup() {
        RaycastHit2D hit;
        Vector3 origin_point = transform.position;
        hit = Physics2D.Linecast(origin_point, origin_point, ~PICKUP_MASK);
        if(hit && hit.collider.isTrigger) {
            hit.transform.gameObject.GetComponent<TriggerObject>().GetTriggered();
        }
        
    }
}
