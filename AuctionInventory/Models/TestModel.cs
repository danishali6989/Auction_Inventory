using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AuctionInventory.Models
{

    public class TestModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

    }



}