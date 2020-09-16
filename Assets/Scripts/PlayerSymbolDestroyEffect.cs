using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSymbolDestroyEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2f);
    }

  
}
