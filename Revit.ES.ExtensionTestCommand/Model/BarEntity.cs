using System.Collections.Generic;
using Revit.ES.Extension.Attributes;

namespace Revit.ES.Extension.Demo.Model
{
    [Schema("0488C456-66B2-445F-817C-34C1A4DF4546",
        "TestEntitySchema",
        Documentation = "Provide entity for test command")]
    public class BarEntity : IRevitEntity
    {
        [Field(Documentation = "Field store some string property")]
        public string Property1 { get; set; }

        [Field(Documentation = "Integer property")]
        public int Property2 { get; set; }

#if FORGETYPEID
        [Field(SpecTypeId = Utils.specTypeIdPrefix + ".piping:velocity" + Utils.specTypeIdSuffix)]
#else
        [Field(UnitType = UnitType.UT_Piping_Velocity)] 
#endif
        public double Property3 { get; set; }        

        [Field]
        public DeepEntity SubEntity { get; set; }

        [Field]
        public List<int> ArrayField { get; set; }

        [Field]
        public List<DeepEntity> SubEntities { get; set; }
        
    }
}
