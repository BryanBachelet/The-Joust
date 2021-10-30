using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformCollision : MonoBehaviour
{
    public float forceProject = 5;
    float RectWidth;
    float RectHeight;
    Vector3 center;
    // Sta RectHeightrt is called before the first frame update
    void Start()
    {
        RectWidth = this.GetComponent<Collider2D>().bounds.extents.x;
        RectHeight = this.GetComponent<Collider2D>().bounds.extents.y;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        if (collision.gameObject.tag == "Player")
        {

            bool collideFromLeft;
            bool collideFromTop;
            bool collideFromRight;
            bool collideFromBottom;

            Vector3 centerPlayer = collision.collider.bounds.extents;
            Vector3 contactPoint = collision.contacts[0].point;
            center = this.GetComponent<Collider2D>().bounds.center;
            float circleRad = collider.bounds.extents.x;
            //Debug.Log(collider.transform.position.y + "//" + (center.y + RectHeight));
            if (collider.transform.position.y - centerPlayer.y > (center.y + RectHeight))
            {
                collideFromTop = true;
              ///  collision.gameObject.GetComponent<Player_Move>().grounded = true;
                Debug.Log("FromMyTop");

            }
            if (contactPoint.x > center.x + RectWidth / 2 && contactPoint.y < center.y + RectHeight / 2 && contactPoint.y > center.y - RectHeight / 2)
            {
                collideFromLeft = true;
                //collision.gameObject.GetComponent<Player_Move>().grounded = false;
                Debug.Log("FromLeft");
                collider.gameObject.GetComponent<Rigidbody2D>().AddForce(collider.gameObject.GetComponent<Player_Move>().direction * forceProject * new Vector3(1, 0, 0), ForceMode2D.Impulse);
                //collision.gameObject.GetComponent<Player_Move>().ChangeDirection();
            }
            if (contactPoint.x < center.x + RectWidth / 2 && contactPoint.y < center.y + RectHeight / 2 && contactPoint.y > center.y - RectHeight / 2)
            {
                collideFromRight = true;
                //collision.gameObject.GetComponent<Player_Move>().grounded = false;
                Debug.Log("FromMyRight");
                collider.gameObject.GetComponent<Rigidbody2D>().AddForce(-collider.gameObject.GetComponent<Player_Move>().direction * forceProject * new Vector3(1, 0, 0), ForceMode2D.Impulse);

                //collision.gameObject.GetComponent<Player_Move>().ChangeDirection();
            }
            if (transform.position.y + transform.localScale.y < center.y - RectHeight)
            {
                collideFromTop = true;
                Debug.Log("FromMyBottom");

            }

        }
    }
}
