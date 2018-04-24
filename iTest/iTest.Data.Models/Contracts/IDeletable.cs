using System;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models.Contracts
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? DeletedOn { get; set; }
    }
}
