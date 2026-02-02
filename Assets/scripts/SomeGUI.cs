using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SomeGUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameComponent;
    [SerializeField] private TextMeshProUGUI itemDescriptionComponent;
    [SerializeField] private GameObject textParent;
    private void Start()
    {
        Player.Instance.OnSelectedInteractibleChanged += Player_OnSelectedInteractibleChanged;
        textParent.SetActive(false);
    }

    private void Player_OnSelectedInteractibleChanged(object sender, Player.OnSelectedInteractibleChangedEventArgs e)
    {

        if (e.selectedInteractible != null)
        {
            if (!textParent.activeSelf)
            {
                textParent.SetActive(true);
            }
            itemNameComponent.text = e.selectedInteractible.GetName();
          //  itemDescriptionComponent.text = e.selectedInteractible.GetHighlight();
        }
        else
        {
            if (textParent.activeSelf)
            {
                textParent.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
