using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;
using TMPro;

public class TogglePanelVisibility : MonoBehaviour
{
    public LeanEvent showpanel, hidepanel;

    public TextMeshProUGUI buttontext;

    public void ViewPanel()
    {
        buttontext.text = "Hide Panel";
        showpanel.BeginAllTransitions();    
    }

    public void HidePanel()
    {
        buttontext.text = "Show Panel";
        hidepanel.BeginAllTransitions();     
    }
}
