using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCData data;

    public bool playerInArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "怪人")
        {
            playerInArea = true;
        Dialog()
        }
    } 
    private void OnTriggerExit(Collider other)
    {
        if(other.name=="怪人")
        { 
            playerInArea = false;
        }
    }
    private void Dialog() 
    {
        print(data.dialougA);
    }



}
