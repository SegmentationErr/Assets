using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{
    public float moveTime = 0.1f;
    public LayerMask blockingLayer;

    private CircleCollider2D circleCollider;
    //private BoxCollider2D boxCollier;
    private Rigidbody2D rb2D;
    private float inverseMoveTime;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        inverseMoveTime = 1f / moveTime;
    }
    
    protected bool Move(int xDir, int yDir, out RaycastHit2D hit)
    {
        //print("MovingObject: Move");
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

        circleCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        circleCollider.enabled = true;
        if(hit.transform == null)
        {
            StartCoroutine(SmoothMovement(end));
            //Vector2 movement = new Vector2(xDir, yDir);
            //rb2D.MovePosition(rb2D.position + movement * 7 * Time.fixedDeltaTime);
            //Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
            //rb2D.MovePosition(newPosition);
            return true; 
        }
        return false;
    }

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        while (sqrRemainingDistance > float.Epsilon)
        {
            int i = 0; print(sqrRemainingDistance + "MovingObject: SmoothMovement" + i++); 
            Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
            rb2D.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            print(sqrRemainingDistance + "MovingObject: SmoothMovement" + i++);
            yield return null;
            //yield return new WaitForSeconds(1f);
        }
    }

    protected virtual void AttempMove<T>(int xDir, int yDir)
        where T : Component
    {
        RaycastHit2D hit;

        bool canMove = Move(xDir, yDir, out hit);

        if (hit.transform == null)
            return;

        T hitComponent = hit.transform.GetComponent<T>();

        if (!canMove && hitComponent != null)
            OnCantMove(hitComponent);
    }

    protected abstract void OnCantMove<T>(T component)
        where T : Component;
}
