using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Core;

namespace VisualNovel
{

    public class SimpleTextModule : MonoBehaviour
    {
        VN_Manager vn_Manager;
        string displayText = "";
        int currentTextChar = 0;
        [SerializeField] TextMeshProUGUI title_Text, dialogue_text;
        [SerializeField] GameObject choicePanel;
        List<GameObject> ChoiceObjectList = new List<GameObject>();
        [SerializeField] GameObject choicePrefab;

        void Start()
        {
            choicePanel.SetActive(false);
            FindVNManager();
        }

        void Update()
        {
            if (!IsTextFinished()) { dialogue_text.text = displayText; }
            else { vn_Manager.ReportTextFinished(); }
        }


        /****************************************************************************************************/
        public void ShowChoices()
        {
            choicePanel.SetActive(true);
            if (ChoiceObjectList.Count < vn_Manager.GetCurrentPage().GetChoiceText().Length)
            {
                for (int a = 0; a < vn_Manager.GetCurrentPage().GetChoiceText().Length; a++)
                {
                    GameObject g = Instantiate(choicePrefab, choicePanel.transform);
                    string btn_text = vn_Manager.GetCurrentPage().GetChoiceText(a);
                    int btn_report = vn_Manager.GetCurrentPage().GetChoiceNextPage(a);
                    g.GetComponent<Choice_Button>().SetUpButton(btn_text, btn_report, this.gameObject);
                    ChoiceObjectList.Add(g);
                }
            }
        }


        /****************************************************************************************************/
        public void ResetUI()
        {
            choicePanel.SetActive(false);
            displayText = "";
            currentTextChar = 0;
        }

        /****************************************************************************************************/
        private IEnumerator UpdateText()
        {
            string a = vn_Manager.GetCurrentPage().GetVNText();
            if (displayText.Length < a.Length)
            {
                if (a[currentTextChar] == '/') { print("index"); }
                displayText += a[currentTextChar];
                currentTextChar++;
                dialogue_text.text = displayText;
                float b = vn_Manager.GetPlaySpeed();
                yield return new WaitForSeconds(b);
                StartCoroutine(UpdateText());
            }
        }
        /****************************************************************************************************/
        public void TriggerTextUpdate() { StartCoroutine(UpdateText()); }
        public void ApplyTitleText() { title_Text.text = vn_Manager.GetCurrentPage().GetTitleText(); }
        /****************************************************************************************************/
        private void FindVNManager() { vn_Manager = this.gameObject.GetComponent<VN_Manager>(); }
        public bool IsTextFinished() { if (displayText.Length != vn_Manager.GetCurrentPage().GetVNText().Length) { return false; } return true; }
        /****************************************************************************************************/
    }
}