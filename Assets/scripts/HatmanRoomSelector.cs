using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class HatmanRoomSelector : MonoBehaviour 
{
    //hatman prev room
    //player room chosen
    //loop num (updated at the creation of each loopselector), so will be set already when this is called

    public static HatmanRoomSelector Instance {  get; private set; }  
    private int hatmanPrevRoom = -1;
    private int hatmanCurrRoom = 0;
    //  private int playerPrevRoom;
    // private int loopIndex;

    private void Awake()
    {
        Instance = this;
    }

    public int SelectHatmanRoom(int playerPrevRoom, int loopIndex)
    {
        hatmanPrevRoom = hatmanCurrRoom;
        hatmanCurrRoom = ChooseRoomForHatman(playerPrevRoom, loopIndex);
        Debug.Log("hatmanCurrRoom = " + hatmanCurrRoom + " playerPrevRoom = " + playerPrevRoom);
        return hatmanCurrRoom;
    }

    private int ChooseRoomForHatman(int playerPrevRoom, int loopIndex)
    {
        int seekIndex = loopIndex / 2;

        Debug.Log("seek index: " +  seekIndex);

        //roomnumbers are 0 indexed

        //i got overwhelmed at school i dont feel like making a cool algorithm.
        switch (seekIndex)
        {
            case 1:
                int rand = Random.Range(0, 5);
                return rand;
            case 2:
                return playerPrevRoom;
            case 3:
                //
                //return 
                switch (hatmanPrevRoom)
                {
                    case 0:
                        return 4;
                    case 1:
                        return 3;
                    case 3:
                        return 1;
                    case 4:
                        return 0;
                    case 2:
                        return 3;
                    case 5:
                        return 0;
                    default:
                        return -1;
                }
            case 4:
                switch (hatmanPrevRoom)
                {
                    case 0:
                    case 1:
                    case 3:
                    case 4:
                        return hatmanPrevRoom + 1;
                    case 2:
                    case 5:
                        return hatmanPrevRoom - 1;
                    default:
                        return -1;
                }
            case 5:
                switch (hatmanPrevRoom)
                {
                    case 0:
                        return 5;
                    case 1:
                        return 4;
                    case 2:
                        return 3;
                    case 3:
                        return 2;
                    case 4:
                        return 1;
                    case 5:
                        return 0;
                    default:
                        return -1;
                }
            case 6:
                switch (hatmanPrevRoom)
                {
                    case 0:
                    case 1:
                        return 2;
                    case 2:
                        return 0;
                    case 3:
                        return 5;
                    case 4:
                    case 5:
                        return 3;
                    default:
                        return -1;
                }
            default:
                Debug.Log("error");
                return -1;
        }

        //#BRUTE FORCE!!!! YAASSSSADASDSADASDAS
    }
    

    /*
    public int ChooseRoomForHatman()
    {
        int seekIndex = loopIndex / 2;

        //roomnumbers are 0 indexed

        //i got overwhelmed at school i dont feel like making a cool algorithm.
        switch (seekIndex) {
            case 1:
                int rand = Random.Range(0,5);
                return rand;
            case 2:
                return playerPrevRoom;
            case 3:
                //
                //return 
                switch (hatmanPrevRoom) {
                    case 0:
                        return 4;
                    case 1:
                        return 3;
                    case 3:
                        return 1;
                    case 4:
                        return 0;
                    case 2:
                        return 3;
                    case 5:
                        return 0;
                    default:
                        return -1;
                }
            case 4:
                switch (hatmanPrevRoom)
                {
                    case 0:
                    case 1:
                    case 3:
                    case 4:
                        return hatmanPrevRoom + 1;
                    case 2:
                    case 5:
                        return hatmanPrevRoom - 1;
                    default:
                        return -1;
                }
            case 5:
                switch (hatmanPrevRoom)
                {
                    case 0:
                        return 5;
                    case 1:
                        return 4;
                    case 2:
                        return 3;
                    case 3:
                        return 2;
                    case 4:
                        return 1;
                    case 5:
                        return 0;
                    default:
                        return -1;
                }
            case 6:
                switch (hatmanPrevRoom)
                {
                    case 0:
                    case 1:
                        return 2;
                    case 2:
                        return 0;
                    case 3:
                        return 5;
                    case 4:
                    case 5:
                        return 3;
                    default:
                        return -1;
                }
            default:
                Debug.Log("error");
                return -1;
        }

        //#BRUTE FORCE!!!! YAASSSSADASDSADASDAS
    }*/
}

