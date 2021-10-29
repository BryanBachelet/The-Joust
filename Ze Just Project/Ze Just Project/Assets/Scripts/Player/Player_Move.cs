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
    public bool grounded = false;
    public bool isJumped = false;
    // Start is called before the first frame update
    void Start()
    {
        canvasUsed = GameObject.Find("Canvas");
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
    void Update()
    {
        if(grounded)
        {
            Mouvement();
        }
        
        if(isJumped)
        {
            Jump();
            isJumped = false;
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
        if(collision.gameObject.tag == "Plateform")
        {
            Vector3 center = this.GetComponent<Collider2D>().bounds.center;

          //  Debug.Log((collision.transform.position.y + collision.collider.bounds.extents.y) + "//" + (center.y - transform.position.y));
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
        
        myRB2D.velocity = new Vector2(Mathf.Clamp(myRB2D.velocity.x, -5, 5), myRB2D.velocity.y);
        if(Mathf.Sign(myRB2D.velocity.x) >= 0)
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
        myRB2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    private IEnumerator WaitAndPrint(float waitTime, GameObject textToDestroy)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(textToDestroy);
    }

    public void ChangeDirection()
    {
        if(direction == 0)
        {
            direction = 1;


        }
        else if (direction == 1)
        {
            
            direction = 0;

        }
    }

}
