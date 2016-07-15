using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
    public sealed class CodeReviewAttribute : System.Attribute
    {
        public CodeReviewAttribute(string reviewerName, string reviewDate, bool codeIsApproved)
        {
            ReviewerName = reviewerName;
            ReviewDate = reviewDate;
            CodeIsApproved = codeIsApproved;
        }

        public string ReviewerName { get; private set; }
        public string ReviewDate { get; private set; }
        public bool CodeIsApproved { get; private set; }

        public override string ToString()
        {
            return string.Format($"Reviewer name: {ReviewerName}.\nReview Date: {ReviewDate}.\nCode approval state: {CodeIsApproved}.");
        }
        
    }   
}
