using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    public int uniqueId;
    void Start()
    {
        
    }

    public void setToManager()
    {
        GameManager.instance.remedialIdentifier = uniqueId;
        GameManager.instance.remedialSelected = true;
    }
}
