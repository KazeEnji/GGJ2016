using UnityEngine;
using System.Collections;

public class PlantTile : MonoBehaviour
{
    [SerializeField] private bool isInUse = false;

    [SerializeField] private ParticleSystem selectionParticle;

    [SerializeField] private GameObject redFlower, yellowFlower, whiteFlower;

    [SerializeField] private GameObject currentPlant;
    [SerializeField] private GameObject plantSpawnPoint;

    private void Start()
    {
        selectionParticle = GetComponent<ParticleSystem>();
        selectionParticle.enableEmission = false;

		if (redFlower != null) redFlower.SetActive(false);
		if (yellowFlower != null) yellowFlower.SetActive(false);
		if (whiteFlower != null) whiteFlower.SetActive(false);
    }

    public void PlantFlower(Babushka.SeedType _seed)
    {
        switch (_seed)
        {
            case Babushka.SeedType.Red:
                {
                    redFlower.SetActive(true);
                    break;
                }
            case Babushka.SeedType.White:
                {
                    whiteFlower.SetActive(true);
                    break;
                }
            case Babushka.SeedType.Yellow:
                {
                    yellowFlower.SetActive(true);
                    break;
                }
        }
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

    public void SetCurrentPlant(GameObject _plant)
    {
        currentPlant = _plant;
    }

    private void OnTriggerEnter(Collider _other)
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
        }
    }
}
