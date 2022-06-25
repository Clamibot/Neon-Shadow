using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupText : MonoBehaviour
{
    public TextMeshPro popup;
    public string text;
    private string textTmp;
    bool used = false;
    // Start is called before the first frame update
    void Start()
    {
        popup = GameObject.Find("Dialogue").GetComponent<TextMeshPro>();
        textTmp = text;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            popup.SetText("");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"&&!used)
        {
            popup.SetText(textTmp);
            used = true;
        }
    }
}
