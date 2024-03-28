using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCRUDAPI.Models
{
    [MetadataType(typeof(PEOPLE.MetaData))]
    public partial class PEOPLE
    {
        sealed class MetaData
        {
            [Required]
            public string name;
        }
    }
}