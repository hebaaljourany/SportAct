using System;
using System.ComponentModel.DataAnnotations;

namespace SportAct.Domain
{
    public class CreateUpdateClientDto
    {
        [Required]
        //[StringLength(128)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public int MobileNumber { get; set; }
    }
}