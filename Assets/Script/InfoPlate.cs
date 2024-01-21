using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoPlate : MonoBehaviour
{
    public GameObject infoPlateDialog;
    private bool showingDialog;

    private void Start()
    {
        EnableDialog(false);
    }

    public void EnableDialog(bool enabled)
    {
        infoPlateDialog.SetActive(enabled);
        showingDialog = enabled;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !showingDialog)
        {
            EnableDialog(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && showingDialog)
        {
            EnableDialog(false);
        }
    }
}

