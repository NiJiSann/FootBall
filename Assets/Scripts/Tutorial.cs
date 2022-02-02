using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tut_1;
    [SerializeField] private GameObject _tut_2;
    [SerializeField] private Button _tut_1_BTN;
    [SerializeField] private Button _tut_2_BTN;

    private static bool tutPassed = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!tutPassed)
        {
            tutPassed = true;

            _tut_1.SetActive(true);
            _tut_1_BTN.onClick.AddListener(() => _tut_1.SetActive(false));
            _tut_2_BTN.onClick.AddListener(() => _tut_2.SetActive(false));
        }
    }

}
