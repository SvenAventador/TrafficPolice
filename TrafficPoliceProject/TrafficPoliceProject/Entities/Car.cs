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
    
    public partial class Car
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Weight { get; set; }
        public int ColorId { get; set; }
        public int EngineTypeId { get; set; }
        public int TypeOfDriveId { get; set; }
        public string CarNumber { get; set; }
        public int DriverId { get; set; }
    
        public virtual Color Color { get; set; }
        public virtual Drivers Drivers { get; set; }
        public virtual EngineType EngineType { get; set; }
        public virtual TypeOfDrive TypeOfDrive { get; set; }
    }
}
