using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Navigation : MonoBehaviour
{

    public RectTransform tabManager;
    public Vector3[] menuTabs;
    public int currentMenuTab;
    public int nextMenuTab;
    public float tempsTransition = 1f;
    public bool isMoving = false;
    private float tempsEcouleTransition = 0;

    // Start is called before the first frame update
    void Start()
    {
         currentMenuTab = 0;
         isMoving = false;
         tempsEcouleTransition = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            tempsEcouleTransition += Time.deltaTime;
            if (tempsEcouleTransition < tempsTransition)
            {
                tabManager.localPosition = Vector3.Lerp(menuTabs[currentMenuTab], menuTabs[nextMenuTab], tempsEcouleTransition);
            }
            else
            {
                tabManager.localPosition = menuTabs[nextMenuTab];
                currentMenuTab = nextMenuTab;
                tempsEcouleTransition = tempsTransition;
                isMoving = false;
            }

        }
    }

    public void ChangeMenuTab(int numeroTab)
    {
        if(currentMenuTab != numeroTab)
        {
            nextMenuTab = numeroTab;
            isMoving = true;
            tempsEcouleTransition = 0;
        }
    }

    public void LoadingScene(int numeroScene)
    {
        SceneManager.LoadSceneAsync(numeroScene);
    }
}
