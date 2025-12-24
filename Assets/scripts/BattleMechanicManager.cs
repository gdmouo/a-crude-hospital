using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BattleMechanicManager : MonoBehaviour
{
    public static BattleMechanicManager Instance { get; private set; }

    private const string HOSPITAL_ROOM = "3DHospitalMap";
    private const string BEAT_ROOM = "2DBeatRoom";

    private string currentRoom;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;

        currentRoom = GetCurrentScene();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToBeatRoom()
    {
        if (GetCurrentScene() != BEAT_ROOM)
        {
            GameInput.Instance.ToggleMouse(true);
            SceneManager.LoadScene(BEAT_ROOM);
        }
    }

    private string GetCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        return sceneName;
    }
}
