using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatLadyNPC : MonoBehaviour {
    public IsWizard Wizard;
    public IsIgnitableObject[] Torchs;
    public IsIgnitableObject Fireplace;

    private bool sleeping = false;
    private DialogSubtitles subtitles;

    private void Start()
    {
        subtitles = Wizard.GetComponent<DialogSubtitles>();
    }

    public void TalkTo()
    {
        if (sleeping) return;

        if (!Wizard.HasMagicWand)
        {
            subtitles.Display("Enfin réveillé ?! Va chercher ta baguette avant de sortir !");
        }
        else if (!TorchesAreOff())
        {
            subtitles.Display("Puisque tu as ta baguette, profites en pour éteindre les lumière de la salle commune avec le sort : Aguamenti !");
            if (!Wizard.KnowsSpell("Aguamenti"))
            {
                Wizard.LearnNewSpell("Aguamenti");
            }
        }
        else if (!FirePlaceIsLit())
        {
            subtitles.Display("Tant qu'on y est, allume le feu de la cheminée avec le sort : Incendio !");
            if (!Wizard.KnowsSpell("Incendio"))
            {
                Wizard.LearnNewSpell("Incendio");
            }
        }
        else
        {
            subtitles.Display("Allez, je te laisse passer mais ne m'embête plus. Je dors.");
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
