﻿using System;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models.Abstract
{
    public class DataModel : IDeletable, IAuditable
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }
    }
}
