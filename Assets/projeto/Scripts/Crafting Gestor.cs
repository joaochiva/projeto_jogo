using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingGestor : MonoBehaviour
{

    public GameObject polig;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(new GameObject(),Vector3.zero,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
