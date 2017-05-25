using System;
using UnityEngine.Graphing;

namespace UnityEngine.MaterialGraph
{
    [Serializable]
    [Title("Master/Unlit")]
    public class UnlitMasterNode : AbstractAdvancedMasterNode
    {
        public const string LightFunctionName = "Advanced";
        public const string SurfaceOutputStructureName = "SurfaceOutputAdvanced";

        public UnlitMasterNode()
        {
            name = "UnlitMaster";
            UpdateNodeAfterDeserialization();
        }

        public override string GetMaterialID()
        {
            return "SHADINGMODELID_UNLIT";
        }

        public override int[] GetCustomDataSlots()
        {
            return new int[] { };
        }

        public override string[] GetCustomData()
        {
            return new string[] { };
        }

        public sealed override void UpdateNodeAfterDeserialization()
        {
            AddSlot(new MaterialSlot(AlbedoSlotId, AlbedoSlotName, AlbedoSlotName, SlotType.Input, SlotValueType.Vector3, Vector4.zero));
            AddSlot(new MaterialSlot(NormalSlotId, NormalSlotName, NormalSlotName, SlotType.Input, SlotValueType.Vector3, Vector4.zero));
            AddSlot(new MaterialSlot(EmissionSlotId, EmissionSlotName, EmissionSlotName, SlotType.Input, SlotValueType.Vector3, Vector4.zero));
            AddSlot(new MaterialSlot(AlphaSlotId, AlphaSlotName, AlphaSlotName, SlotType.Input, SlotValueType.Vector1, Vector4.zero));

            // clear out slot names that do not match the slots
            // we support
            RemoveSlotsNameNotMatching(
                                       new[]
                                       {
                                           AlbedoSlotId,
                                           NormalSlotId,
                                           EmissionSlotId,
                                           AlphaSlotId
                                       });
        }
        
        public override string GetSurfaceOutputName()
        {
            return SurfaceOutputStructureName;
        }

        public override string GetLightFunction()
        {
            return LightFunctionName;
        }
    }
}
