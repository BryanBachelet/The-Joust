using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputManager : MonoBehaviour
{
    public PlayerInputManager PlayerInputManager;
    public GameInputManager[] playerInGame;
    public PlayerInput p1Input;
    // Start is called before the first frame update
    void Start()
    {
        
        PlayerInputManager = gameObject.GetComponent<PlayerInputManager>();
        PlayerInputManager.JoinPlayer();

    }

    // Update is called once per frame
    void Update()
    {

        PlayerInputManager.JoinPlayer();

    }
}
