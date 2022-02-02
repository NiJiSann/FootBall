using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalkeeperInput : MonoBehaviour
{
    public enum SaveDir
    {
        def,

        saveRUp ,
        saveRDown,
        saveCUp,
        saveCenter,
        saveLUp,
        saveLDown
    }

    public static SaveDir animIndex;

    [SerializeField] private Button saveRUp;
    [SerializeField] private Button saveRDown;
    [SerializeField] private Button saveCUp;
    [SerializeField] private Button saveCenter;
    [SerializeField] private Button saveLUp;
    [SerializeField] private Button saveLDown;

    private void Start()
    {
        saveRUp.onClick.AddListener(()=> SetAnimIndex(1));
        saveRDown.onClick.AddListener(() => SetAnimIndex(2));
        saveCUp.onClick.AddListener(() => SetAnimIndex(3));
        saveCenter.onClick.AddListener(() => SetAnimIndex(4));
        saveLUp.onClick.AddListener(() => SetAnimIndex(5));
        saveLDown.onClick.AddListener(() => SetAnimIndex(6));
    }

    void SetAnimIndex(int i)
    {
        animIndex = (SaveDir)i;
        GameState.GetState = GameState.GameStates.watch;
    }

}
