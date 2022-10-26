using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ModelPerfomance
    {
        public ModelPerfomance(Performances performance)
        {
            ID = performance.ID;
            Title = performance.Title;
            Genre = performance.Genre;
            Producer = performance.Producer;
            Image = performance.Image;  
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Producer { get; set; }
        public string Image { get; set; }   

    }
}