using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Review_2017_1
{
    class Test2
    {
        public int Id { set; get; }

        public override bool Equals(object obj)
        {
            bool IsEquals = false;
            Test2 test2Obj = obj as Test2;
            if (test2Obj != null)
            {
                if (this.Id == test2Obj.Id)
                {
                    IsEquals = true;
                }
            }

            return IsEquals;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Test2 left, Test2 right)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(left, right))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)left == null) || ((object)right == null))
            {
                return false;
            }

            // Return true if the fields match:
            return left.Id == right.Id;
        }

        public static bool operator !=(Test2 left, Test2 right)
        {
            return !(left == right);
        }
    }
}
