using System;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace iTest.Data.Models.Contracts
{
   public class DataModel : IIdentifiable<int>, IDeletable, IEditable
    {
        public int Id { get; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
