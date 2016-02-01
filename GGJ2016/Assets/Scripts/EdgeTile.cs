using UnityEngine;
using System.Collections;

public class EdgeTile : MonoBehaviour
{
    [SerializeField] private bool isInUse = false;

    [SerializeField] private ParticleSystem selectionParticle;

    [SerializeField] private GameObject currentTrap;
    [SerializeField] private GameObject trapSpawnPoint;

    private void Start()
    {
        selectionParticle = GetComponent<ParticleSystem>();
        selectionParticle.enableEmission = false;

        currentTrap.SetActive(false);
    }

    public void ActivateParticle()
    {
        selectionParticle.enableEmission = true;
    }

    public void DeactivateParticle()
    {
        selectionParticle.enableEmission = false;
    }

    public bool GetIsInUse()
    {
        return isInUse;
    }

    public void SetIsInUse(bool _value)
    {
        isInUse = _value;
    }

    public void SetTrap()
    {
        currentTrap.SetActive(true);
		GameManager.Instance.AddCandy(this.gameObject);
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Dedushka")
        {
            ActivateParticle();
            _other.GetComponent<Dedushka>().SetCurrentTile(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Dedushka")
        {
            DeactivateParticle();
            _other.GetComponent<Dedushka>().SetCurrentTile(null);
        }
    }
}
