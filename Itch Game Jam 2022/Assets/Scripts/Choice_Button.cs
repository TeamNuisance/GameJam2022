using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using VisualNovel;
public class Choice_Button : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI button_text;
    [SerializeField] int button_report;
    [SerializeField] GameObject report_To;

    public void SetUpButton(string btn_text, int btn_report, GameObject report_to ) {
        button_text.text = btn_text;
        button_report = btn_report;
        report_To = report_to;
    }

    public void OnClick() {
        report_To.SendMessage("ChoiceButton_OnClick", button_report, SendMessageOptions.DontRequireReceiver);
    }

}
