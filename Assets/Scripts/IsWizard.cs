using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsWizard : MonoBehaviour {
    public bool HasMagicWand = false;
    public float SpellsRange = 20.0f;
    public float SpellsCooldown = 0.2f;
    public float UseDistance = 2f;
    public GameObject SpellPanel;
    public Text EveryFlavourBeansUI;
    public Text ActiveSpellUI;
    public int EveryFlavourBeans = 0;

    private Transform CamTransform;
    private float spellCooldownRemaining = 0.0f;
    private List<Spell> spells;
    private Spell equippedSpell;
    private int equippedSpellIndex = 0;
    private GameObject magicWand;
    private Quaternion magicWandInitialRotation;
    private Vector3 magicWandInitialPosition;
    private DialogSubtitles subtitlesComponent;

    // Use this for initialization
    void Start() {
        CamTransform = gameObject.transform.GetChild(0);

        spells = new List<Spell>();

        LearnNewSpell("Lumos", 1.0f);

        equippedSpell = spells[0];

        
        SetActiveSpellText(equippedSpell.Name);

        magicWand = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        magicWandInitialRotation = magicWand.transform.localRotation;
        magicWandInitialPosition = magicWand.transform.localPosition;
        if (!HasMagicWand)
        {
            magicWand.SetActive(false);
            SpellPanel.SetActive(false);
        }
        subtitlesComponent = GetComponent<DialogSubtitles>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!HasMagicWand) return;

        spellCooldownRemaining -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            magicWand.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
            magicWand.transform.localPosition += new Vector3(0.0f, -0.1f, 0.0f);
        }

        // launch a spell
        if (Input.GetMouseButton(0) && spellCooldownRemaining <= 0 && equippedSpell != null)
        {
            LaunchSpell();
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            magicWand.transform.localRotation = magicWandInitialRotation;
            magicWand.transform.localPosition = magicWandInitialPosition;
        }

        // mouse whell changes equipped spell
        float mRot = Input.GetAxis("Mouse ScrollWheel");
        if ( mRot != 0.0f)
        {
            ChangeEquippedSpell(mRot>0.0f ? -1 : 1);
        }
    }

    void ChangeEquippedSpell(int addToIndex)
    {
        if (!Input.GetMouseButton(0))
        {
            equippedSpellIndex = Mathf.Clamp(equippedSpellIndex+addToIndex, 0, spells.Count - 1);
            equippedSpell = spells[equippedSpellIndex];
            //Debug.Log("changed spell to : " + equippedSpell.SpellName);
            SetActiveSpellText(equippedSpell.Name);
        }
        
    }

    public void GotMagicWand()
    {
        SpellPanel.SetActive(true);
        HasMagicWand = true;
        magicWand.SetActive(true);
    }

    public void AddEveryFlavourBeans(int quantity)
    {
        EveryFlavourBeans += quantity;
        UpdateEveryFlavourBeansUI();
    }

    public void RemoveEveryFlavourBeans(int quantity)
    {
        EveryFlavourBeans -= quantity;
        if (EveryFlavourBeans < 0)
        {
            EveryFlavourBeans = 0;
        }
        UpdateEveryFlavourBeansUI();
    }
    private void UpdateEveryFlavourBeansUI()
    {
        EveryFlavourBeansUI.text = EveryFlavourBeans.ToString();
    }
    public void LearnNewSpell(string spellName, float cooldown)
    {
        if (!KnowsSpell(spellName))
        {
            Spell newSpell = (Spell)ScriptableObject.CreateInstance("Spell");
            newSpell.Init(spellName, cooldown);
            this.spells.Add(newSpell);
        }
    }

    public void LearnNewSpell(string spellName)
    {
        this.LearnNewSpell(spellName, 0.5f);
    }

    public bool KnowsSpell(string spellName)
    {
        foreach (Spell spell in spells)
        {
            if (spell.Name == spellName)
            {
                return true;
            }
        }
        return false;
    }

    private void LaunchSpell()
    {
        equippedSpell.Launch(CamTransform.position, CamTransform.forward, CamTransform.rotation);
        spellCooldownRemaining = equippedSpell.Cooldown;
        if (subtitlesComponent != null)
        {
            subtitlesComponent.Display("<i>" + equippedSpell.Name + " !</i>");
        }
    }

    private void SetActiveSpellText(string text)
    {
        if (ActiveSpellUI != null)
        {
            ActiveSpellUI.text = text;
        }
    }
}
