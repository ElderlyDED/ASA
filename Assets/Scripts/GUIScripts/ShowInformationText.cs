using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowInformationText : MonoBehaviour
{
    [SerializeField] GameObject _informationText;
    public void OnShowInfText(string _text)
    {
        _informationText.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _text;
        _informationText.GetComponent<Animation>().Play();
    }
}
