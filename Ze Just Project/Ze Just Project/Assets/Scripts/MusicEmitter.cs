using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class MusicEmitter : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string Event = "";
    private static  FMOD.Studio.EventInstance instance;

    static public bool gameStarted;
    // Start is called before the first frame update
    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(Event);



        Debug.Log("Srtating : " + Event);
        if(gameStarted)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("GameLaunch", 1);
            //instance.setParameterByName("GameLaunch", 1);

        }
        else
        {
            instance.start();
        }
        //instance.release();
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void LaunchMusic(bool gameStat)
    {
        gameStarted = gameStat;

    }

}
