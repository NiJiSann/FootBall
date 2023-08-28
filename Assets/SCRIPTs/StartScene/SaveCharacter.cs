using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCharacter : MonoBehaviour
{
    public void Save(string name)
    {
        PlayerPrefs.SetString("character", name);
    }
}
