using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public ShipBehaviour ship;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.score = 0;
    }
}
