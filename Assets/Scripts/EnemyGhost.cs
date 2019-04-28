using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : EnemyControl {

    // Use this for initialization
    public override void Start() {
        base.Start();
        is_etheral = true;
        has_moveAnim = false;
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();
    }

    protected override void seekPlayer() {
        Transform playerTarget = FindObjectOfType<PlayerControl>().transform;
        if(!playerTarget) {
            RandomMove();
            return;
        }
        int difX = (int)Mathf.Abs(transform.position.x - playerTarget.position.x);
        int difY = (int)Mathf.Abs(transform.position.y - playerTarget.position.y);
        //Ghosts have infinite sight range so they don't wander out of bounds and get lost/inaccessible
        if(difX > 0 && (difY > difX || difY == 0)) {
            if(transform.position.x < playerTarget.position.x) {
                AttemptMove(EAST);
            } else {
                AttemptMove(WEST);
            }
        } else {
            if(transform.position.y < playerTarget.position.y) {
                AttemptMove(NORTH);
            } else {
                AttemptMove(SOUTH);
            }
        }
    }

    protected override void DoMoveAnim() {
        return;
    }
}