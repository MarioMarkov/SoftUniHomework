﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        //[Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        //[Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        //[Column(TypeName = "nvarchar(250)")]
        public string Address{ get; set; }

        //[Column(TypeName = "varchar(80)")]
        public string Email { get; set; }

        public bool HasInsurance { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; }

        public ICollection<Visitation> Visitations { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; }

       
    }
}
