using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class HatmanDefeatedManager : MonoBehaviour
{
    [SerializeField] private HatmanDefeatedCanvas hatmanDefeatedCanvas;

    private bool activated = false;

    private float currTimer = 0f;

    private HMGameStep currStep;

    private const float HIDE_MAX = 10f;
    private const float SEEK_MAX = 10f;

    private void Awake()
    {
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            switch (currStep) {
                case HMGameStep.Hide:
                    hatmanDefeatedCanvas.UpdatePlayerStatus("Player status: " + GetPlayerStatusDuringHide().ToString());
                    if (currTimer <= HIDE_MAX)
                    {
                        currTimer += Time.deltaTime;
                    } else
                    {
                        currTimer = 0f;
                        currStep = HMGameStep.Seek;
                        hatmanDefeatedCanvas.UpdateStatus("Hatman Seek");
                        HallwayManagerNew.Instance.ToggleAllDoors(true);
                        hatmanDefeatedCanvas.UpdateHatmanSelectedRoom(GetHatmanSelectedRoom());
                    }
                    break;
                case HMGameStep.Seek:
                default:
                    hatmanDefeatedCanvas.UpdatePlayerStatus("Player status: " + GetPlayerStatusDuringSeek().ToString());
                    if (currTimer <= SEEK_MAX)
                    {
                        currTimer += Time.deltaTime;
                    }
                    else
                    {
                        currTimer = 0f;
                        currStep = HMGameStep.Hide;
                        hatmanDefeatedCanvas.UpdateStatus("Player Hide");
                        HallwayManagerNew.Instance.ToggleAllDoors(false);
                        hatmanDefeatedCanvas.ClearHatmanSelectedRoom();
                    }
                    break;
            }
            hatmanDefeatedCanvas.UpdateCounter(currTimer);
            hatmanDefeatedCanvas.UpdatePlayerRoom(HallwayManagerNew.Instance.GetPlayerRoomIndex());
            //status while hiding, status while seeking

            //hiding statuses: hiding, not hiding
            //seeking statuses: not found, found
        }
    }

    public void Run()
    {
        currStep = HMGameStep.Hide;
        hatmanDefeatedCanvas.Activate();
        hatmanDefeatedCanvas.UpdateStatus("Player Hide");
        hatmanDefeatedCanvas.UpdateCounter(0f);
        activated = true;
    }

    private PlayerStatus GetPlayerStatusDuringHide()
    {
        if (HallwayManagerNew.Instance.GetPlayerRoomIndex() == -1)
        {
            return PlayerStatus.Not_hiding;
        } else
        {
            return PlayerStatus.Hiding;
        }
    }

    private PlayerStatus GetPlayerStatusDuringSeek()
    {
        int pIndex = HallwayManagerNew.Instance.GetPlayerRoomIndex();
        if (pIndex == -1 || pIndex == GetHatmanSelectedRoom())
        {
            return PlayerStatus.Found;
        }
        else
        {
            return PlayerStatus.Not_found;
        }
    }

    private int GetHatmanSelectedRoom()
    {
        //some algorithm
        return 1;
    }


}

public enum HMGameStep { 
    Hide,
    Seek
}

public enum PlayerStatus { 
    Hiding,
    Not_hiding,
    Found,
    Not_found
}

