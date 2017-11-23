using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanLaunchSpells : MonoBehaviour {
    public bool hasMagicWand = false;
    public float spellsRange = 20.0f;
    public float spellsCooldown = 0.2f;
    public float useDistance = 2f;

    private float spellCooldownRemaining = 0.0f;
    private List<Spell> spells;
    private Spell equippedSpell;
    private int equippedSpellIndex = 0;
    private GameObject magicWand;
    private Quaternion magicWandInitialRotation;
    private Vector3 magicWandInitialPosition;

    // Use this for initialization
    void Start() {
        spells = new List<Spell>();
        Spell s1 = (Spell)ScriptableObject.CreateInstance("Spell");
        s1.Init("Incendio", 0.5f);
        spells.Add(s1);
        
        Spell s2 = (Spell)ScriptableObject.CreateInstance("Spell");
        s2.Init("Aguamenti", 0.5f);
        spells.Add(s2);

        equippedSpell = spells[0];

        magicWand = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        magicWandInitialRotation = magicWand.transform.localRotation;
        magicWandInitialPosition = magicWand.transform.localPosition;
        if (!hasMagicWand)
        {
            magicWand.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        HandleUseKey();
        if (!hasMagicWand) return;

        spellCooldownRemaining -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            magicWand.transform.localRotation = Quaternion.Euler(90, 0, 0);
            magicWand.transform.localPosition += new Vector3(0, -0.1f, 0);
        }

        // fire a spell
        if (Input.GetMouseButton(0) && spellCooldownRemaining <= 0 && equippedSpell != null)
        {
            equippedSpell.Launch(Camera.main.transform.position, Camera.main.transform.forward, Camera.main.transform.rotation);
            spellCooldownRemaining = equippedSpell.Cooldown;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            magicWand.transform.localRotation = magicWandInitialRotation;
            magicWand.transform.localPosition = magicWandInitialPosition;
        }
        float mRot = Input.GetAxis("Mouse ScrollWheel");
        if ( mRot != 0.0f)
        {
            ChangeEquippedSpell(mRot>0.0f ? 1 : -1);
        }

        
    }

    void ChangeEquippedSpell(int addToIndex)
    {
        if (!Input.GetMouseButton(0))
        {
            equippedSpellIndex = Mathf.Clamp(equippedSpellIndex+addToIndex, 0, spells.Count - 1);
            equippedSpell = spells[equippedSpellIndex];
            //Debug.Log("changed spell to : " + equippedSpell.SpellName);
        }
        
    }

    public void GotMagicWand()
    {
        hasMagicWand = true;
        magicWand.SetActive(true);
    }

    void HandleUseKey()
    {
        if (Input.GetButtonDown("Use"))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 2.0f))
            {
                //Debug.Log(hitInfo.collider.gameObject.name); // prints the name of the object we're aiming at
                Vector3 hitPoint = hitInfo.point;
                GameObject target = hitInfo.collider.gameObject;

                CollectibleObject collectible = target.GetComponent<CollectibleObject>();
                if (collectible != null)
                {
                    collectible.Collect(gameObject);
                }

                InteractiveObject interactive = target.GetComponent<InteractiveObject>();
                if (interactive != null)
                {
                    interactive.Interact();
                }
            }
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 2.0f, Color.green, 5.0f);
        }
    }
}
