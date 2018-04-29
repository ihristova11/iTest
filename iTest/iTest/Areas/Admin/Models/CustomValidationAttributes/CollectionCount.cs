using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace iTest.Web.Areas.Admin.Models.CustomValidationAttributes
{
    public class CollectionCount : ValidationAttribute
    {
        private int min;

        public CollectionCount(int min)
        {
            this.min = min;
        }

        public override bool IsValid(object value)
        {
            var list = value as ICollection;
            if (list != null)
            {
                return list.Count >= this.min;
            }
            return false;
        }
    }
}
