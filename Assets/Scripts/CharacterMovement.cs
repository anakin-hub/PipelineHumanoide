using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMovement : MonoBehaviour
{
    public UnityEvent onCapoeira;
    public UnityEvent onPunch;
    public UnityEvent onKick;

    private KeyCode _capoeiraKey = KeyCode.F;
    private KeyCode _punchKey = KeyCode.G;
    private KeyCode _kickKey = KeyCode.H;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        onCapoeira.AddListener(CapoeiraToggle);
        onPunch.AddListener(PunchingToggle);
        onKick.AddListener(KickingToggle);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(_capoeiraKey))
        {
            onCapoeira.Invoke();
            Debug.Log("capoeira");
        }

        if (Input.GetKeyDown(_punchKey)) { onPunch.Invoke(); }
        if (Input.GetKeyDown(_kickKey)) { onKick.Invoke(); }
    }

    IEnumerator ActionTrigger(string animBool)
    {
        _animator.SetBool(animBool, true);
        yield return null;
        _animator.SetBool(animBool, false);
    }

    void CapoeiraToggle()
    {
        StartCoroutine(ActionTrigger("isCapoeira"));
    }

    void KickingToggle()
    {
        StartCoroutine(ActionTrigger("isKicking"));
    }
    void PunchingToggle()
    {
        StartCoroutine(ActionTrigger("isPunching"));
    }
}
