//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CvDeneme.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CvInformation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bo? b?rak?lmaz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bo? b?rak?lmaz")]
        public string LName { get; set; }
        [Required(ErrorMessage = "Bo? b?rak?lmaz")]
        public long Phone { get; set; }
        [Required(ErrorMessage = "Bo? b?rak?lmaz")]
        public string Mail { get; set; }
        public string Adress { get; set; }
        public string Position { get; set; }
        [Required(ErrorMessage = "Bo? b?rak?lmaz")]
        public string CoverLetter { get; set; }
        [Required(ErrorMessage = "Bo? b?rak?lmaz")]
        public string Education { get; set; }
        public string Experience { get; set; }
        public string Skills { get; set; }
        public string Certificate { get; set; }
        public string Reference { get; set; }
        public string Hobby { get; set; }
        public string Image { get; set; }
        public string Documan { get; set; }
    }
}
