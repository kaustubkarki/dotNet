﻿namespace wepAppPractice.ViewModels
{
    public class CategoryViewModel
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NameAndDescription => $"{Name} {Description}";

        //public string IdAndName => $"{Name }";
    }
}
