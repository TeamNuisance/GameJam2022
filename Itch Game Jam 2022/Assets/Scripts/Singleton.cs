using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Singleton : MonoBehaviour
    {
        public static Singleton instance;
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            if (instance != null) { Destroy(gameObject); } else { instance = this; }
        }
        [SerializeField] Book_Element[] books;
        [SerializeField] int current_Book_index;
        [SerializeField] int current_Chapter_index;

        [SerializeField] float text_Speed = 0.05f;
        [SerializeField] float fast_text_Speed = 0.005f;
        [SerializeField] bool[] vn_Switch;

        public Book_Element GetCurrentBook()        {   return books[current_Book_index];   }
        public Chapter_Element GetCurrentChapter()  { return books[current_Chapter_index].GetChapterElement(current_Book_index);  }



        public bool Get_VN_Switch(int a) { return vn_Switch[a]; }
        public void Set_VN_Switch(int a, bool b) { vn_Switch[a] = b; }
        public float Text_Speed         {   get {   return text_Speed;              }   set {   text_Speed = value;             }   }
        public float Fast_text_Speed    {   get {   return fast_text_Speed;         }   set { fast_text_Speed = value;          }   }
        public int Current_Book_Index   {   get {   return current_Book_index;      }   set {   current_Book_index = value;     }   }
        public int Current_Chapter_index{   get {   return current_Chapter_index;   }   set {   current_Chapter_index = value;  }   }





    }
}