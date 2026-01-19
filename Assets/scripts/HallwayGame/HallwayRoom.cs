using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class HallwayRoom : MonoBehaviour
{
    //Bounds areaBounds = boxCollider.bounds;
    private Bounds areaBounds;
    [SerializeField] private BoxCollider boxCollider;
    private GameObject target;
    [SerializeField] private int roomNumber = 0;

    
    public int RoomNumber { get { return roomNumber; } }
    // Start is called before the first frame update

    void Start()
    {
        areaBounds = boxCollider.bounds;
        target = Player.Instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PlayerInRoom()
    {
        if (target == null)
        {
            return false;
        }
        if (areaBounds.Contains(target.transform.position))
        {
            return true;
            // target is inside
        }
        return false;
    }
}


