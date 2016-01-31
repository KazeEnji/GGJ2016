using UnityEngine;
using System.Collections;

public class PlantTile : MonoBehaviour
{
    [SerializeField] private bool isInUse = false;

    [SerializeField] private ParticleSystem selectionParticle;

    [SerializeField] private GameObject currentPlant;
    [SerializeField] private GameObject plantSpawnPoint;

    private void Start()
    {
        selectionParticle = GetComponent<ParticleSystem>();
        selectionParticle.Stop();
    }

    public void ActivateParticle()
    {
        selectionParticle.Play();
    }

    public void DeactivateParticle()
    {
        selectionParticle.Stop();
    }

    public bool GetIsInUse()
    {
        return isInUse;
    }

    public void SetIsInUse(bool _value)
    {
        isInUse = _value;
    }

    public void SetCurrentPlant(GameObject _plant)
    {
        currentPlant = _plant;
    }

    private void OnTriggerStay(Collider _other)
    {
        if(_other.tag == "Babushka")
        {
            ActivateParticle();
            _other.GetComponent<Babushka>().SetCurrentTile(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if(_other.tag == "Babushka")
        {
            DeactivateParticle();
            _other.GetComponent<Babushka>().SetCurrentTile(null);
        }
    }
}
