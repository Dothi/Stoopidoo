
using UnityEngine;
using System.Collections;

public class LoadingSceneManager : Singleton<LoadingSceneManager>
{

    public static void UnloadLoadingScene()
    {
        GameObject.Destroy(instance.gameObject);
    }
}
