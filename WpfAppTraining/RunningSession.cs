//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfAppTraining
{
    using System;
    using System.Collections.Generic;
    
    public partial class RunningSession
    {
        public int Id { get; set; }
        public System.DateTime When { get; set; }
        public int Distance { get; set; }
        public System.TimeSpan Time { get; set; }
        public float AverageSpeed { get; set; }
        public int TrainingType { get; set; }
        public string Comments { get; set; }
    }
}
