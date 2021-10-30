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
    public float forceReturn = 3;
    public GameObject myBody;

    public enum DirectionContact
    {
        UP, RIGHT, DOWN, LEFT, NONE,
    };
    public DirectionContact directionContact = DirectionContact.NONE;
    // Start is called before the first frame update
    void Start()
    {
        //direction = Random.Range(0, 2);
        myRB2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Mouvement();
        if (tempsEcouleSaut < tempsAvantProchainSaut)
        {
            tempsEcouleSaut += Time.deltaTime;

        }
        else
        {
            Jump();
        }
        if (transform.position.y < -2.65f)
        {
            Jump();
        }

        if (transform.position.x > 6.95f)
        {
            transform.position = new Vector3(-6.90f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -6.95f)
        {
            transform.position = new Vector3(6.90f, transform.position.y, transform.position.z);
        }
    }

    public void Mouvement()
    {

        if(direction == 0)
        {
            myRB2D.velocity = new Vector2(myRB2D.velocity.x + 1 * speed * Time.deltaTime, myRB2D.velocity.y);
        }
        else
        {
            myRB2D.velocity = new Vector2(myRB2D.velocity.x + -1 * speed * Time.deltaTime, myRB2D.velocity.y);
        }
        myRB2D.velocity = new Vector2(Mathf.Clamp(myRB2D.velocity.x, -3, 3), myRB2D.velocity.y);
        if (Mathf.Sign(myRB2D.velocity.x) >= 0)
        {
            myBody.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            myBody.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        //Mathf.Clamp
    }

    public void Jump()
    {
        tempsEcouleSaut = 0;
        tempsAvantProchainSaut = Random.Range(0.2f, tempsMaxEntreSaut);
        myRB2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(myRB2D.velocity.x, myRB2D.velocity.y, 0));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.tag == "Plateform")
        {
            Vector2 contactPosition = collision.GetContact(0).point;
            BoxCollider2D platformCollider = collision.gameObject.GetComponent<BoxCollider2D>();
            Vector2 normalContact = collision.GetContact(0).normal;

            // CompareAxisCoordoonee(platformCollider, contactPosition);

            CheckNormalContactPoint(contactPosition, normalContact);

        }


    }

    void CheckNormalContactPoint(Vector2 contactPosition, Vector2 normalContact)
    {
        Debug.Log("Debug normal " + normalContact.normalized);
        Debug.DrawRay(contactPosition, normalContact.normalized * 10.0f, Color.green);

        if (normalContact.y == 1)
        {
            directionContact = DirectionContact.UP;


        }
        if (normalContact.y == -1)
        {
            directionContact = DirectionContact.DOWN;
            ReturnForce(normalContact, 0.5f);


        }
        if (normalContact.x == 1)
        {
            directionContact = DirectionContact.RIGHT;
            ReturnForce(normalContact, 1);
        }
        if (normalContact.x == -1)
        {
            directionContact = DirectionContact.LEFT;
            ReturnForce(normalContact, 1);
        }
        return;


    }

    public void ReturnForce(Vector2 dir, float multipleBy)
    {

        myRB2D.AddForce(dir.normalized * forceReturn * multipleBy, ForceMode2D.Impulse);

    }
}
