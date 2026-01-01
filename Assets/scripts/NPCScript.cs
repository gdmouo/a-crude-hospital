using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCScript : MonoBehaviour
{
    [SerializeField] private string npcName;
    [SerializeField] private Dictionary<Room, DialoguePack> roomDialogueDict;

    // Start is called before the first frame update
    void Start()
    {
        LoadDialogueDict();
    }

    public Dialogue GetDialogue(Room r)
    {
        if (roomDialogueDict == null)
        {
            Debug.LogError("dialogue unassigned");
            Debug.Log("4");
            return new Dialogue("poop", true);
        }

        if (roomDialogueDict.TryGetValue(r, out DialoguePack dp))
        {
            return dp.GetDialogue();
        }

        Debug.LogError("dialoguepack error");
        Debug.Log("3");
        return new Dialogue("poop", true);
    }

    public List<Dialogue> GetDialoguePack(Room r)
    {
        if (roomDialogueDict == null)
        {
            Debug.LogError("dialogue unassigned");
            return null;
        }

        if (roomDialogueDict.TryGetValue(r, out DialoguePack dp))
        {
            List<Dialogue> list = new();

            Dialogue d;
            do
            {
                d = dp.GetDialogue();
                list.Add(d);
            } while (!d.EndOfDialogue);

            return list;
        }

        return null;
    }

    protected virtual void LoadDialogueDict()
    {

    }
    protected void AddToHospitalRoomDialogue(string line, bool isEnd)
    {
        AddToRoomDialogue(Room.HOSPITAL_RECEPTION, line, isEnd);
    }

    private void AddToRoomDialogue(Room room, string line, bool isEnd)
    {
        if (roomDialogueDict == null)
        {
            roomDialogueDict = new Dictionary<Room, DialoguePack>();
        }

        if (!roomDialogueDict.ContainsKey(room)) {
            roomDialogueDict.Add(room, new DialoguePack(null));
        }

        roomDialogueDict[room].AddDialogue(new Dialogue(line, isEnd));
    }
}

public enum Room { 
    HOSPITAL_RECEPTION,
    BEAT_ROOM
}

[System.Serializable]

public struct DialoguePack {
    public List<Dialogue> dialogue;
    private int index;

    public DialoguePack(List<Dialogue> d)
    {
        dialogue = d;
        index = 0;
    }

    public void AddDialogue(Dialogue d)
    {
        if (dialogue == null)
        {
            dialogue = new List<Dialogue>() { d };
            return;
        }
        dialogue.Add(d);
    }

    public Dialogue GetDialogue()
    {
        if (dialogue == null)
        {
            Debug.Log("1");
            dialogue = new List<Dialogue>();
            return new Dialogue("poop", true);
        }
        if (index >= dialogue.Count)
        {
            Debug.Log("2");
            return new Dialogue("poop", true);
        }
        int temp = index;
        index++;
        return dialogue[temp];
    }
}

[System.Serializable]

public struct Dialogue {
    public string Line;
    public bool EndOfDialogue;

    public Dialogue(string s, bool b)
    {
        Line = s;
        EndOfDialogue = b;
    }
}






