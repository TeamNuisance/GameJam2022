using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Core;

namespace VisualNovel
{
    public class SimpleImageModule : MonoBehaviour
    {
        VN_Manager vn_Manager;
        [SerializeField] CharacterLibrarySO[] ActorList;
        [SerializeField] VN_Element currentPage; //LIBRARY
        [SerializeField] GameObject ActorPrefab;
        [SerializeField] Vector3[] ActorLocations;
        [SerializeField] Transform canvasTransform;
        [SerializeField] GameObject backgroundObj;
        GameObject[] actorObjectList = new GameObject[1];

        void Start()
        {
            FindVNManager();
        }

        /****************************************************************************************************/
        public void ResetUI() { if (actorObjectList.Length > 0) { foreach (GameObject a in actorObjectList) { Destroy(a); } } }

        public void UpdateImages()
        {
            currentPage = vn_Manager.GetCurrentPage();
            if (currentPage.ShowBackground()) { UpdateBackground(); }
            if (currentPage.ShowActors()) { GenerateActors(); }
        }

        private void GenerateActors()
        {
            ActorList = currentPage.GetActorLibrary();
            actorObjectList = new GameObject[ActorList.Length];
            for (int a = 0; a < ActorList.Length; a++)
            {
                GameObject b = Instantiate(ActorPrefab, canvasTransform);
                int[] c = currentPage.GetActorSpriteID();
                b.GetComponent<Image>().sprite = ActorList[a].GetImage(c[a]);
                b.transform.localPosition = ActorLocations[a];
                actorObjectList[a] = b;
            }
        }

        /****************************************************************************************************/
        private void FindVNManager() { vn_Manager = this.gameObject.GetComponent<VN_Manager>(); }
        private void UpdateBackground() { backgroundObj.GetComponent<Renderer>().material = currentPage.GetBackground(); }
        /****************************************************************************************************/
        public GameObject[] GetActorObjectList() { return actorObjectList; }
        public Vector3[] GetActorLocationsList() { return ActorLocations; }
        public Vector3 GetActorLocationsList(int a) { return ActorLocations[a]; }

    }
}

