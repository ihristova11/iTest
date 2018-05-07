using iTest.Data.Models.Abstract;
using iTest.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace iTest.Data.Models
{
    public class UserTest : IDeletable, IAuditable
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public TimeSpan RequestedTime { get; set; }

        public DateTime StartedOn { get; set; }

        public TimeSpan ExecutionTime { get; set; }

        public bool IsDeleted { get; set; }

        public ResultStatus ResultStatus { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }


    }
}