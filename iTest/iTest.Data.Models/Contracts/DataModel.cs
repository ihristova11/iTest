using System;

namespace iTest.Data.Models.Contracts
{
    public class DataModel : IEditable, IDeletable
    {
        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
