using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] AnimationManager _animMan;
    [SerializeField] Canvas _canvas;
    private Coroutine _timerCor = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DD (Collider other)
    {
        Logger.Log("Player");
    }
    public void OnPlayerDetected()
    {
        _canvas.enabled = true;
        _anim.enabled = true;
        _anim.SetTrigger("open");
        if (_timerCor != null)
        {
            StopCoroutine(_timerCor);
            _timerCor = null;
        }
    }

    public void OnPlayerLeft()
    {
        _anim.SetTrigger("close");
        _timerCor=StartCoroutine(HelperClass.DelayedFunction(_animMan.GetAnimationLength("close") + 0.01f, () =>
        { 
            _anim.enabled = false; 
            _canvas.enabled = false; 
        }));
    }
    
}
