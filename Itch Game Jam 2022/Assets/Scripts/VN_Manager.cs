using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Core;

namespace VisualNovel
{
    public class VN_Manager : MonoBehaviour
    {
        Singleton singleton; //SINGLETON  
        [SerializeField] SimpleAnimationModule sAM; SimpleImageModule sIM; SimpleTextModule sTM; //MODULES
        Book_Element currentBook; Chapter_Element currentChapter; VN_Element currentPage; //LIBRARY
        int current_Page_Index = 0, previousPageIndex = 0, nextPage = 0; //page references
        [SerializeField]  bool applyAnimations, applyImages, applyText, checkingInput; //bools
        GameObject backgroundTrigger; //background object

        [SerializeField] float pageTimer = 0;
        [SerializeField] float choiceTimer = 0;
        [SerializeField] bool pageTimerActive = false;
        [SerializeField] bool choiceTimerActive = false;

        /****************************************************************************************************/
        private void Start()
        {
            FindObjects();
            Loop1();
        }

        private void Update() { 
            if (checkingInput) { if (Input.GetKeyDown(KeyCode.Space)) { 
                    Loop4(); 
                } 
            }
            if (pageTimerActive) {
                pageTimer += Time.deltaTime;
            }
            if (choiceTimerActive)
            {
                choiceTimer += Time.deltaTime;
            }
        }

        /****************************************************************************************************/
        private void Loop1()
        {
            checkingInput = false;
            pageTimer = 0;
            choiceTimer = 0;
            pageTimerActive = true;
            choiceTimerActive = false;
            ResetUI();
            sIM.UpdateImages();
            sAM.TriggerStartAnimations();
        }

        private void Loop2()
        {
            if (applyText)
            {
                sTM.ApplyTitleText();
                sTM.TriggerTextUpdate();
            }
        }

        private void Loop3()
        {
            choiceTimerActive = true;
            if (currentPage.GetElementType() == "Text") { checkingInput = true; }
            else if (currentPage.GetElementType() == "Choice") { sTM.ShowChoices();  }
        }

        private void Loop4()
        {
            sAM.TriggerEndAnimations();
        }

        /****************************************************************************************************/
        private void ChangePage()
        {
            previousPageIndex = current_Page_Index;
            current_Page_Index = nextPage;
            UpdateBook();
            Loop1();
        }

        public void ChoiceButton_OnClick(int a)
        {
            nextPage = a;
            Loop4();
        }

        /****************************************************************************************************/
        public void ReportAnimations(string a)
        {
            if (a == "Enter") { Loop2(); }
            if (a == "Exit") { ChangePage(); }
        }
        public void ReportTextFinished() { Loop3(); nextPage = currentPage.GetDefaultNextPage(); }

        /****************************************************************************************************/
        public VN_Element GetCurrentPage() { return currentPage; }
        public float GetPlaySpeed() { return singleton.Text_Speed; }
        public SimpleImageModule GetImageModule() { return sIM; }

        /****************************************************************************************************/
        private void ResetUI()
        {
            sIM.ResetUI();
            sTM.ResetUI();
            Destroy(backgroundTrigger);
            TriggerObjectCheck();
        }


        private void FindObjects()
        {
            singleton = GameObject.FindGameObjectWithTag("GameController").GetComponent<Singleton>();
            FindModules();
            UpdateBook();

        }

        private void FindModules()
        {
            sAM = this.gameObject.GetComponent<SimpleAnimationModule>();
            if (sAM == null) { applyAnimations = false; applyImages = false; }
            sIM = this.gameObject.GetComponent<SimpleImageModule>();
            if (sIM == null) { applyAnimations = false; applyImages = false; }
            sTM = this.gameObject.GetComponent<SimpleTextModule>();
            if (sTM == null) { applyText = false; }
        }

        private void UpdateBook()
        {
            currentBook = singleton.GetCurrentBook();
            currentChapter = singleton.GetCurrentChapter();
            currentPage = currentChapter.GetPage(current_Page_Index);
        }

        private void TriggerObjectCheck()
        {
            if (currentPage.IsThereTriggerObject())
            {
                backgroundTrigger = Instantiate(currentPage.GetBackgroundTriggerObject(), this.transform);
            }
        }

    }
}