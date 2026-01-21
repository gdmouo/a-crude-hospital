using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UniverseManager : MonoBehaviour
{
    public static UniverseManager Instance { get; private set; }

    private const string HOSPITAL_ROOM = "3DHospitalMap";
    private const string BEAT_ROOM = "2DBeatRoom";
    private const string DEATH_ROOM = "DeathRoom";

    private string currentRoom; 

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;
      //  DontDestroyOnLoad(gameObject);

        currentRoom = GetCurrentScene();
    }

    private void Start()
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

    public void GoToHospital()
    {
        if (GetCurrentScene() != HOSPITAL_ROOM)
        {
            GameInput.Instance.ToggleMouse(false);
            SceneManager.LoadScene(HOSPITAL_ROOM);
        }
    }

    public void GoToDeath()
    {
        if (GetCurrentScene() != DEATH_ROOM)
        {
            GameInput.Instance.ToggleMouse(true);
            SceneManager.LoadScene(DEATH_ROOM);
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    private string GetCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        return sceneName;
    }
}
