using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using Lean.Transition.Method;

public class EnlargeShrinkMenu : MonoBehaviour
{
    public LeanTransformLocalScale enlargemenu, shrinkmenu;

    public void EnlargeMenu()
    {
        enlargemenu.BeginThisTransition();
    }

    public void ShrinkMenu()
    {
        shrinkmenu.BeginThisTransition();
    }
}
