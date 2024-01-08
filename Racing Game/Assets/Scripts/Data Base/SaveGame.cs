using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        Database.SaveData();
    }
}
