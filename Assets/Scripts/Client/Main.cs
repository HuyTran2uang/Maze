using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }

    private void Reset()
    {
        Init();
    }

    private void Init()
    {
        var abc = this.GetListInt();
        foreach (var i in abc)
        {
            Debug.Log(i);
        }
    }

    IEnumerable<int> GetListInt()
    {
        yield return 1;
    }
}
