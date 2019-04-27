using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour {

    protected GameManager gm;
    protected Collider2D myCollider;
    protected SpriteRenderer sr;
    protected Animator anim;

    internal const int NORTH = 1;
    internal const int EAST = 2;
    internal const int SOUTH = 4;
    internal const int WEST = 8;

    internal const int PICKUP_MASK = ~(1 << 8);

    protected bool is_moving = false;
    protected bool is_etheral = false;

    protected Vector3 move_goal;

    // Use this for initialization
    public virtual void Start () {
        gm = FindObjectOfType<GameManager>();
        myCollider = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        HandleMove();
    }

    protected void AttemptMove(int dir) {
        if(is_moving) {
            return;
        }

        if(!is_etheral && !CheckMove(dir)) {
            return;
        }

        is_moving = true;
        move_goal = GetEndPoint(transform.position, dir);
        HandleMove();
    }

    protected bool CheckMove(int dir) {
        myCollider.enabled = false;

        Vector3 origin_point = transform.position;
        Vector3 end_point = GetEndPoint(origin_point, dir);

        Transform tr = ColliderCheck(origin_point, end_point);

        myCollider.enabled = true;
        if(!tr || tr == null) {
            return true;
        }
        Collider2D hit_collider = tr.GetComponent<Collider2D>();
        return hit_collider.isTrigger;
    }

    Transform ColliderCheck(Vector3 origin_point, Vector3 end_point) {
        RaycastHit2D hit;
        hit = Physics2D.Linecast(origin_point, end_point, PICKUP_MASK);
        return hit.transform;
    }

    Vector3 GetEndPoint(Vector3 origin_point, int dir) {
        Vector3 end_point = origin_point;
        switch(dir) {
            case NORTH:
                end_point += Vector3.up;
                break;
            case EAST:
                end_point += Vector3.right;
                break;
            case SOUTH:
                end_point += Vector3.down;
                break;
            case WEST:
                end_point += Vector3.left;
                break;
        }
        return end_point;
    }

    protected virtual void HandleMove() {
        if(!is_moving) {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, move_goal, Time.deltaTime * 2.5f);
        if(transform.position == move_goal) {
            is_moving = false;
            return;
        }
    }

    public virtual void GetHurt() {
        return;
    }
}
