//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CandidatesSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Candidate
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string First_Name { get; set; }
        [DisplayName("Last Name")]
        public string Last_Name { get; set; }
        [DisplayName("Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime Date_of_Birth { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        [DisplayName("C#.NET & ASP")]
        public Nullable<int> C_NET_ASP { get; set; }
        public Nullable<int> CSS { get; set; }
        public Nullable<int> HTML { get; set; }
        public Nullable<int> Java { get; set; }
        public Nullable<int> JavaScript { get; set; }
        public Nullable<int> Python { get; set; }
        [DisplayName("Python Flask")]
        public Nullable<int> Python_Flask { get; set; }
    }
}
