//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrafficPoliceProject.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Color
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Color()
        {
            this.Car = new HashSet<Car>();
        }
    
        public int ColorId { get; set; }
        public string ColorCode { get; set; }
        public string Name { get; set; }
        public string ColorName_RU_ { get; set; }
        public bool IsMetallic_ { get; set; }
        public string Name_EN_ { get; set; }
        public string ColorName_EN_ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Car> Car { get; set; }
    }
}
