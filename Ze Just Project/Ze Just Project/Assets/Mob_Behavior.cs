using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_Behavior : MonoBehaviour
{
    public int direction;// 0 = Left; 1 = Right
    public Rigidbody2D myRB2D;
    public float speed;
    public float tempsAvantProchainSaut;
    public float tempsMaxEntreSaut;
    public float tempsEcouleSaut;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        //direction = Random.Range(0, 2);
        myRB2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Mouvement();
        if(tempsEcouleSaut < tempsAvantProchainSaut)
        {
            tempsEcouleSaut += Time.deltaTime;

        }
        else
        {

            Jump();
        }
    }

    public void Mouvement()
    {

        if(direction == 0)
        {
            myRB2D.velocity = new Vector2(1 * speed, myRB2D.velocity.y);
        }
        else
        {
            myRB2D.velocity = new Vector2(-1 * speed, myRB2D.velocity.y);
        }
        //Mathf.Clamp
    }

    public void Jump()
    {
        tempsEcouleSaut = 0;
        tempsAvantProchainSaut = Random.Range(0.5f, tempsMaxEntreSaut);
        myRB2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(myRB2D.velocity.x, myRB2D.velocity.y, 0));
    }
}
