﻿
using UnityEngine;
using System.Collections;


public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    protected static T s_instance;


    public static T instance
    {
        get
        {

            if (s_instance == null)
                s_instance = (T)FindObjectOfType(typeof(T));



            return s_instance;
        }
    }
}
