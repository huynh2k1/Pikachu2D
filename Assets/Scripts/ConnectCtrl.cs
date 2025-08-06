using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConnectCtrl : MonoBehaviour
{
    public static ConnectCtrl I;


    private void Awake()
    {
        I = this;
    }

}
