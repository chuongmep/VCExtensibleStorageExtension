using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Autodesk.Revit.DB;
using Revit.ES.Extension.Attributes;

namespace Revit.ES.Extension.Demo.Model
{
    [Schema("675551F3-04D4-4A33-94CA-0C2E34B2A5BF", "FooEntity",
        Documentation = "The class I want to save in the project")]
    public class FooEntity : IRevitEntity
    {
        #region Simple properties

        [Field(Documentation = "Int32 Property")]
        public int IntProperty { get; set; }

        [Field(Documentation = "Int16 Property")]
        public short ShortProperty { get; set; }

        [Field(Documentation = "Byte Property")]
        public byte ByteProperty { get; set; }

#if FORGETYPEID
        [Field(Documentation = "Double Property", SpecTypeId = Utils.specTypeIdPrefix + ".electrical:cableTraySize" + Utils.specTypeIdSuffix)]
#else
        [Field(Documentation = "Double Property", UnitType = UnitType.UT_Electrical_CableTraySize)]
#endif
        public double DoubleProperty { get; set; }

#if FORGETYPEID
        [Field(Documentation = "Float Property", SpecTypeId = Utils.specTypeIdPrefix + ":number" + Utils.specTypeIdSuffix)]
#else
        [Field(Documentation = "Float Property", UnitType = UnitType.UT_Number)]
#endif
        public float FloatProperty { get; set; }

        [Field(Documentation = "Boolean Property")]
        public bool BoolProperty { get; set; }

        [Field(Documentation = "String Property")]
        public string StringProperty { get; set; }

        [Field(Documentation = "Guid Property")]
        public Guid GuidProperty { get; set; }

        [Field(Documentation = "ElementId Property")]
        public ElementId ElementIdProperty { get; set; }

#if FORGETYPEID
        [Field(Documentation = "XYZ Property", SpecTypeId = Utils.specTypeIdPrefix + ":volume" + Utils.specTypeIdSuffix)]
#else
        [Field(Documentation = "XYZ Property", UnitType = UnitType.UT_Volume)]
#endif
        public XYZ XyzProperty { get; set; }

#if FORGETYPEID
        [Field(Documentation = "UV Property", SpecTypeId = Utils.specTypeIdPrefix + ".hvac:ductInsulationThickness" + Utils.specTypeIdSuffix)]
#else
        [Field(Documentation = "UV Property", UnitType =  UnitType.UT_HVAC_DuctInsulationThickness)]
#endif
        public UV UvProperty { get; set; }

        [Field]
        public DeepEntity DeepEntityProperty { get; set; }

        #endregion

        #region ArrayProperties


        [Field(Documentation = "Int32 Collection Property")]
        public Collection<int> IntArrayProperty { get; set; }

        [Field(Documentation = "Int16 List Property")]
        public List<short> ShortArrayProperty { get; set; }

        [Field(Documentation = "BindingList of Byte Property")]
        public BindingList<byte> ByteArrayProperty { get; set; }

        [Field(Documentation = "ObservableCollection of Double Property",
#if FORGETYPEID
            SpecTypeId = Utils.specTypeIdPrefix + ".hvac:temperature" + Utils.specTypeIdSuffix)]
#else
            UnitType = UnitType.UT_HVAC_Temperature)]
#endif
        public ObservableCollection<double> DoubleArrayProperty { get; set; }

        [Field(Documentation = "Float List Property",
#if FORGETYPEID
            SpecTypeId = Utils.specTypeIdPrefix + ".structural:force" + Utils.specTypeIdSuffix)]
#else
            UnitType = UnitType.UT_Force)]
#endif
        public List<float> FloatArrayProperty { get; set; }

        [Field(Documentation = "Boolean Property")]
        public Collection<bool> BoolArrayProperty { get; set; }

        [Field(Documentation = "String List Property")]
        public List<string> StringArrayProperty { get; set; }

        [Field(Documentation = "Guid List Property")]
        public List<Guid> GuidArrayProperty { get; set; }

        [Field(Documentation = "ElementId List Property")]
        public List<ElementId> ElementIdArrayProperty { get; set; }

        [Field(Documentation = "XYZ Property",
#if FORGETYPEID
            SpecTypeId = Utils.specTypeIdPrefix + ".piping:temperature" + Utils.specTypeIdSuffix)]
#else
            UnitType = UnitType.UT_Piping_Temperature)]
#endif
        public Collection<XYZ> XyzArrayProperty { get; set; }

        [Field(Documentation = "UV BindingList Property",
#if FORGETYPEID
            SpecTypeId = Utils.specTypeIdPrefix + ".energy:energy" + Utils.specTypeIdSuffix)]
#else
            UnitType = UnitType.UT_HVAC_Energy)]
#endif
        public BindingList<UV> UvArrayProperty { get; set; }

        [Field]
        public List<BarEntity> BarEntityArray { get; set; }

        #endregion


        #region Map properties

        /* The supported types for the keys are 
         * Boolean, Byte, Int16, Int32, ElementId, GUID and String. 
         */

#if FORGETYPEID
        [Field(SpecTypeId = Utils.specTypeIdPrefix + ".hvac:ductLiningThickness" + Utils.specTypeIdSuffix)]
#else
        [Field(UnitType = UnitType.UT_HVAC_DuctLiningThickness)]
#endif
        public Dictionary<bool, XYZ> BoolXyzMap { get; set; }

        [Field]
        public SortedDictionary<Byte, Guid> ByteGuidMap { get; set; }

        [Field]
        public Dictionary<short, ElementId> ShortElementIdMap { get; set; }

        [Field]
        public SortedDictionary<int, BarEntity> IntBarEntityMap { get; set; }

        [Field]
        public Dictionary<ElementId, string> ElementIdStringMap { get; set; }

        [Field]
        public Dictionary<Guid, DeepEntity> GuidDeepEntityMap { get; set; }

#if FORGETYPEID
        [Field(SpecTypeId = Utils.specTypeIdPrefix + ".electrical:demandFactor" + Utils.specTypeIdSuffix)]
#else
        [Field(UnitType = UnitType.UT_Electrical_Demand_Factor)]
#endif
        public SortedDictionary<string, double> StringDoubleMap { get; set; }

        #endregion

        /// <summary>
        /// This property won't save in an Entity
        /// </summary>
        //public string NonFieldProperty { get; set; }
    }
}
