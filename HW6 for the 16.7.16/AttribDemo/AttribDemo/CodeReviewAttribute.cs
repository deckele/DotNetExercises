using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    public sealed class CodeReviewAttribute : System.Attribute
    {
        public CodeReviewAttribute(string reviewerName, DateTime reviewDate, bool codeIsApproved)
        {
            ReviewerName = reviewerName;
            ReviewDate = reviewDate.Date;
            CodeIsApproved = codeIsApproved;
        }

        public string ReviewerName { get; private set; }
        public DateTime ReviewDate { get; private set; }
        public bool CodeIsApproved { get; private set; }

        public override string ToString()
        {
            return string.Format($"Reviewer name: {ReviewerName}.\nReview Date: {ReviewDate.Date}.\nCode approval state: {CodeIsApproved}.");
        }
    }
}
