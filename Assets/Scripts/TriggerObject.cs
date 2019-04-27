using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour {

    protected GameManager gm;

    internal const int PICKUP_MASK = ~(1 << 8);

    protected bool is_pickup = false;

    public bool active_trigger = false;
    protected bool requires_reset = false;

    public bool player_trigger = false;

    protected int reset_counter = 0;
    internal const int RESET_RATE = 10;

	// Use this for initialization
	protected virtual void Start () {
        gm = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!active_trigger) {
            return;
        }
        reset_counter++;
        if(reset_counter == RESET_RATE) {
            CheckTrigger();
            reset_counter = 0;
        }
	}

    public virtual void GetTriggered() {
        if(!active_trigger) {
            CheckTrigger();
            return;
        }
    }

    protected void CheckTrigger() {
        GameObject target = GetTriggerTarget();
        if(target) {
            if(target.CompareTag("Player")){
                player_trigger = true;
            }
            active_trigger = true;
            return;
        }
        ResetTrigger();
    }

    protected GameObject GetTriggerTarget() {
        GameObject target;
        RaycastHit2D hit;
        Vector3 origin_point = transform.position;
        hit = Physics2D.Linecast(origin_point, origin_point, PICKUP_MASK);
        if(!hit) {
            return null;
        }
        target = hit.transform.gameObject;
        return target;
    }

    protected virtual void DoPlayerTrigger() {
        return;
    }

    protected virtual void DoEnemyTrigger() {
        return;
    }

    protected void ResetTrigger() {
        active_trigger = false;
        player_trigger = false;
        requires_reset = false;
    }
}
