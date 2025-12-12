using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRef : MonoBehaviour
{
    [SerializeField] private List<Button> buttons = new List<Button>();

    public List<Button> Buttons
    {
        get
        {
            return buttons;
        }
    }
}
