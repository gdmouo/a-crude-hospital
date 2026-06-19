using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentManager : MonoBehaviour
{
    private SceneToGo sceneToGo;
    public static PersistentManager Instance { get; private set; }
    public Mission01StageLabel CurrentStage;
    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy this duplicate
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set this object as the permanent instance
        Instance = this;

        // Instruct Unity to carry this object across scene changes
        DontDestroyOnLoad(gameObject);
    }

    public void SetMissionStageForReturn(Mission01StageLabel m)
    {
        CurrentStage = m;
    }

    public void LoadBeatLevel(SongTitle sTitle)
    {
        switch (sTitle)
        {
            case SongTitle.Beaty:
                sceneToGo = SceneToGo.BeatRoom;
                break;
        }
    }

    public void LoadMission()
    {
        sceneToGo = SceneToGo.Mission_01;
    }

    public void SwitchRoom()
    {
        SceneManager.LoadScene(sceneToGo.ToString());
    }
}

public enum SceneToGo
{
    Mission_01,
    BeatRoom
}
