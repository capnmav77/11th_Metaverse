using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    // Start is called before the first frame update
    [SerializeField] Menu[] menus;

    void Awake(){
        Instance = this;
    }

    public void OpenMenu(string menuName){
        foreach (Menu menu in menus){
            if (menu.MenuName == menuName){
                OpenMenu(menu);
            } 
            else if (menu.open){
                CloseMenu(menu);
            }
        }
    }

    public void OpenMenu(Menu menu){

        foreach (Menu m in menus){
            if (m.open == true && m != menu){
                Debug.Log("calling Closing menu: " + m.MenuName);
                CloseMenu(m);
            }
        }
        Debug.Log("Opening menu: " + menu.MenuName);
        menu.Open();
    }

    public void CloseMenu(Menu menu){
        Debug.Log("Closing menu: " + menu.MenuName);
        menu.Close();
    }
}
