using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    // Start is called before the first frame update
    void Start()
    {
        canvasUsed = GameObject.Find("Canvas");
        myRB2D = gameObject.GetComponent<Rigidbody2D>();
        Player_Control = new PlayerAction();

        Player_Control.KeyBoard.Jump.performed += _ => Jump();
        Player_Control.KeyBoard.Movement.performed += ctx => InputDirection = ctx.ReadValue<Vector2>();
        Player_Control.KeyBoard.Movement.canceled += ctx => InputDirection = Vector2.zero;
        coroutine = WaitAndPrint(2.0f, null);
        Player_Control.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        if(grounded)
        {
            Mouvement();
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
