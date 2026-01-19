using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HallwayManager : MonoBehaviour
{
    [SerializeField] private List<HallwayRoom> roomList;

    public Dictionary<int, HallwayRoom> RoomDictionary { get; private set; }

    public static HallwayManager Instance { get; private set; }

    [SerializeField] private Vector3 hatmanHallwayStartPos;
    public Vector3 HatmanHallwayStartPos { get { return hatmanHallwayStartPos; } }

    public int HatmanRoom { get; private set; }

    private int playerPrevRoom = -1;
    private int playerCurrRoom = -1;

    public int PlayerPrevRoom { get { return playerPrevRoom; } }

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (roomList != null)
        {
            RoomDictionary = roomList.ToDictionary(r => r.RoomNumber);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetRoomPos(int i)
    {
        foreach (HallwayRoom r in roomList)
        {
            if (r.RoomNumber == i)
            {
                Debug.Log(i);
                Debug.Log(r.transform.position);
                //Debug.Log(GetRoomPos(i));
                return r.transform.position;
            }
        }
        return Vector3.zero;
    }

 

    public int GetPlayerRoomIndex()
    {
        foreach (var value in RoomDictionary)
        {
            if (value.Value.PlayerInRoom())
            {
                playerPrevRoom = playerCurrRoom;
                playerCurrRoom = value.Key;
                return value.Key;
            }
        }
        return -1;
    }

    public void UpdateHatmanRoom(int i)
    {
        HatmanRoom = i;
    }
}
