using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanController : MonoBehaviour
{
    [SerializeField]
    private int points = 0;


    public void Trashed()
    {
        points++;
    }

}
