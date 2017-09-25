using UnityEngine;
using UMA;
using UnityStandardAssets.Characters.ThirdPerson;

public class UMAMaker : MonoBehaviour
{
    public UMAGeneratorBase Generator;
    public SlotLibrary SlotLibrary;
    public OverlayLibrary OverlayLibrary;
    public RaceLibrary RaceLibrary;
    public RuntimeAnimatorController AnimatorController;
    public ThirdPersonCharacter Character;
    public bool GenerateOnStart = true;
    public UMADynamicAvatar Avatar;

    private UMADynamicAvatar _dynamicAvatar;
    private UMAData _data;
    private UMADnaHumanoid _dna;
    private UMADnaTutorial _tutorialDna;

    private int _numSlots = 20;

    void Start()
    {
        if (this.GenerateOnStart)
            this.GenerateUMA();
    }

    public void GenerateUMA()
    {
        //GameObject go = new GameObject("MyUMA");
        //go.transform.parent = this.transform;
        _dynamicAvatar = this.Avatar; // go.AddComponent<UMADynamicAvatar>();

        _dynamicAvatar.Initialize();
        _data = _dynamicAvatar.umaData;
        _dynamicAvatar.umaGenerator = this.Generator;
        _data.umaGenerator = this.Generator;

        UMAData.UMARecipe recipe = _data.umaRecipe;
        recipe.slotDataList = new SlotData[_numSlots];

        _dna = new UMADnaHumanoid();
        _tutorialDna = new UMADnaTutorial();
        recipe.AddDna(_dna);
        recipe.AddDna(_tutorialDna);

        create(recipe);

        _dynamicAvatar.animationController = this.AnimatorController;
        //this.GetComponent<Animator>().applyRootMotion = false;
        /*if (this.Character != null)
        {
            this.Character.m_Animator = go.GetComponent<Animator>();
            this.Character.m_Animator.applyRootMotion = false;
        }*/
        _dynamicAvatar.UpdateNewRace();
    }

    private void create(UMAData.UMARecipe recipe)
    {
        recipe.SetRace(this.RaceLibrary.GetRace("HumanFemale"));

        // Head
        recipe.slotDataList[0] = this.SlotLibrary.InstantiateSlot("FemaleFace");
        recipe.slotDataList[0].AddOverlay(this.OverlayLibrary.InstantiateOverlay("F_H_Head"));

        // Eyes
        recipe.slotDataList[1] = this.SlotLibrary.InstantiateSlot("FemaleEyes");
        recipe.slotDataList[1].AddOverlay(this.OverlayLibrary.InstantiateOverlay("EyeOverlay"));

        // Mouth
        recipe.slotDataList[2] = this.SlotLibrary.InstantiateSlot("FemaleInnerMouth");
        recipe.slotDataList[2].AddOverlay(this.OverlayLibrary.InstantiateOverlay("InnerMouth"));

        // Torso
        recipe.slotDataList[3] = this.SlotLibrary.InstantiateSlot("FemaleTorso");
        recipe.slotDataList[3].AddOverlay(this.OverlayLibrary.InstantiateOverlay("FemaleBody01"));
        //recipe.slotDataList[3].AddOverlay(this.OverlayLibrary.InstantiateOverlay("FemaleUnderwear01"));

        // Hands
        recipe.slotDataList[4] = this.SlotLibrary.InstantiateSlot("FemaleHands");
        recipe.slotDataList[4].AddOverlay(this.OverlayLibrary.InstantiateOverlay("FemaleBody01"));

        // Legs
        recipe.slotDataList[5] = this.SlotLibrary.InstantiateSlot("FemaleLegs");
        recipe.slotDataList[5].AddOverlay(this.OverlayLibrary.InstantiateOverlay("FemaleBody01"));
        recipe.slotDataList[5].AddOverlay(this.OverlayLibrary.InstantiateOverlay("FemaleJeans01"));

        // Feet
        recipe.slotDataList[6] = this.SlotLibrary.InstantiateSlot("FemaleFeet");
        recipe.slotDataList[6].AddOverlay(this.OverlayLibrary.InstantiateOverlay("FemaleBody01"));

        // Shirt
        recipe.slotDataList[7] = this.SlotLibrary.InstantiateSlot("FemaleTshirt01");
        recipe.slotDataList[7].AddOverlay(this.OverlayLibrary.InstantiateOverlay("FemaleTshirt01"));
    }
}
