using System;
using System.ComponentModel.DataAnnotations;

namespace SportAct.ActivityTypes
{
    public class CreateUpdateActivityTypeDto
    {
        [Required]
        public string ActivityTypeName { get; set; }
        //public List<SportActivity> SportActivitiesType { get; set; }
    }
}