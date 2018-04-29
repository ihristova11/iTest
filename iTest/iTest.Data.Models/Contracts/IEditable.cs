using System;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models.Contracts
{
    public interface IEditable
    {
        [DataType(DataType.DateTime)]
        DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        DateTime? ModifiedOn { get; set; }
    }
}
