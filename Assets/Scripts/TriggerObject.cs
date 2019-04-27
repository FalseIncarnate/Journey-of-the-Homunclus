using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour {

    protected GameManager gm;

    internal const int PICKUP_MASK = ~(1 << 8);

    protected bool is_pickup = false;

    public bool active_trigger = false;
    protected bool requires_reset = false;

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
        if(is_pickup) {
            return;
        }
        if(!active_trigger) {
            active_trigger = true;
            return;
        }
    }

    protected void CheckTrigger() {
        RaycastHit2D hit;
        Vector3 origin_point = transform.position;
        hit = Physics2D.Linecast(origin_point, origin_point, PICKUP_MASK);
        if(hit) {
            MoveableObject mo = hit.transform.gameObject.GetComponent<MoveableObject>();
            if(mo) {
                return;
            }
        }
        ResetTrigger();
    }

    protected void ResetTrigger() {
        active_trigger = false;
        requires_reset = false;
    }
}
