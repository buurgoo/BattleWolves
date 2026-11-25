using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class FeedingManager : MonoBehaviour
{
    [SerializeField] private WolfHomeController wolf;
    [SerializeField] private GameObject feedingMenu;

    public void OnRabbitButtonClicked()
    {
        Debug.Log("Eat: Rabbit button clicked");
        wolf.ReduceHunger(25f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
    }

    public void OnChickenButtonClicked()
    {
        Debug.Log("Eat: Chicken button clicked");
        wolf.ReduceHunger(17f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
    }

   public void OnTurkeyButtonClicked()
    {
        wolf.ReduceHunger(17f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
        Debug.Log("Eat: Turkey button clicked");
    }

    public void OnPorkButtonClicked()
    {
        wolf.ReduceHunger(30f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
        Debug.Log("Eat: Pork button clicked");
    }

    public void OnBeefButtonClicked()
    {
        wolf.ReduceHunger(30f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
        Debug.Log("Eat: Beef button clicked");
    }

    public void OnPotatoButtonClicked()
    {
        wolf.ReduceHunger(5f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
        Debug.Log("Eat: Potato button clicked");
    }

    public void OnSausageButtonClicked()
    {
        wolf.ReduceHunger(12f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
        Debug.Log("Eat: Sausage button clicked");
    }

    public void OnDumplingsButtonClicked()
    {
        wolf.ReduceHunger(25f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
        Debug.Log("Eat: Dumplings button clicked");
    }

    public void OnVarenikiButtonClicked()
    {
        wolf.ReduceHunger(20f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
        Debug.Log("Eat: Vareniki button clicked");
    }

    public void OnBorschtButtonClicked()
    {
        wolf.ReduceHunger(15f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
        Debug.Log("Eat: Borscht button clicked");
    }

    public void OnTeaButtonClicked()
    {
        wolf.ReduceHunger(5f);
        CloseMenu();
        wolf.animator.SetTrigger("isEating");
        Debug.Log("Eat: Tea button clicked");
    }

    // public void OnMedicine10ButtonClicked()
    // {
    //     wolf.Healing(10f);
    //     CloseMenu();
    //     // wolf.animator.SetTrigger("isEating"); 
    //     Debug.Log("Healing: Medicine x10 button clicked");
    // }

    // public void OnMedicine20ButtonClicked()
    // {
    //     wolf.Healing(20f);
    //     CloseMenu();
    //     // wolf.animator.SetTrigger("isEating"); 
    //     Debug.Log("Healing: Medicine x20 button clicked");
    // }

    // public void OnMedicine30ButtonClicked()
    // {
    //     wolf.Healing(30f);
    //     CloseMenu();
    //     // wolf.animator.SetTrigger("isEating"); 
    //     Debug.Log("Healing: Medicine x30 button clicked");
    // }

    public void OpenMenu()
    {
        Debug.Log("Feeding menu opened");
        feedingMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        Debug.Log("Feeding menu closed");
        feedingMenu.SetActive(false);
    }
}