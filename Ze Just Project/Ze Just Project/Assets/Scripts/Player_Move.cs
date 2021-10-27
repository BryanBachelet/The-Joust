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

    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        canvasUsed = GameObject.Find("Canvas");
        coroutine = WaitAndPrint(2.0f, null);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Oeuf")
        {
            Destroy(collision.gameObject);
            GameObject textScore = Instantiate(textAdd_GO, transform.position, Quaternion.identity, canvasUsed.transform);
            Text textScoreText = textScore.GetComponent<Text>();
            //textScoreText.rectTransform.localPosition = Camera.main.WorldToScreenPoint(transform.position);
            textScore.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(1.5f,0.25f,0));
            //textScore.transform.localPosition = transform.position;
            textScoreText.text = "" + 250;
            textScoreText.color = myColor;
            coroutine = WaitAndPrint(2.0f, textScore);
            StartCoroutine(coroutine);
            myScoreValue += 250;
        }
    }

    private IEnumerator WaitAndPrint(float waitTime, GameObject textToDestroy)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(textToDestroy);
        print("WaitAndPrint " + Time.time);
    }
}
