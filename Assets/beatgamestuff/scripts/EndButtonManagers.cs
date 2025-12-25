using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButtonManagers : MonoBehaviour
{
    private const string HOSPITAL_ROOM = "3DHospitalMap";
    private const string BEAT_ROOM = "2DBeatRoom";

    private string currentRoom;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReturnToHospital()
    {
        //if (GetCurrentScene() != BEAT_ROOM)
       // {
            GameInput.Instance.ToggleMouse(false);
            SceneManager.LoadScene(HOSPITAL_ROOM);
       // }
    }

    public void PlayAgain()
    {
        //if (GetCurrentScene() != BEAT_ROOM)
        // {
        GameInput.Instance.ToggleMouse(true);
        SceneManager.LoadScene(BEAT_ROOM);
        // }
    }


}
