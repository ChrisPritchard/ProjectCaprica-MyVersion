using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonyView : MonoBehaviour 
{
    public object Colony;

    private void OnEnable() 
    {
        // Update elements based on colony
        Debug.Log("On Enable");
    }
}
