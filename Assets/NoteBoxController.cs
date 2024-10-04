using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBoxController : MonoBehaviour, ISelectable
{
    [SerializeField] Material _defaultMaterial;
    [SerializeField] Material _glowMaterial;
    [SerializeField] Material _greenMaterial;
    [SerializeField] Material _redMaterial;
    [SerializeField] AudioClip _audioClip;
    [SerializeField] SimonSaysManager _simonSaysManager;
    AudioSource _audioSource;
    MeshRenderer _meshRenderer;


    void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }
    public void OnHover()
    {
        UIManager.Instance.PressEHover();
        _meshRenderer.material = _glowMaterial;
    }

    public void OnHoverExit()
    {
        UIManager.Instance.PressEHoverExit();
        _meshRenderer.material = _defaultMaterial;
    }

    public void OnSelect()
    {
        PlayAudio();
        StartCoroutine(Glow());
        _simonSaysManager.PlayerSelected(this);
    }

    public IEnumerator Glow()
    {
        _meshRenderer.material = _glowMaterial;
        yield return new WaitForSeconds(2f);
        _meshRenderer.material = _defaultMaterial;
    }

    public void PlayAudio()
    {
        _audioSource.PlayOneShot(_audioClip);
    }

    public IEnumerator HighlightGreen()
    {
        _meshRenderer.material = _greenMaterial;
        yield return new WaitForSeconds(2f);
        _meshRenderer.material = _defaultMaterial;
    }

    public IEnumerator HighlightRed()
    {
        _meshRenderer.material = _redMaterial;
        yield return new WaitForSeconds(2f);
        _meshRenderer.material = _defaultMaterial;
    }


}
