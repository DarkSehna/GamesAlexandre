using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComponent : MonoBehaviour, ILogicUpdate
{
    protected Core core;

    protected virtual void Awake()
    {
        core = transform.parent.GetComponent<Core>();

        if(core == null)
        {
            Debug.LogError("There is no Core on the parent");
        }

        core.AddComponent(this); //Add the component to the list
    }

    public virtual void LogicUpdate() { } //Implement ILogicUpdate as a virtual function
}
