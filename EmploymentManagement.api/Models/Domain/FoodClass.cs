﻿namespace EmploymentManagement.api.Models.Domain
{
    public class FoodClass : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        //public ICollection<Food> Foods { get; set; }
    }
}
