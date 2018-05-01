using iTest.Data.Models.Abstract;
using Microsoft.TeamFoundation.TestManagement.Client;
using System.Collections.Generic;

namespace iTest.Data.Models.Implementations
{
    public class User : DataModel, IIdentifiable<int>, IEditable, IDeletable, IAuditable
    {
        public ICollection<UserTest> Tests { get; set; } = new List<UserTest>();
    }
}
