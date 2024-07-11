using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngamePanel : MonoBehaviour
{

    protected bool _isEndTransitionAnim         = false;
    protected bool _isOpen                      = false;

    public virtual void OnOpenTransition()      { gameObject.SetActive(true);   }
    public virtual void OnCloseTransition()     { gameObject.SetActive(false);  }

    public virtual void OnOpenEvent()       { _isOpen = true;       }
    public virtual void OnCloseEvent()      { _isOpen = false;      }

}
