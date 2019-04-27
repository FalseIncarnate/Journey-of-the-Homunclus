using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyControl : MoveableObject {

    protected int move_counter = 0;
    protected const int MOVE_RATE = 60;

    // Use this for initialization
    public override void Start() {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();
        if(is_moving) {
            anim.SetTrigger("enemyMoving");
        }
        move_counter++;
        if(move_counter == MOVE_RATE) {
            int rand_dir = (int)Random.Range(1, 6);
            if(rand_dir < 5) {
                AttemptMove(rand_dir);
            }
            move_counter = 0;
        }
        
    }

    protected override void HandleMove() {
        base.HandleMove();
        Trigger();
    }

    void seekPlayer() {
        
    }
}
