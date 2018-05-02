using System;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models.Abstract
{
    public interface IAuditable
    {
        [DataType(DataType.DateTime)]
        DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? ModifiedOn { get; set; }
    }
}
