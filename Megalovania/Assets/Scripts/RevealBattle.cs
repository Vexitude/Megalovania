using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealBattle : MonoBehaviour
{
    public SoulMovement soulMovement;
    public GameObject canvasObject;


    void Start()
    {
        
    }

    void OnEnable()
    {
        if (soulMovement != null)
        {
            soulMovement.ScriptRunComplete += OnSoulMovement_Complete;
        }

    }

    void OnDisable()
    {
        if (soulMovement != null)
        {
            soulMovement.ScriptRunComplete -= OnSoulMovement_Complete;
        }
    }

    void OnSoulMovement_Complete()
    {
        canvasObject.SetActive(true);
    }
}
