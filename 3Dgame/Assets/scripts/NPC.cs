﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    [Header("NPC 資料")]
    public NPCData data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話者名稱")]
    public Text textName;
    [Header("對話間隔")]
    public float interval = 0.2f;


    public bool playerInArea;

    public enum NPCState
    {
        FirstDialog, Missioning,Finish
    }


    public NPCState state = NPCState.FirstDialog;

    /**
     private void Start() 
    {

        StartCoroutine(Test());
    }

    private IEnumerator Test()
    {
        print("嗨~");
        yield return new WaitForSeconds(1.5f);


    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "怪人")
        {
            playerInArea = true;
            StartCoroutine(Dialog());
        }
    } 
    private void OnTriggerExit(Collider other)
    {
        if(other.name=="怪人")
        { 
            playerInArea = false;
            StopDialog();

        }
    }

    private void StopDialog()
    {
        dialog.SetActive(false);
        StopAllCoroutines();
    }
    private IEnumerator Dialog() 
    {
        dialog.SetActive(true);
        textContent.text = "";
        textName.text = name;
        string dialogString = data.dialougB;

       switch(state)
        {
            case NPCState.FirstDialog:
                dialogString = data.dialougA;
                break;
            case NPCState.Missioning:
                dialogString = data.dialougB;
                break;
            case NPCState.Finish:
                dialogString = data.dialougC;
                break;
        }

       for(int i = 0;i< dialogString.Length;i++)
        {
            //print(data.dialougA[i]);
            textContent.text += dialogString[i]+"";

            yield return new WaitForSeconds(0.2f);
        }
                
                }



}
