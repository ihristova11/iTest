using Microsoft.TeamFoundation.TestManagement.Client;
using System;

namespace iTest.Data.Models.Abstract
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
