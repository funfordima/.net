using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential2.Library
{
    public class Customer: IComparable<Customer>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly CreateDate { get; set; }

        public int CompareTo(Customer? other)
        {
            if (other.Id == this.Id) {
                return 0;
            }

            if (other.Id > this.Id)
            {
                return -1;
            }

            return 1;
        }

        public T Map<T>(IMapper<Customer, T> mapper) {
            return mapper.Map(this);
        }
    }
}
