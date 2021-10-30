using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player_Move : MonoBehaviour
{
    public int myScoreValue;
    public GameObject canvasUsed;
    public GameObject textAdd_GO;
    public Color myColor;
    public float speed;
    public float jumpForce;
    public Rigidbody2D myRB2D;
    public GameObject myBody;

    private IEnumerator coroutine;
    public PlayerAction Player_Control;
    public Vector2 InputDirection;
    public int direction; // 0 = Left; 1 = Right
    public bool grounded = true;
    public bool isJumped = false;
    public LayerMask layerMask;
    public float forceReturn = 3;
    public GameObject oeufPrefab;
    public float forceProjectionOeuf;

    public Animator myAnimator;
    public static int indexPlayer;
    // Start is called before the first frame update
    void Start()
    {
        indexPlayer++;
        myAnimator = GetComponentInChildren<Animator>();
        canvasUsed = GameObject.Find("Canvas");
        Camera.main.GetComponent<Manager_Score>().playerScript.Add(this.GetComponent<Player_Move>());
        myRB2D = gameObject.GetComponent<Rigidbody2D>();

        coroutine = WaitAndPrint(2.0f, null);

    }

    public void onMove(InputAction.CallbackContext context)
    {
        InputDirection = context.ReadValue<Vector2>();
    }

    public void onJump(InputAction.CallbackContext context)
    {
        //isJumped  = context.ReadValue<bool>();
        isJumped = context.action.triggered;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (grounded)
        {
            Mouvement();
        }

        if (isJumped)
        {
            Jump();
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.down * 0.40f,Color.red);
            if (Physics2D.Raycast(transform.position, Vector2.down, 0.40f, layerMask))
            {
                if (myAnimator.GetBool("Flying") == true)
                {
                    myAnimator.SetBool("Flying", false);
                }
                grounded = true;
            }

        }
        if(transform.position.x > 6.95f)
        {
            transform.position = new Vector3(-6.90f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -6.95f)
        {
            transform.position = new Vector3(6.90f, transform.position.y, transform.position.z);
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Oeuf")
        {
            Destroy(collision.gameObject);
            GameObject textScore = Instantiate(textAdd_GO, transform.position, Quaternion.identity, canvasUsed.transform);
            Text textScoreText = textScore.GetComponent<Text>();
            //textScoreText.rectTransform.localPosition = Camera.main.WorldToScreenPoint(transform.position);
            textScore.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(1.5f, 0.25f, 0));
            //textScore.transform.localPosition = transform.position;
            textScoreText.text = "" + 250;
            textScoreText.color = myColor;
            coroutine = WaitAndPrint(2.0f, textScore);
            StartCoroutine(coroutine);
            myScoreValue += 250;
        }
        if (collision.gameObject.tag == "Plateform")
        {
            Vector3 center = this.GetComponent<Collider2D>().bounds.center;

            //  Debug.Log((collision.transform.position.y + collision.collider.bounds.extents.y) + "//" + (center.y - transform.position.y));
        }
        if(collision.gameObject.tag == "Mob")
        {
            if(transform.position.y > collision.transform.position.y)
            {
                GameObject oeufInstant = Instantiate(oeufPrefab, collision.transform.position, Quaternion.identity);
                Vector2 rndDir = Random.insideUnitCircle * 1;
                oeufInstant.GetComponent<Rigidbody2D>().AddForce(rndDir * forceProjectionOeuf, ForceMode2D.Impulse);
                Destroy(collision.gameObject);


            }
        }
    }

    public void Mouvement()
    {
        if (grounded)
        {
            if (direction == 0)
            {
                myRB2D.velocity = new Vector2(myRB2D.velocity.x + InputDirection.x * 1 * speed * Time.deltaTime, myRB2D.velocity.y);

            }
            else
            {
                myRB2D.velocity = new Vector2(myRB2D.velocity.x + InputDirection.x * -1 * speed, myRB2D.velocity.y);

            }
        }

        if(myRB2D.velocity != Vector2.zero)
        {
            
            if(myAnimator.GetBool("Running") == false && myAnimator.GetBool("Flying") == false )
            {
                myAnimator.SetBool("Running", true);
            }

        }
        else
        {
            if (myAnimator.GetBool("Running") == true)
            {
                myAnimator.SetBool("Running", false);
            }
        }
        myRB2D.velocity = new Vector2(Mathf.Clamp(myRB2D.velocity.x, -5, 5), myRB2D.velocity.y);
        if (Mathf.Sign(myRB2D.velocity.x) >= 0)
        {
            myBody.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            myBody.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        
    }

    public void Jump()
    {
        myRB2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        if(myAnimator.GetBool("Flying") == false)
        {
            myAnimator.SetBool("Flying", true);
            myAnimator.SetBool("Running", false);
        }
        else
        {
            myAnimator.SetBool("Flying", false);
            myAnimator.SetBool("Flying", true);
        }
        isJumped = false;
        if(!grounded)
        {
            grounded = true;
        }
        //grounded = false;
    }

    public void ReturnForce(Vector2 dir, float multipleBy)
    {

            myRB2D.AddForce(dir.normalized  * forceReturn * multipleBy, ForceMode2D.Impulse);

    }
    private IEnumerator WaitAndPrint(float waitTime, GameObject textToDestroy)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(textToDestroy);
    }

    public void ChangeDirection()
    {
        if (direction == 0)
        {
            direction = 1;


        }
        else if (direction == 1)
        {

            direction = 0;

        }
    }

}
