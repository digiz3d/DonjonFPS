using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatLadyNPC : MonoBehaviour {
    public IsWizard Wizard;
    public IsIgnitableObject[] Torchs;
    public IsIgnitableObject Fireplace;

    private bool sleeping = false;

    public void TalkTo()
    {
        if (sleeping) return;

        if (!Wizard.HasMagicWand)
        {
            Debug.Log("Va chercher ta baguette fdp");
        }
        else if (!TorchesAreOff())
        {
            Debug.Log("Puisque tu as ta baguette, profites en pour éteindre les lumière de la salle commune avec le sort : Aguamenti !");
            if (!Wizard.KnowsSpell("Aguamenti"))
            {
                Wizard.LearnNewSpell("Aguamenti");
            }
        }
        else if (!FirePlaceIsLit())
        {
            Debug.Log("Tant qu'on y est, allume le feu de la cheminée avec le sort : Incendio !");
            if (!Wizard.KnowsSpell("Incendio"))
            {
                Wizard.LearnNewSpell("Incendio");
            }
        }
        else
        {
            Debug.Log("Pas mal gamin");
            GetComponent<DoorScript>().Open();
        }
        
    }

    public void GoToSleep()
    {
        this.sleeping = true;
    }

    private bool TorchesAreOff()
    {
        foreach(IsIgnitableObject torch in Torchs)
        {
            if (torch.IsLit)
            {
                return false;
            }
        }
        return true;
    }

    private bool FirePlaceIsLit()
    {
        return Fireplace.IsLit;
    }
}
