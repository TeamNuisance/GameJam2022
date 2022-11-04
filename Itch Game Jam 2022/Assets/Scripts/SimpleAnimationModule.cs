using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Core;

namespace VisualNovel
{
    public class AnimationInformation { public GameObject obj; public string phase; public int objectId; public AnimationInformation() { } }


    public class SimpleAnimationModule : MonoBehaviour
    {
        VN_Manager vn_Manager;
        [SerializeField] Vector3 offStage_Left, offStage_Right;
        string coroutineCall = "";
        bool[] finishedBoolArray;

        /****************************************************************************************************/
        private void Start() { FindVNManager(); }

        private void FindVNManager() { vn_Manager = this.gameObject.GetComponent<VN_Manager>(); }

        public void TriggerStartAnimations() { TriggerAnimation("Enter"); }
        public void TriggerEndAnimations() { TriggerAnimation("Exit"); }

        private void TriggerAnimation(string phase)
        {
            GameObject[] actorObjects = vn_Manager.GetImageModule().GetActorObjectList();
            finishedBoolArray = new bool[actorObjects.Length];
            for (int a = 0; a < actorObjects.Length; a++)
            {
                AnimationInformation animInfo = new AnimationInformation();
                if (phase == "Enter") { coroutineCall = vn_Manager.GetCurrentPage().GetEnterAnimation(a); }
                else if (phase == "Exit") { coroutineCall = vn_Manager.GetCurrentPage().GetExitAnimation(a); }
                animInfo.obj = actorObjects[a];
                animInfo.phase = phase;
                animInfo.objectId = a;
                StartCoroutine(coroutineCall, animInfo);
            }
        }


        /****************************************************************************************************/
        private bool CheckFinishedBoolArray() { for (int a = 0; a < finishedBoolArray.Length; a++) { if (!finishedBoolArray[a]) { return false; } } return true; }
        private void ChangeFinishedBoolArray(int a, bool b) { finishedBoolArray[a] = b; }
        private void CheckFinished(string a) { if (CheckFinishedBoolArray()) { vn_Manager.ReportAnimations(a); } }

        /****************************************************************************************************/
        private IEnumerator ExitStageLeft(AnimationInformation a)
        {
            Vector3 onStage = a.obj.transform.localPosition;
            float b = 0;
            while (b < 1)
            {
                a.obj.transform.localPosition = Vector3.Lerp(onStage, offStage_Left, b);
                yield return new WaitForSeconds(0.001f);
                b += 0.01f;
            }
            a.obj.transform.localPosition = onStage;
            ChangeFinishedBoolArray(a.objectId, true);
            CheckFinished(a.phase);
        }
        private IEnumerator ExitNone(AnimationInformation a)
        {
            yield return new WaitForSeconds(0.001f);
            ChangeFinishedBoolArray(a.objectId, true);
            CheckFinished(a.phase);
        }

        private IEnumerator ExitStageRight(AnimationInformation a)
        {

            Vector3 onStage = a.obj.transform.localPosition;
            float b = 0;
            while (b < 1)
            {
                a.obj.transform.localPosition = Vector3.Lerp(onStage, offStage_Right, b);
                yield return new WaitForSeconds(0.001f);
                b += 0.01f;
            }
            a.obj.transform.localPosition = onStage;
            ChangeFinishedBoolArray(a.objectId, true);
            CheckFinished(a.phase);
        }

        /****************************************************************************************************/
        private IEnumerator EnterStageLeft(AnimationInformation a)
        {
            a.obj.transform.localPosition = offStage_Left;
            Vector3 onStage = vn_Manager.GetImageModule().GetActorLocationsList(a.objectId);
            float b = 0;
            while (b < 1)
            {
                a.obj.transform.localPosition = Vector3.Lerp(offStage_Left, onStage, b);
                yield return new WaitForSeconds(0.001f);
                b += 0.01f;
            }
            a.obj.transform.localPosition = onStage;
            ChangeFinishedBoolArray(a.objectId, true);
            CheckFinished(a.phase);
        }

        private IEnumerator EnterNone(AnimationInformation a)
        {
            yield return new WaitForSeconds(0.001f);
            ChangeFinishedBoolArray(a.objectId, true);
            CheckFinished(a.phase);
        }

        private IEnumerator EnterStageRight(AnimationInformation a)
        {
            a.obj.transform.localPosition = offStage_Right;
            Vector3 onStage = vn_Manager.GetImageModule().GetActorLocationsList(a.objectId);
            float b = 0;
            while (b < 1)
            {
                a.obj.transform.localPosition = Vector3.Lerp(offStage_Right, onStage, b);
                yield return new WaitForSeconds(0.001f);
                b += 0.01f;
            }
            a.obj.transform.localPosition = onStage;
            ChangeFinishedBoolArray(a.objectId, true);
            CheckFinished(a.phase);
        }
        /****************************************************************************************************/
    }

}



